using System;

namespace Entities
{
    public class CourseFormula : BaseEntity
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public string Formula { get; set; }
    }
}
