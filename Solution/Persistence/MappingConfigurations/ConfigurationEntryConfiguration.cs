using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.MappingConfigurations
{
    public class ConfigurationEntryConfiguration : IEntityTypeConfiguration<ConfigurationEntry>
    {
        public void Configure(EntityTypeBuilder<ConfigurationEntry> builder)
        {
            builder.ToTable("ConfigurationEntries");
            builder.Property(x => x.id).HasDefaultValueSql("newsequentialid()");
        }
    }
}