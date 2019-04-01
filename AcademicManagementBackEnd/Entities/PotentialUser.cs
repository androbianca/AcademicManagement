using System.Collections.Generic;

namespace Entities
{
    public class PotentialUser : BaseEntity
    {
        public string UserCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Year { get; set; }
        public string Group { get; set; }
        public int Semester { get; set; }
        public string Photo { get; set; }
        public Student Student { get; set; }
        public IEnumerable<OptionalPotentialUser> Optionals { get; set; }
    }
}
