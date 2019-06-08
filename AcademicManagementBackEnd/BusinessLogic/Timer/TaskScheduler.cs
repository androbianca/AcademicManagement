using BusinessLogic.Abstractions;
using BusinessLogic.HubConfig;
using Entities;
using Microsoft.AspNetCore.SignalR;
using Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BusinessLogic.TaskScheduler
{


    public class SendUserEmailsJob : IJob
    {

        private IEmailLogic _emailLogic;
        private IAlertLogic _alertLogic;
  

        public SendUserEmailsJob( IEmailLogic emailLogic, IAlertLogic alertLogic)
        {
            _emailLogic = emailLogic;
            _alertLogic = alertLogic;
        }

        public Task Execute(IJobExecutionContext context)
        {
            // _emailLogic.SendEmail("andrada9805@gmail.com", "Pune note", "Pune note");

            //var alert = new Alert
            //{
            //    Title = "Note",
            //    Body = "Adauga notele"
            //};

           // _alertLogic.AddAlert(alert);

            return null;
        }


    }
}

