using System;
using CovidBrasil.Api.Domain.Common;
using System.Collections.Generic;

namespace CovidBrasil.Api.Application.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void DeleteAll();
    }
}
