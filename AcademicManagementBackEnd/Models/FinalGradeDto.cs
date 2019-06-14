using System;

namespace Models
{
    public class FinalGradeDto
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public double Value { get; set; }
    }
}
