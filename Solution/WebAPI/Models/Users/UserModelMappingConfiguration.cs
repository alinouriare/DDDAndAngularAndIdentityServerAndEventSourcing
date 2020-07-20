using AutoMapper;
using Domain.Entities;

namespace WebAPI.Models.Users
{
    public class UserModelMappingConfiguration : Profile
    {
        public UserModelMappingConfiguration()
        {
            CreateMap<User, UserModel>();
        }

    }
}
