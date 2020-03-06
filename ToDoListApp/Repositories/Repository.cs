using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private bool disposed;

        protected DbContext DbContext { get; private set; }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return this.DbContext.Set<TEntity>();
            }
        }

        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.DbContext = context;
        }

        public virtual TEntity GetById(TKey id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            this.DbSet.Add(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            this.DbSet.Attach(entity);
            this.DbContext.Entry(entity).State = EntityState.Modified;
            this.DbContext.SaveChanges();
            return entity;
        }

        public virtual TEntity Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.DbContext != null)
                    {
                        this.DbContext.Dispose();
                    }
                }
                disposed = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}