using System;

namespace Entities
{
    public class Student : BaseUser
    {

        public Guid PotentialUserId { get; set; }

        public PotentialUser PotentialUser { get; set; }
    }
}
