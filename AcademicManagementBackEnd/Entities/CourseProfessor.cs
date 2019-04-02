using System;

namespace Entities
{
    public class CourseProfessor : BaseEntity
    {
        public Guid CourseId { get; set; }

        public Guid ProfessorId { get; set; }

        public Course Course { get; set; }

        public Professor Professor { get; set; }
    }
}
