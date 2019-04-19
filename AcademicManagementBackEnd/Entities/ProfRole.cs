using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProfRole
    {
        public Guid ProfId { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Professor Professor { get; set; }
    }
}
