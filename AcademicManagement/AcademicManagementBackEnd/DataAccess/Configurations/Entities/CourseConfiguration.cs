﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class CourseConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(p => p.Package)
                    .HasMaxLength(5);

            builder.Property(p => p.Year)
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(p => p.Semester)
                .IsRequired()
                .HasMaxLength(1);
        }
    }
}
