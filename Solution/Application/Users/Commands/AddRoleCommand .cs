using Application.Common.Commands;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Users.Commands
{
    public class AddRoleCommand : ICommand
    {
        public User User { get; set; }
        public UserRole Role { get; set; }
    }

    internal class AddRoleCommandHandler : ICommandHandler<AddRoleCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(AddRoleCommand command)
        {
            command.User.UserRoles.Add(command.Role);
            _userRepository.AddOrUpdate(command.User);
            _userRepository.UnitOfWork.SaveChanges();
        }
    }
}
