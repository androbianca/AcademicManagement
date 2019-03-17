using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Professor : BaseEntity
    {

        public string ProfessorCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CourseName { get; set; }

        public ICollection<CourseProfessor> Courses { get; set; }

    }
}
