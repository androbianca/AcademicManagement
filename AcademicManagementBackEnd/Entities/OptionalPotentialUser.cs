using System;

namespace Entities
{
    public class OptionalPotentialUser : BaseEntity
    {
        public Guid OptionalId { get; set; }
        public Guid PotentialUserId { get; set; }
        public Optional Optional { get; set; }
        public PotentialUser PotentialUser { get; set; }

    }
}
