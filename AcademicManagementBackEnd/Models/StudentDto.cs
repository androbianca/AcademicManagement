using System;

namespace Models
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Year { get; set; }

        public string Group { get; set; }

 
    }
}
