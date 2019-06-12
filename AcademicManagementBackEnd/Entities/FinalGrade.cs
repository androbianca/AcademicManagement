using System;

namespace Entities
{
    public class FinalGrade : BaseEntity
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public double Value { get; set; }
    }
}
