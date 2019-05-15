using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Abstractions;
using BusinessLogic.HubConfig;
using DataAccess.Abstractions;
using Entities;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace BusinessLogic.Implementations
{
    public class NotificationLogic : BaseLogic, INotificationLogic
    {
        private IHubContext<SignalServer> _hubContext;
        public NotificationLogic(IRepository repository, IHubContext<SignalServer> hubContext)
            : base(repository)
        { _hubContext = hubContext; }

        public Notification Create(NotificationDto notificationDto)
        {
            var account = _repository.GetByFilter<Account>(x => x.PotentialUserId == notificationDto.UserId);

            var notification = new Notification
            {
                Body = notificationDto.Body,
                Title = notificationDto.Title,
                IsRead = notificationDto.IsRead,
                Id = Guid.NewGuid(),
                UserId = account.Id
            };

            _repository.Insert(notification);
            _repository.Save();

            var userNotification = new NotificationUser
            {
                UserId = notification.UserId,
                NotificationId = notification.Id
            };

            _repository.Insert(userNotification);
            _repository.Save();
            _hubContext.Clients.All.SendAsync("ceva", "");


            return notification;

        }

        public List<Notification> GetUserNotifications(string userId)
        {
            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == userId);
            var account = _repository.GetByFilter<Account>(x => x.PotentialUserId == potentialUser.Id);
            var notificationApplicationUsers = _repository.GetAllByFilter<NotificationUser>(x => x.UserId == account.Id);
            var notifications = new List<Notification>();
            foreach(var notificationApplicationUser in notificationApplicationUsers)
            {
                var notification = _repository.GetByFilter<Notification>(x => x.Id == notificationApplicationUser.NotificationId);
                notifications.Add(notification);
            }

            return notifications;
        }

        public void ReadNotification(Guid notificationId)
        {
            var notification = _repository.GetByFilter<Notification>(x => x.Id == notificationId);
            notification.IsRead = true;
            _repository.Update(notification);
        }

    }
}
