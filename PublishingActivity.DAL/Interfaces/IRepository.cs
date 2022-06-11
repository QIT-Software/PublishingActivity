using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PublishingActivity.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null);
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}