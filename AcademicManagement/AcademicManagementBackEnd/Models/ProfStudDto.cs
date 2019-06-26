using System;

namespace Models
{
    public class ProfStudDto
    {
        public Guid Id { get; set; }
        public Guid ProfId { get; set; }
        public Guid CourseId { get; set; }
        public Guid GroupId { get; set; }
    }
}
