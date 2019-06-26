using System;

namespace Models
{
    public class CourseFormulaDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Formula { get; set; }
    }
}
