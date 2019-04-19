using System;

namespace Entities
{
    public class ProfCourse
    {
        public Guid CourseId { get; set; }

        public Guid ProfId { get; set; }

        public Course Course { get; set; }

        public Professor Professor { get; set; }

    }
}
