using System;
using CovidBrasil.Api.Application.Common;
using CovidBrasil.Api.Application.Dataset;
using Microsoft.Extensions.DependencyInjection;

namespace CovidBrasil.Api.IoC
{
    public static class BootstraperExtensions
    {
        public static void AddInjections(IServiceCollection services)
        {
            services.AddScoped<DownloadDataset>();
            services.AddScoped<PersistDataset>();

            services.AddScoped<IUnitOfWork>();
        }
    }
}