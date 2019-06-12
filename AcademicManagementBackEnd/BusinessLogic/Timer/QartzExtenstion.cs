using BusinessLogic.Abstractions;
using BusinessLogic.Implementations;
using BusinessLogic.TaskScheduler;
using DataAccess;
using DataAccess.Abstractions;
using DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Ninject;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System.Collections.Specialized;

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
           // scheduler.ScheduleJob(job, trigger);
            scheduler.Start();

        }

        static IKernel InitializeNinjectKernel()
        {
            var properties = new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "DefaultQuartzScheduler",
                ["quartz.scheduler.instanceId"] = "instance_one",
            //    ["quartz.serializer.type"] = "binary",
               // ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
             //   ["quartz.threadPool.threadCount"] = "10",
              //  ["quartz.threadPool.threadPriority"] = "1",
              //  ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
            //    ["quartz.jobStore.misfireThreshold"] = "60000",
             //   ["quartz.jobStore.dataSource"] = "default",
               // ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.StdAdoDelegate, Quartz",
               // ["quartz.jobStore.lockHandler.type"] = "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz",
              //  ["quartz.jobStore.tablePrefix"] = "QRTZ_",
                ["quartz.dataSource.default.connectionString"] = "Server=sqlexpress;Database=AcademicManagementDB;Trusted_Connection=True;",
                ["quartz.dataSource.default.provider"] = "SqlServer",
            //    ["quartz.jobStore.useProperties"] = "true"
            };


            //,
            //["quartz.dataSource.default.provider"] = "SqlServer",
            //["quartz.dataSource.default.connectionString"]  = "Data Source=.\\SQLEXPRESS;integrated security=true;Initial Catalog=AcademicManagementDB;MultipleActiveResultSets=True;Trusted_Connection=True"

            var kernel = new StandardKernel();

            // setup Quartz scheduler that uses our NinjectJobFactory
            kernel.Bind<IScheduler>().ToMethod(x =>
                    {
                        var schedulerFactory = new StdSchedulerFactory(properties);
                        var _scheduler = schedulerFactory.GetScheduler().Result;
                        var job = new NinjectJobFactory(kernel);

                        _scheduler.JobFactory = (IJobFactory)job;
                        return _scheduler;
                    });

            // add our bindings as we normally would (these are the bindings that our jobs require)
            kernel.Bind<IEmailLogic>().To<EmailLogic>();
            kernel.Bind<INotificationLogic>().To<NotificationLogic>();
            kernel.Bind<IFinalGradeLogic>().To<FinalGradeLogic>();

            kernel.Bind<IRepository>().To<Repository>();
            kernel.Bind<IAlertLogic>().To<AlertLogic>();
            kernel.Bind<IPotentialUserLogic>().To<PotentialUserLogic>();
            kernel.Bind<ApplicationDbContext>().ToSelf().InThreadScope();

            kernel.Bind<IHttpContextAccessor>().To<HttpContextAccessor>();

            kernel.Bind<IJob>().To<SendUserEmailsJob>();
            return kernel;
        }
    }
}
