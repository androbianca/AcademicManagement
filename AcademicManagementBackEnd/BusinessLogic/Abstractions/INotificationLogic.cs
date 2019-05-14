using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace BusinessLogic.Abstractions
{
    public interface INotificationLogic
    {
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        void Create(Notification notification, int petId);
        void ReadNotification(int notificationId, string userId);
    }
}
