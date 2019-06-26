using System;
using System.Collections.Generic;

namespace Entities
{
    public class Account : BaseEntity
    {
        public string UserCode { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public Guid PotentialUserId { get; set; }

        public PotentialUser PotentialUser { get; set; }

        public IEnumerable<Notification> Notifications { get; set; }

        public IEnumerable<Post> Posts { get; set; }


    }
}
