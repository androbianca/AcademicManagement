using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CourseProfessor
    {
        public Guid CourseId { get; set; }

        public Guid ProfessorId { get; set; }

        public Course Course { get; set; }

        public Professor Professor { get; set; }
    }
}
