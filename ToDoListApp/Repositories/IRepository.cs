using System;
using System.Collections.Generic;
using ToDoListApp.Models;

namespace ToDoListApp.Repositories
{
    public interface IRepository<TEntity, TKey> : IDisposable
        where TEntity : IEntity<TKey>
    {
        TEntity Delete(TEntity entity);
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
    }
}