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
                AccountId = account.Id
            };

            _repository.Insert(notification);
            _repository.Save();

            _repository.Save();
            _hubContext.Clients.All.SendAsync("ceva", "");

            return notification;

        }

        public List<NotificationDto> GetUserNotifications(string userId)
        {
            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == userId);
            var account = _repository.GetByFilter<Account>(x => x.PotentialUserId == potentialUser.Id);
            var notifications = _repository.GetAllByFilter<Notification>(x => x.AccountId == account.Id);
            var notificationDtos = new List<NotificationDto>();
            foreach(var notification in notifications)
            {
                var notificationDto = new NotificationDto
                {
                    Title = notification.Title,
                    Body = notification.Body,
                    IsRead = notification.IsRead,

                };

                notificationDtos.Add(notificationDto);
            }

            return notificationDtos;
        }

        public void ReadNotification(Guid notificationId)
        {
            var notification = _repository.GetByFilter<Notification>(x => x.Id == notificationId);
            notification.IsRead = true;
            _repository.Update(notification);
        }

    }
}
