using System;

namespace Entities
{
    public class Professor : BaseUser
    {

        public Guid PotentialUserId { get; set; }

        public PotentialUser PotentialUser { get; set; }

    }
}
