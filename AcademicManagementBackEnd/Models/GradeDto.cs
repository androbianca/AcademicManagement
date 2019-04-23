using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GradeDto
    {
        public float Value { get; set; }
        public string Category { get; set; }
        public Guid StudentId { get; set; }

        public Guid CourseId { get; set; }

        public Guid ProfId { get; set; }
    }
}
