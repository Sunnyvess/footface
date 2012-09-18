using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace FootFace.Core.Repositories.Implementation
{
    public class RepositoryBase<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        protected TDbContext DbContext { get; private set; }

        protected Func<TDbContext, DbSet<TEntity>> EntitySetSelector { get; set; }

        protected static TDbContext CreateDbContext()
        {
            return (TDbContext)Activator.CreateInstance(typeof(TDbContext));
        }

        protected void Initialize(Func<TDbContext, DbSet<TEntity>> entitySetSelector)
        {
            if (entitySetSelector == null)
            {
                throw new ArgumentNullException("entitySetSelector");
            }

            this.EntitySetSelector = entitySetSelector;
            this.DbContext = RepositoryBase<TDbContext, TEntity>.CreateDbContext();
        }

        #region Implementation of IRepository<TEntity>

        public virtual IQueryable<TEntity> Query
        {
            get { return this.EntitySetSelector(this.DbContext); }
        }

        public virtual TEntity Create()
        {
            return (TEntity)Activator.CreateInstance(typeof(TEntity));
        }

        public virtual TEntity Find(int id)
        {
            return this.EntitySetSelector(this.DbContext).Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            TEntity result;
            using (var dbContext = RepositoryBase<TDbContext, TEntity>.CreateDbContext())
            {
                result = this.EntitySetSelector(dbContext).Add(entity);
                dbContext.SaveChanges();
            }

            return result;
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using (var dbContext = RepositoryBase<TDbContext, TEntity>.CreateDbContext())
            {
                this.EntitySetSelector(dbContext).Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            var entity = this.Find(id);
            this.Remove(entity);
        }

        public virtual TEntity AttachAsModified(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            TEntity result;
            using (var dbContext = RepositoryBase<TDbContext, TEntity>.CreateDbContext())
            {
                var entry = dbContext.Entry(entity);
                entry.State = EntityState.Modified;
                result = entry.Entity;

                dbContext.SaveChanges();
            }

            return result;
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            this.DbContext.Dispose();
        }

        #endregion
    }
}
