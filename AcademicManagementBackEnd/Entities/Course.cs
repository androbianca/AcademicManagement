using System.Collections.Generic;

namespace Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public string Package { get; set; }

        public IEnumerable<ProfCourse> Profs { get; set; }

        public IEnumerable<StudCourse> Studs { get; set; }

        public IEnumerable<Grade> Grades { get; set; } 

    }
}
