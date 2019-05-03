using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ProfDto
    {
        public Guid Id { get; set; }

        public IEnumerable<ProfCourse> Courses { get; set; }

        public IEnumerable<ProfRole> Roles { get; set; }

        public IEnumerable<ProfGroup> Groups { get; set; }
    }
}
