using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Abstractions;
using BusinessLogic.HubConfig;
using DataAccess.Abstractions;
using Entities;
using Microsoft.AspNetCore.SignalR;

namespace BusinessLogic.Implementations
{
    public class NotificationLogic : BaseLogic, INotificationLogic
    {
        private IHubContext<SignalServer> _hubContext;
        public NotificationLogic(IRepository repository, IHubContext<SignalServer> hubContext)
            : base(repository)
        { _hubContext = hubContext; }

        public void Create(Notification notification, int gradeId)
        {
            _repository.Insert(notification);
            _repository.Save();
        }

        public List<NotificationApplicationUser> GetUserNotifications(string userId)
        {
            _repository.GetAllByFilter<>()
        }

        public void ReadNotification(int notificationId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
