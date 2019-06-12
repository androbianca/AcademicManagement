using BusinessLogic.Abstractions;
using Quartz;
using System.Threading.Tasks;

namespace BusinessLogic.TaskScheduler
{
    public class SendUserEmailsJob : IJob
    {

        private IEmailLogic _emailLogic;
        private IAlertLogic _alertLogic;
        private IPotentialUserLogic _potentialUserLogic;

        public SendUserEmailsJob(IEmailLogic emailLogic, IAlertLogic alertLogic, IPotentialUserLogic potentialUserLogic)
        {
            _emailLogic = emailLogic;
            _alertLogic = alertLogic;
            _potentialUserLogic = potentialUserLogic;
        }

        public Task Execute(IJobExecutionContext context)
        {
            
            var emails = _potentialUserLogic.GetEmails().ToString();

           // foreach(var email in emails)
          //  {
           //     var a = email;
             _emailLogic.SendEmail("academic.management19@gmail.com", " note", " note");

          //  }

            return null;
        }


    }
}

