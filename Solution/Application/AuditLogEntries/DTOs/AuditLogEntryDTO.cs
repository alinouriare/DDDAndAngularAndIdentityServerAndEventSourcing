using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AuditLogEntries.DTOs
{
    public class AuditLogEntryDTO
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Action { get; set; }

        public string ObjectId { get; set; }

        public string Log { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
