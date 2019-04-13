using System;

namespace Entities
{
    public class PotentialUserCourse
    {
        public Guid CourseId { get; set; }

        public Guid PotentialUserId { get; set; }

        public Course Course { get; set; }

        public PotentialUser PotentialUser { get; set; }

    }
}
