using Application.Common.Queries;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Roles.Queries
{
    public class GetRoleQuery : IQuery<Role>
    {
        public Guid Id { get; set; }
        public bool IncludeClaims { get; set; }
        public bool IncludeUserRoles { get; set; }
        public bool IncludeUsers { get; set; }
        public bool AsNoTracking { get; set; }
    }

    internal class GetRoleQueryHandler : IQueryHandler<GetRoleQuery, Role>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role Handle(GetRoleQuery query)
        {
            var db = _roleRepository.Get(new RoleQueryOptions
            {
                IncludeClaims = query.IncludeClaims,
                IncludeUserRoles = query.IncludeUserRoles,
                IncludeUsers = query.IncludeUsers,
                AsNoTracking = query.AsNoTracking,
            });

            return db.FirstOrDefault(x => x.id == query.Id);
        }
    }
}
