using System;

namespace Models
{
    public class CommentDto
    {
        public string UserCode { get; set; }
        public Guid PostId { get; set; }
        public string Body { get; set; }
        public DateTime Time { get; set; }
    }
}
