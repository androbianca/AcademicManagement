using BusinessLogic.Abstractions;
using BusinessLogic.Implementations;
using DataAccess.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Configurations
{
   public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddTransient<IUserLogic, UserLogic>();
            services.AddTransient<ICourseLogic, CourseLogic>();
            services.AddTransient<IStudentLogic, StudentLogic>();
            services.AddTransient<IGradeLogic, GradeLogic>();
            services.AddTransient<IGroupLogic, GroupLogic>();
            services.AddTransient<IProfLogic, ProfLogic>();
            services.AddTransient<INotificationLogic, NotificationLogic>();
            services.AddTransient<IPotentialUserLogic, PotentialUserLogic>();
            services.AddTransient<IProfStudLogic, ProfStudLogic>();
            services.AddTransient<IStudCourseLogic, StudCourseLogic>();
            services.AddTransient<IFeedbackLogic, FeedbackLogic>();
            services.AddTransient<IPostLogic, PostLogic>();
            services.AddTransient<IFileMetadataLogic, FileMetadataLogic>();
            services.AddTransient<IGradeCategoryLogic, GardeCategoryLogic>();
            services.AddTransient<IFinalGradeLogic, FinalGradeLogic>();




        }
    }
}
