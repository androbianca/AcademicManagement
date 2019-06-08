using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EmailDto
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Receiver { get; set; }
    }
}
