using System;

namespace Models
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Year { get; set; }

        public bool IsDeleted { get; set; }

        public Guid GroupId { get; set; }

        public Guid PotentialUserId { get; set; }


    }
}
