using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.MappingConfigurations
{
    public class AuditLogEntryConfiguration : IEntityTypeConfiguration<AuditLogEntry>
    {
        public void Configure(EntityTypeBuilder<AuditLogEntry> builder)
        {
            builder.ToTable("AuditLogEntries");
            builder.Property(x => x.id).HasDefaultValueSql("newsequentialid()");
        }
    }
}
