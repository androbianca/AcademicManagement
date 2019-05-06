using System;

namespace Entities
{
    public class PotentialUser : BaseEntity
    {
        public string UserCode { get; set; }

        public Guid UserRoleId { get; set; }

        public Student Student { get; set; }

        public Professor Professor { get; set; }

        public Admin Admin { get; set; }

        public Account Account { get; set; }

    }
}
