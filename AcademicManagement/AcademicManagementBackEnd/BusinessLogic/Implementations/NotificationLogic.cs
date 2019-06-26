using System;
using System.Collections.Generic;
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
        private IHubContext<NotificationsServer> _hubContext;

        public NotificationLogic(IRepository repository, IHubContext<NotificationsServer> hubContext)
            : base(repository)
        {
            _hubContext = hubContext;
        }

        public Notification Create(NotificationDto notificationDto)
        {

            Guid accountReciverId = Guid.Empty;
            Guid accountSenderId = Guid.Empty;

            if (notificationDto.SenderId != Guid.Empty)
            {
                var accountSender = _repository.GetByFilter<Account>(x => x.PotentialUserId == notificationDto.SenderId);
                    if (accountSender == null)
                {
                    return null;
                }
                accountSenderId = accountSender.Id;

            }
            if (notificationDto.ReciverId != Guid.Empty)
            {

                var accountReciver = _repository.GetByFilter<Account>(x => x.PotentialUserId == notificationDto.ReciverId);
                if (accountReciver == null)
                {
                    return null;
                }
                accountReciverId = accountReciver.Id;
            }


            var notification = new Notification
            {
                Body = notificationDto.Body,
                Title = notificationDto.Title,
                IsRead = notificationDto.IsRead,
                Id = Guid.NewGuid(),
                SenderId = accountSenderId,
                ReciverId = accountReciverId,
                ItemId = notificationDto.ItemId,
                Time = DateTime.Now
            };

            _repository.Insert(notification);
            _repository.Save();

            _hubContext.Clients.All.SendAsync("notification");


            return notification;

        }

        public List<NotificationDto> GetUserNotifications(string userId)
        {
            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == userId);


            var role = _repository.GetByFilter<UserRole>(x => x.Id == potentialUser.UserRoleId);

            if (role.Name != "Admin")
            {
                var account = _repository.GetByFilter<Account>(x => x.PotentialUserId == potentialUser.Id);
                ; var notifications = _repository.GetAllByFilter<Notification>(x => x.ReciverId == account.Id || x.ReciverId == Guid.Empty);
                var notificationDtos = new List<NotificationDto>();
                foreach (var notification in notifications)
                {
                    if (notification.SenderId != account.Id)
                    {

                        var notificationDto = new NotificationDto
                        {

                            Title = notification.Title,
                            Body = notification.Body,
                            IsRead = notification.IsRead,
                            ItemId = notification.ItemId,
                            Id = notification.Id,
                            Time = notification.Time

                        };

                        notificationDtos.Add(notificationDto);
                    }
                }

                return notificationDtos;
            }

            return null;
        }

        public Notification ReadNotification(NotificationDto notificationDto)
        {
            var notification = _repository.GetByFilter<Notification>(x => x.Id == notificationDto.Id);

            if (notification == null)
            {
                return null;
            }
            notification.IsRead = true;
            _repository.Update(notification);
            _repository.Save();

            return notification;
        }

    }
}
