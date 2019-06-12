using Quartz;
using Quartz.Spi;
using System;


namespace BusinessLogic.Timer
{
    class NinjectJobFactory : IJobFactory
    {
        readonly IServiceProvider _kernel;

        public NinjectJobFactory(IServiceProvider kernel)
        {
            this._kernel = kernel;
        }

        public  IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
                    {
            try
            {
                // this will inject dependencies that the job requires
                return (IJob)this._kernel.GetService(bundle.JobDetail.JobType);
            }
            catch (Exception e)
            {
                throw new SchedulerException(string.Format("Problem while instantiating job '{0}' from the NinjectJobFactory.", bundle.JobDetail.Key), e);
            }
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}