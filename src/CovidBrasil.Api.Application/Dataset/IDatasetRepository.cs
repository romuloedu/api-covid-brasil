using System;
using CovidBrasil.Api.Application.Common;
using CovidBrasil.Api.Domain.Dataset;

namespace CovidBrasil.Api.Application.Dataset
{
    public interface IDatasetRepository : IRepository<Domain.Dataset.Dataset>
    {
        bool HasRegister(string region, string state, 
            DateTime ocurrenceDate);
    }
}
