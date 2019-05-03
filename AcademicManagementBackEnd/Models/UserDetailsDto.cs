using System;

namespace Models
{
   public class UserDetailsDto
    {
        public Guid Id { get; set; }
        public string UserCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserRole { get; set; }     
    }
}
