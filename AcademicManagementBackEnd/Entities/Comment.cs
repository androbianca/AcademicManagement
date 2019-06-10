using System;

namespace Entities
{
    public class Comment : BaseEntity
    {
        public Guid SenderId {get; set;}
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public string Body { get; set; }
        public DateTime Time { get; set; }

    }
}
