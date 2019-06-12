using System;

namespace Models
{
    public class PotentialUserDto 
    {
        public string UserCode { get; set; }

        public Guid RoleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
