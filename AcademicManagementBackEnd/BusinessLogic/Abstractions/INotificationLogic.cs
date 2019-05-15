using System;
using System.Collections.Generic;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface INotificationLogic
    {
        List<Notification> GetUserNotifications(string userId);
        Notification Create(NotificationDto notificationDto);
        void ReadNotification(Guid notificationId);
    }
}
