using System;
using System.Collections.Generic;

namespace QualityMeter.Core.Interfaces.Service
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> GetAll(string sort
            , int pag, int pageSize);
        T GetById(Guid id);
        T Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
