﻿using Application.Common.Commands;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Users.Commands
{
    public class DeleteRoleCommand : ICommand
    {
        public User User { get; set; }
        public UserRole Role { get; set; }
    }

    internal class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(DeleteRoleCommand command)
        {
            command.User.UserRoles.Remove(command.Role);
            _userRepository.AddOrUpdate(command.User);
            _userRepository.UnitOfWork.SaveChanges();
        }
    }
}
