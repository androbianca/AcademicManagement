using System;

namespace Entities
{
    public class Admin : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid PotentialUserId { get; set; }
        public PotentialUser PotentialUser { get; set; }
    }
}
