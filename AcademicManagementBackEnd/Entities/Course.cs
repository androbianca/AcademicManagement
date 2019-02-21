using System.Collections.Generic;

namespace Entities
{
    public class Course : BaseEntity
    {
     
        public string CourseName { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public IEnumerable<CourseProf> Profs { get; set; }
    }
}
