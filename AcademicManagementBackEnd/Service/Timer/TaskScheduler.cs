using BusinessLogic.Abstractions;
using Entities;
using Microsoft.AspNetCore.SignalR;
using Quartz;
using System.Threading.Tasks;

namespace BusinessLogic.TaskScheduler
{


    public class SendUserEmailsJob : IJob
    {

        private IEmailLogic _emailLogic;
        private IAlertLogic _alertLogic;
        private IPotentialUserLogic _potentialUserLogic;


        public SendUserEmailsJob( IEmailLogic emailLogic, IAlertLogic alertLogic, IPotentialUserLogic potentialUserLogic)
        {
            _emailLogic = emailLogic;
            _alertLogic = alertLogic;
            _potentialUserLogic = potentialUserLogic;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var emails = _potentialUserLogic.GetEmails();

            foreach(var email in emails)
            {
                _emailLogic.SendEmail(email, "Pune note", "Pune note");

            }

            return null;
        }


    }
}

