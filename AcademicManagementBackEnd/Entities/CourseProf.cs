using System;
using System.Collections.Generic;

namespace Entities
{
    public class CourseProf
    {
        public Guid CourseId { get; set; }

        public Guid ProfId { get; set; }

        public Course Course { get; set; }

        public Prof Prof { get; set; }

    }
}
