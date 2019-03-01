using System;

namespace Entities
{
    public class Account:BaseEntity
    {
        public Guid RegistrationId { get; set; }

        public Registration Registration { get; set; }

    }
}
