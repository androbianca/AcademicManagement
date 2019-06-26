using System;

namespace Models
{
    public class NotificationDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; } = false;
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReciverId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime Time { get; set; }

    }
}
