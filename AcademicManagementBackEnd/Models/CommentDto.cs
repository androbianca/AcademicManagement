using System;

namespace Models
{
    public class CommentDto
    {
        public Guid SenderId { get; set; }
        public Guid PostId { get; set; }
        public string Body { get; set; }
        public DateTime Time { get; set; }
    }
}
