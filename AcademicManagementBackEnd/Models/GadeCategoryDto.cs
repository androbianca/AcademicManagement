using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GradeCategoryDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public Guid CourseId { get; set; }
    }
}
