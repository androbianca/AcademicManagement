using System;

namespace Entities
{
    public class Student : BaseUser
    {

        public string Email { get; set; }

        public Guid PotentialUserId { get; set; }

        public PotentialUser PotentialUser { get; set; }
    }
}
