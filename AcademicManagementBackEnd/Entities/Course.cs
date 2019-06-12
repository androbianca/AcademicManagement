using System.Collections.Generic;

namespace Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public string Package { get; set; }

        public bool isDeleted { get; set; }

        public CourseFormula CourseFormula { get; set; }

        public IEnumerable<StudCourse> Studs { get; set; }

        public IEnumerable<Grade> Grades { get; set; }

        public IEnumerable<Feedback> Feedback { get; set; }

        public IEnumerable<GradeCategory> Categories { get; set; }


    }
}
