using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CourseProfConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<CourseProf>
    {
        public void Configure(EntityTypeBuilder<CourseProf> builder)
        {
           builder.HasKey(x => new { x.CourseId, x.ProfId });

            builder.HasOne(x => x.Course)
                .WithMany(y => y.Profs)
                .HasForeignKey(y => y.ProfId);

            builder.HasOne(x => x.Prof)
                .WithMany(y => y.Courses)
                .HasForeignKey(y => y.CourseId);

        }
    }
}
