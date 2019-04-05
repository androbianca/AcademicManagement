using System.Collections.Generic;

namespace Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public string Package { get; set; }

        public IEnumerable<PUserOptionalCourse> PotentialUsers { get; set; }

      //  public IEnumerable<CourseProfessor> CourseProfessors { get; set; }
    }
}
