using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity:AggregateRoot<TKey>
    {

        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntity> GetAll();

        void AddOrUpdate(TEntity entity);

        void Delete(TEntity entity);
    }
}
