using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class StudentDto
    {
        public string UserCode { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Year { get; set; }

        public string Group { get; set; }

        public int Semester { get; set; }
    }
}
