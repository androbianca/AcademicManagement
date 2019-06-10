using DataAccess.Configurations;
using DataAccess.Configurations.Entities;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<PotentialUser> PotentialUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudCourse> StudCourse { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ProfRole> ProfRole { get; set; }
        public DbSet<ProfStuds> ProfStuds { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Feedback> Feedback {get; set;}
        public DbSet<Post> Posts { get; set; }
        public DbSet<FileMetadata> Files { get; set; }
        public DbSet<GradeCategory> GradeCategories { get; set; }
        public DbSet<FinalGrade> FinalGrades { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Optional> Optionals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PotentialUserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudCourseConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguraton());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ProfRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProfStudsConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new FileMetadataConfiguration());
            modelBuilder.ApplyConfiguration(new GradeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FinalGradeConfiguration());
            modelBuilder.ApplyConfiguration(new EmailConfiguration());


        }
    }
}
