using System;

namespace Models
{
    public class CourseDto
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public string Package { get; set; }

    }
}
