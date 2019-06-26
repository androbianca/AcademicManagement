using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class FileMetadataConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<FileMetadata>
    {
        public void Configure(EntityTypeBuilder<FileMetadata> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Path)
                .IsRequired();

            builder.Property(p => p.FileName)
                .IsRequired();

            builder.Property(p => p.CourseId)
                .IsRequired();
        }
    }
}
