using System;

namespace Entities
{
    public class GradeCategory : BaseEntity
    {
        public string Name { get; set; }
        //  public bool IsCourseCategory { get; set; }
        //  public int Percentage { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
