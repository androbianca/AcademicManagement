using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class BaseUser : BaseEntity
    {
        public string UserCode { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
