using System;

namespace Models
{
   public class UserDetailsDto
    {  
        public string UserCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Boolean isStudent { get; set; }     
    }
}
