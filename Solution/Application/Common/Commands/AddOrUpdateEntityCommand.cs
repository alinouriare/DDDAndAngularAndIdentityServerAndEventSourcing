using Application.Common.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Commands
{
   public class AddOrUpdateEntityCommand<TEntity>:ICommand where TEntity :AggregateRoot<Guid>
    {
        public AddOrUpdateEntityCommand(TEntity entity)
        {
            Entity = entity;
        }
        public TEntity Entity  { get; set; }
    }

    internal class AddOrUpdateEntityCommandHandler<TEntity> : ICommandHandler<AddOrUpdateEntityCommand<TEntity>> where TEntity : AggregateRoot<Guid>
    {
        private readonly ICrudService<TEntity> _crudService;

        public AddOrUpdateEntityCommandHandler(ICrudService<TEntity> crudService)
        {
            _crudService = crudService;
        }

        public void Handle(AddOrUpdateEntityCommand<TEntity> command)
        {
            _crudService.AddOrUpdate(command.Entity);
        }
    }
}
