using System;

namespace Models
{
    public class PostDto
    {
        public string Body { get; set; }
        public string UserCode { get; set; }
        public DateTime Time { get; set; }
        public string Role { get; set; }
    }
}
