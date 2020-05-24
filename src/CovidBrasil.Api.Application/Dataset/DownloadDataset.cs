using System;
using System.IO;
using CovidBrasil.Api.Application.Common;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;

namespace CovidBrasil.Api.Application.Dataset
{
    public class DownloadDataset
    {
        private readonly ILogger<DownloadDataset> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatasetRepository _datasetRepository;
        private const string FILE_PATH = "./tmp";

        public DownloadDataset(ILogger<DownloadDataset> logger, 
            IUnitOfWork unitOfWork, IDatasetRepository datasetRepository)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _datasetRepository = datasetRepository;
        }

        public void Download()
        {
            _logger.LogInformation("Baixando o Chromium...");

            // Baixa o executável do Chrome.
            var revision = new BrowserFetcher()
            .DownloadAsync(BrowserFetcher.DefaultRevision).Result;

            if (!Directory.Exists(FILE_PATH))
                Directory.CreateDirectory(FILE_PATH);

            _logger.LogInformation("Removendo arquivos temporários antigos...");
            this.CleanDownloadDirectory();

            var browser = Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = revision.ExecutablePath,
                    Args = new string[] { "--no-sandbox" }
                })
            .Result;

            _logger.LogInformation("Acessando o painel do Governo Federal...");
            var page = ((browser.PagesAsync().Result)[0]);

            page.Client.SendAsync("Page.setDownloadBehavior", new
            {
                behavior = "allow",
                downloadPath = FILE_PATH,
            }).Wait();

            _logger.LogInformation("Realizando o download da base de dados..");
            page.GoToAsync("https://covid.saude.gov.br").Wait();
            page.ClickAsync("ion-button.btn-outline").Wait();

            page.WaitForTimeoutAsync(15000).Wait();

            browser.CloseAsync().Wait();

            _logger.LogInformation("Download concluído! Solicitando o processamento...");
        }

        private void CleanDownloadDirectory()
        {
            foreach (var file in Directory.EnumerateFiles(FILE_PATH))
            {
                File.Delete(file);
            }
        }
    }
}
