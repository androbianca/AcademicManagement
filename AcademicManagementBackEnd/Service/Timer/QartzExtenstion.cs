using BusinessLogic.Abstractions;
using BusinessLogic.Implementations;
using BusinessLogic.TaskScheduler;
using DataAccess;
using DataAccess.Abstractions;
using DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace BusinessLogic.Timer
{
    public static class QartzExtenstion
    {
        public static void UseQuartz(this IApplicationBuilder app)
        {
            StartScheduler();
        }

        static void StartScheduler()
        {
            var kernel = InitializeNinjectKernel();
            var scheduler = kernel.Get<IScheduler>();
         

            IJobDetail job = JobBuilder.Create<SendUserEmailsJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

            // create trigger
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())
                .Build();

            // Schedule the job using the job and trigger 
            scheduler.ScheduleJob(job, trigger);
            scheduler.Start();

        }

        static IKernel InitializeNinjectKernel()
        {
            var kernel = new StandardKernel();

            // setup Quartz scheduler that uses our NinjectJobFactory
            kernel.Bind<IScheduler>().ToMethod(x =>
            {
                var sched = new StdSchedulerFactory().GetScheduler().Result;
                var job = new NinjectJobFactory(kernel);
                sched.JobFactory = (IJobFactory)job;
                return sched;
            });

            // add our bindings as we normally would (these are the bindings that our jobs require)
            kernel.Bind<IEmailLogic>().To<EmailLogic>();
            kernel.Bind<INotificationLogic>().To<NotificationLogic>();
            kernel.Bind<IFinalGradeLogic>().To<FinalGradeLogic>();

            kernel.Bind<IRepository>().To<Repository>();
            kernel.Bind<IAlertLogic>().To<AlertLogic>();
            kernel.Bind<IPotentialUserLogic>().To<PotentialUserLogic>();

            kernel.Bind<IHttpContextAccessor>().To<HttpContextAccessor>();    

            kernel.Bind<IJob>().To<SendUserEmailsJob>();
            return kernel;
        }
    }
}
