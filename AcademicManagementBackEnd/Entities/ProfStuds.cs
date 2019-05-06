using System;

namespace Entities
{
   public class ProfStuds : BaseEntity
    {
        public Guid ProfId { get; set; }
        public Guid CourseId { get; set; }
        public Guid GroupId { get; set; }
    }
}
