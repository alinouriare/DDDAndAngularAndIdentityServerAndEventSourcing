using Application.Common.Commands;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Roles.Commands
{
    public class DeleteRoleCommand : ICommand
    {
        public Role Role { get; set; }
    }

    internal class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Handle(DeleteRoleCommand command)
        {
            _roleRepository.Delete(command.Role);
            _roleRepository.UnitOfWork.SaveChanges();
        }
    }
}
