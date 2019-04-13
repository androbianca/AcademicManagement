using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
   public class ProfRole : BaseEntity
    {
        public string Role { get; set; }
        public IEnumerable<PotentialUserProfRole> PotentialUsers { get; set; }
    }
}
