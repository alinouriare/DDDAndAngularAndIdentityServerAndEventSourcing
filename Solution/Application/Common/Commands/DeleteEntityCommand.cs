using Application.Common.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Commands
{
   public class DeleteEntityCommand<TEntity>:ICommand where TEntity:AggregateRoot<Guid>
    {
        public TEntity Entity { get; set; }
    }

    internal class DeleteEntityCommandHandler<TEntity> : ICommandHandler<DeleteEntityCommand<TEntity>> where TEntity : AggregateRoot<Guid>
    {
        private readonly ICrudService<TEntity> _crudService;

        public DeleteEntityCommandHandler(ICrudService<TEntity> crudService)
        {
            _crudService = crudService;
        }
        public void Handle(DeleteEntityCommand<TEntity> command)
        {
            _crudService.Delete(command.Entity);
          }
    }
}
