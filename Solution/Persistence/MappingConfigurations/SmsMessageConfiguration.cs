using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.MappingConfigurations
{
    public class SmsMessageConfiguration : IEntityTypeConfiguration<SmsMessage>
    {
        public void Configure(EntityTypeBuilder<SmsMessage> builder)
        {
            builder.ToTable("SmsMessages");
            builder.Property(x => x.id).HasDefaultValueSql("newsequentialid()");
        }
    }
}
