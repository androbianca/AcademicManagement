using System;

namespace Entities
{
    public class PUserOptionalCourse
    {
        public Guid OptionalCourseId { get; set; }

        public Guid PotentialUserId { get; set; }

        public Course OptionalCourse { get; set; }

        public PotentialUser PotentialUser { get; set; }

    }
}
