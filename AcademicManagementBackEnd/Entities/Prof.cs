using System.Collections.Generic;

namespace Entities
{
    public class Prof : BaseEntity
    {
     
        public string ProfName { get; set; }

        public string CourseName { get; set; }

        public ICollection<CourseProf> Courses { get; set; }

    }
}
