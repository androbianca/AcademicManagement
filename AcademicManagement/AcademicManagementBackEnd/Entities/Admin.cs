using System;

namespace Entities
{
    public class Admin : BaseUser
    {
        public Guid PotentialUserId { get; set; }
        public PotentialUser PotentialUser { get; set; }
    }
}
