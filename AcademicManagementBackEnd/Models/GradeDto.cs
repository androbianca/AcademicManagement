using System;

namespace Models
{
    public class GradeDto
    {
        public float Value { get; set; }
        public string Category { get; set; }
        public Guid StudentId { get; set; }
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid ProfId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
