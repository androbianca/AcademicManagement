using System;

namespace Models
{
    public class ProfDto
    {
        public Guid Id { get; set; }
        public Guid PotentialUserId { get; set; }
        public string UserCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
