//using System;
//using System.Collections.Generic;
//using System.Text;
//using Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace DataAccess.Configurations.Entities
//{
//    public class CourseProfessorConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<CourseProfessor>
//    {
//        public void Configure(EntityTypeBuilder<CourseProfessor> builder)
//        {
//            builder.HasKey(x => new { x.CourseId, x.ProfessorId });

//            builder.HasOne(x => x.Course)
//                .WithMany(y => y.CourseProfessors)
//                .HasForeignKey(y => y.CourseId);

//            builder.HasOne(x => x.Professor)
//                .WithMany(y => y.CourseProfessors)
//                .HasForeignKey(y => y.ProfessorId);
//        }
//    }
//}
