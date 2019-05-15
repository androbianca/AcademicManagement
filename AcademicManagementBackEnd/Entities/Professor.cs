using System;
using System.Collections.Generic;

namespace Entities
{
    public class Professor : BaseUser
    {
        public Guid PotentialUserId { get; set; }

        public PotentialUser PotentialUser { get; set; }

        public IEnumerable<Grade> Grades { get; set; }
    }
}
