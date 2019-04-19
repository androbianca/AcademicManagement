using System.Collections.Generic;

namespace Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<ProfGroup> Profs { get; set; }
    }
}
