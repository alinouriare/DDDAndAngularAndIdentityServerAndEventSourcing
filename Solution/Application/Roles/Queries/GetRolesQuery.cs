using Application.Common.Queries;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Roles.Queries
{
    public class GetRolesQuery : IQuery<List<Role>>
    {
        public bool IncludeClaims { get; set; }
        public bool IncludeUserRoles { get; set; }
        public bool AsNoTracking { get; set; }
    }

    internal class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, List<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRolesQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Role> Handle(GetRolesQuery query)
        {
            var db = _roleRepository.Get(new RoleQueryOptions
            {
                IncludeClaims = query.IncludeClaims,
                IncludeUserRoles = query.IncludeUserRoles,
                AsNoTracking = query.AsNoTracking,
            });

            return db.ToList();
        }
    }
}
