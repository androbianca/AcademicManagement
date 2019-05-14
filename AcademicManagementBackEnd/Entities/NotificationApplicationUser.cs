using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class NotificationApplicationUser
    {
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string ApplicationUserId { get; set; }
        public Guid studentId { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
