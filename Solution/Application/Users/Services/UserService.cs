using Application.Common.Services;
using Domain.Entities;
using Domain.Event;

using Domain.Repositories;
using System;

namespace Application.Users.Services
{
    public class UserService : CrudService<User>, IUserService
    {
        public UserService(IRepository<User, Guid> userRepository, IDomainEvents domainEvents)
            : base(userRepository, domainEvents)
        {
        }
    }
}
