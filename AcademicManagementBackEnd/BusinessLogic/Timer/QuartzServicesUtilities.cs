using Quartz;

namespace BusinessLogic.Timer
{
    public static class QuartzServicesUtilities
    {
        public static void StartJob<TJob>(IScheduler scheduler)
            where TJob : IJob
        {
            var jobName = typeof(TJob).FullName;

            var job = JobBuilder.Create<TJob>()
                .WithIdentity(jobName)
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{jobName}.trigger")
                .StartNow()
                .WithSimpleSchedule(scheduleBuilder =>
                    scheduleBuilder
                        .WithIntervalInSeconds(30)
                        .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}