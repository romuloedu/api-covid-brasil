using System;
using CovidBrasil.Api.Application.Common;
using Microsoft.Extensions.Logging;

namespace CovidBrasil.Api.Application.Dataset
{
    public class PersistDataset
    {
         private readonly ILogger<PersistDataset> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatasetRepository _datasetRepository;
        private const string FILE_PATH = "./tmp";

        public PersistDataset(ILogger<PersistDataset> logger, 
            IUnitOfWork unitOfWork, IDatasetRepository datasetRepository)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _datasetRepository = datasetRepository;
        }

        public void Persist()
        {
            
        }
    }
}
