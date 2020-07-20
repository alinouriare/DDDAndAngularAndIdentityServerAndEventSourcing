using Application.AuditLogEntries.DTOs;
using Application.Common.Queries;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.AuditLogEntries.Queries
{
    public class GetAuditEntriesQuery : AuditLogEntryQueryOptions, IQuery<List<AuditLogEntryDTO>>
    {
    }

    internal class GetAuditEntriesQueryHandler : IQueryHandler<GetAuditEntriesQuery, List<AuditLogEntryDTO>>
    {
        private readonly IAuditLogEntryRepository _auditLogEntryRepository;
        private readonly IUserRepository _userRepository;

        public GetAuditEntriesQueryHandler(IAuditLogEntryRepository auditLogEntryRepository, IUserRepository userRepository)
        {
            _auditLogEntryRepository = auditLogEntryRepository;
            _userRepository = userRepository;
        }

        public List<AuditLogEntryDTO> Handle(GetAuditEntriesQuery query)
        {
            var auditLogs = _auditLogEntryRepository.Get(query);
            var users = _userRepository.GetAll();

            var rs = auditLogs.Join(users, x => x.UserId, y => y.id,
                (x, y) => new AuditLogEntryDTO
                {
                    UserId = x.UserId,
                    Action = x.Action,
                    ObjectId = x.ObjectId,
                    Log = x.Log,
                    CreatedDateTime = x.CreatedDateTime,
                    UserName = y.UserName,
                });

            return rs.OrderByDescending(x => x.CreatedDateTime).ToList();
        }
    }
}
