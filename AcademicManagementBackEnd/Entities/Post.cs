using System;

namespace Entities
{
    public class Post : BaseEntity
    {
        public string Body { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime Time { get; set; }
    }
}
