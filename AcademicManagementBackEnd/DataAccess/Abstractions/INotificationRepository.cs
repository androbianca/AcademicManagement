using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace DataAccess.Abstractions
{
    public interface INotificationRepository
    {
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        void Create(Notification notification, int petId);
        void ReadNotification(int notificationId, string userId);
    }
}
