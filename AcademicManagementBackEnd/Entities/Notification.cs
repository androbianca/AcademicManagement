using System;
using System.Collections.Generic;

namespace Entities
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; } = false;
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

    }
}
