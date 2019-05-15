using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Feedback : BaseEntity
    {
        public string Body { get; set; }
        public Guid ReciverId { get; set; }
        public Professor Professor { get; set; }
        public Guid? SenderId { get; set; }
        public Student Student { get; set; }

    }
}
