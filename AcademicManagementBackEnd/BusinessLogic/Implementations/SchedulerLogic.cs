using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using DataAccess.HubConfig;
using Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class SchedulerLogic : BaseLogic, ISchedulerLogic
    {
        private IEmailLogic _emailLogic;
        private IAlertLogic _alertLogic;
        IHubContext<AlertServer> _hubContext;

        public SchedulerLogic(IRepository repository, IEmailLogic emailLogic, IAlertLogic alertLogic, IHubContext<AlertServer> hubContext)
            : base(repository)
        {
            _emailLogic = emailLogic;
            _alertLogic = alertLogic;
            _hubContext = hubContext;

        }


        public void SendAlert(string id)
        {

            var send = true;
            var profs = _repository.GetAll<Professor>();

            foreach (var prof in profs)
            {
                var grades = _repository.GetAllByFilter<Grade>(x => x.ProfId == prof.Id);

                foreach (var grade in grades)
                {
                    if (DateTime.Now < grade.Date.AddDays(7))
                    {
                        send = false;
                    }
                }

                if (send)
                {
                    var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.Id == prof.PotentialUserId);

                    _emailLogic.SendEmail(potentialUser.Email, "Note", "Note");

                    AddAlert(potentialUser.UserCode);
                }
            }

        }

        private void AddAlert(string userCode)
        {
            var alert = new Alert
            {
                Title = "Note",
                Body = "Note",
                UserCode = userCode
            };

            _alertLogic.AddAlert(alert);

        }
    }
}
