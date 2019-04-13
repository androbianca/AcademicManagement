using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PotentialUserProfRole
    {
        public Guid RoleId { get; set; }

        public Guid PotentialUserId { get; set; }

        public ProfRole ProfRole { get; set; }

        public PotentialUser PotentialUser { get; set; }
    }
}
