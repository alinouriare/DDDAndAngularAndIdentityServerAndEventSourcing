using AutoMapper;
using Domain.Entities;

namespace WebAPI.Models.Roles
{
    public class RoleModelMappingConfiguration : Profile
    {
        public RoleModelMappingConfiguration()
        {
            CreateMap<Role, RoleModel>();
        }
    }
}
