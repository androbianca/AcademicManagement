using System;

namespace Models
{
    public class UserDto
    {
        public string UserCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean IsStudent { get; set; }

    }
}
