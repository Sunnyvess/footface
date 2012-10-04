using System;
using System.Linq;

namespace SimpleCMS.Core.Repositories
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> Query { get; }

        TEntity Create();

        TEntity Find(int id);

        TEntity Add(TEntity entity);

        void Remove(TEntity entity);

        void Remove(int id);

        TEntity AttachAsModified(TEntity entity);
    }
}