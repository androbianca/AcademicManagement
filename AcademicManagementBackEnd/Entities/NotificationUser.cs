using System;

namespace Entities
{
    public class NotificationUser : BaseEntity
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
    }
}
