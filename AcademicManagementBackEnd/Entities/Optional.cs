using System.Collections.Generic;

namespace Entities
{
    public class Optional : BaseEntity
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public string Package { get; set; }

        public IEnumerable<CourseProfessor> Professors { get; set; }

        public IEnumerable<OptionalPotentialUser> PotentialUsers { get; set; }
    }
}
