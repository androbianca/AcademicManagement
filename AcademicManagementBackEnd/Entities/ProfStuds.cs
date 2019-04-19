using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
   public class ProfStuds : BaseEntity
    {
        public Guid ProfId { get; set; }
        public Guid CourseId { get; set; }
        public Guid GroupId { get; set; }
    }
}
