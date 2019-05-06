using System;

namespace Entities
{
    public class ProfGroup
    {
        public Guid ProfId { get; set; }
        public  Guid GroupId { get; set; }
        public Professor Professor { get; set; }
        public Group Group { get; set; }

    }
}
