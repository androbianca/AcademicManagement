using System;

namespace Entities
{
    public class OptionalPotentialUser
    {
        public Guid OptionalId { get; set; }
        public Guid PotentialUserId { get; set; }
        public Optional Optional { get; set; }
        public PotentialUser PotentialUser { get; set; }

    }
}
