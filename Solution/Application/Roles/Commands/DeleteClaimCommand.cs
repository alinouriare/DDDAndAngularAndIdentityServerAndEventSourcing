using Application.Common.Commands;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Roles.Commands
{
    public class DeleteClaimCommand : ICommand
    {
        public Role Role { get; set; }
        public RoleClaim Claim { get; set; }
    }

    internal class DeleteClaimCommandHandler : ICommandHandler<DeleteClaimCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteClaimCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Handle(DeleteClaimCommand command)
        {
            command.Role.Claims.Remove(command.Claim);
            _roleRepository.UnitOfWork.SaveChanges();
        }
    }
}
