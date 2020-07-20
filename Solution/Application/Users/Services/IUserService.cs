using Application.Common.Services;
using Domain.Entities;

namespace Application.Users.Services
{
    public interface IUserService : ICrudService<User>
    {
    }
}
