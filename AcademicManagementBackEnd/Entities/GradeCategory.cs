using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class GradeCategory:BaseEntity
    {
        public string Name { get; set; }
        public bool isCourseCategory { get; set; }
        public int Percentage { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
