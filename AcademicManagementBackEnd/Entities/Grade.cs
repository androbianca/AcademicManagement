using System;

namespace Entities
{
    public class Grade : BaseEntity
    {
        public float Value { get; set; }

        public string Category { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public Guid ProfId { get; set; }

        public Professor Professor { get; set; }
    }
}
