using System;

namespace Entities
{
    public class Student : BaseEntity
    {
        public string StudentCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Guid PotentialUserId { get; set; }
        public PotentialUser PotentialUser { get; set; }
    }
}
