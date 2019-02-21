using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Configurations;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseProf> CourseProf { get; set; }
        public DbSet<Prof> Professors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                      
            modelBuilder.ApplyConfiguration(new CourseProfConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new ProfConfiguration());

        }
    }
}
