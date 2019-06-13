using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using DataAccess.HubConfig;
using Entities;
using Microsoft.AspNetCore.SignalR;
using Models;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class AlertLogic : BaseLogic, IAlertLogic
    {
        private IHubContext<AlertServer> _hubContext;

        public AlertLogic(IRepository repository, IHubContext<AlertServer> hubContext)
            : base(repository)
        {
            _hubContext = hubContext;
        }


        public AlertDto GetAlert(string userCode)
        {
            var alertsDto = new List<AlertDto>();
            var alerts = _repository.GetAllByFilter<Alert>(x => x.UserCode == userCode);

            if(alerts.Count  == 0)
            {
                return null;
            }
            foreach (var alert in alerts)
            {
                var alertDto = new AlertDto
                {
                    Title = alert.Title,
                    Body = alert.Body
                };
                alertsDto.Add(alertDto);
                _repository.Delete(alert);
                _repository.Save();

            }


            return alertsDto[0];
        }

        public void AddAlert(Alert alert)
        {
            _repository.Insert(alert);
            _repository.Save();
            _hubContext.Clients.All.SendAsync("alert");


        }
    }
}
