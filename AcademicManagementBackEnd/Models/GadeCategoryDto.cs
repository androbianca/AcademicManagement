using System;

namespace Models
{
    public class GradeCategoryDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        //   public int Percentage { get; set; }
        public Guid CourseId { get; set; }
        //   public bool IsCourseCategory { get; set; }

    }
}
