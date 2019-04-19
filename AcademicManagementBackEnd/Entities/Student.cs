using System;
using System.Collections.Generic;

namespace Entities
{
    public class Student : BaseUser
    {
        public Guid PotentialUserId { get; set; }

        public PotentialUser PotentialUser { get; set; }

        public Guid GroupId { get; set; }

        public Group Group { get; set; }

        public IEnumerable<StudCourse> Courses { get; set; }
    }
}
