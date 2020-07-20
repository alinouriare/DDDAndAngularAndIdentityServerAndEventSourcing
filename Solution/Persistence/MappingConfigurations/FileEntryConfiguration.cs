using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.MappingConfigurations
{
    public class FileEntryConfiguration : IEntityTypeConfiguration<FileEntry>
    {
        public void Configure(EntityTypeBuilder<FileEntry> builder)
        {
            builder.ToTable("FileEntries");
            builder.Property(x => x.id).HasDefaultValueSql("newsequentialid()");
        }
    }
}