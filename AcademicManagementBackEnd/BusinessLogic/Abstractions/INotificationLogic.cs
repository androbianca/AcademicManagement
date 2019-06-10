using System.Collections.Generic;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface INotificationLogic
    {
        List<NotificationDto> GetUserNotifications(string userId);
        Notification Create(NotificationDto notificationDto);
        void ReadNotification(NotificationDto notificationDto);
    }
}
