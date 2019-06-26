using System;

namespace Models
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public string UserCode { get; set; }
        public DateTime Time { get; set; }

    }
}
