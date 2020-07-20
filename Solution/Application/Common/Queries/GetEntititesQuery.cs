using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.Queries
{
    public class GetEntititesQuery<TEntity> : IQuery<List<TEntity>>
            where TEntity : AggregateRoot<Guid>
    {
    }

    internal class GetEntititesQueryHandler<TEntity> : IQueryHandler<GetEntititesQuery<TEntity>, List<TEntity>>
    where TEntity : AggregateRoot<Guid>
    {
        private readonly IRepository<TEntity, Guid> _repository;

        public GetEntititesQueryHandler(IRepository<TEntity, Guid> repository)
        {
            _repository = repository;
        }

        public List<TEntity> Handle(GetEntititesQuery<TEntity> query)
        {
            return _repository.GetAll().ToList();
        }
    }
}
