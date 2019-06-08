using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Email : BaseEntity
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Receiver { get; set; }
    }
}
