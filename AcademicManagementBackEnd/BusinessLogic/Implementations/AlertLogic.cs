using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class AlertLogic : BaseLogic, IAlertLogic
    {

        public AlertLogic(IRepository repository)
            : base(repository)
        { }


        public AlertDto GetAlert()
        {
            var alertsDto = new List<AlertDto>();
            var alerts = _repository.GetAll<Alert>();
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

        }
    }
}
