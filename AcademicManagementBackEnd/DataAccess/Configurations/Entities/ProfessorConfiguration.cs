using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class ProfessorConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Professor>
    {
        public new void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(p => p.ProfessorCode)
                .IsRequired();
      
            builder.Property(p => p.CourseName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(40);


        }
    }
}
