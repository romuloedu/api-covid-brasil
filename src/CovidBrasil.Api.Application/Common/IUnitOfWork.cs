using System;

namespace CovidBrasil.Api.Application.Common
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
