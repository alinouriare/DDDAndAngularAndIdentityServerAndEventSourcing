using Application.Common.Commands;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Roles.Commands
{
    public class AddUpdateRoleCommand : ICommand
    {
        public Role Role { get; set; }
    }

    internal class AddUpdateRoleCommandHandler : ICommandHandler<AddUpdateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public AddUpdateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Handle(AddUpdateRoleCommand command)
        {
            _roleRepository.AddOrUpdate(command.Role);
            _roleRepository.UnitOfWork.SaveChanges();
        }
    }
}
