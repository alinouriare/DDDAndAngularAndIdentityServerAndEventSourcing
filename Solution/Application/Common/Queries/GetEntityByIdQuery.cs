using CrossCuttingsConcerns.Exceptions;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.Queries
{
  public class GetEntityByIdQuery<TEntity>:IQuery<TEntity> where TEntity :AggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public bool ThrowNotFoundIfNull { get; set; }
    }

    internal class GetEntityByIdQueryHandler<TEntity> : IQueryHandler<GetEntityByIdQuery<TEntity>, TEntity> where TEntity : AggregateRoot<Guid>
    {
        private readonly IRepository<TEntity, Guid> _repository;

        public GetEntityByIdQueryHandler(IRepository<TEntity, Guid> repository)
        {
            _repository = repository;
        }
        public TEntity Handle(GetEntityByIdQuery<TEntity> query)
        {
            var entity = _repository.GetAll().FirstOrDefault(c => c.id == query.Id);
            if (query.ThrowNotFoundIfNull && entity ==null)
            {
                throw new NotFoundException($"Entity {query.Id} not found.");

            }
            return entity;
        }
    }
}
