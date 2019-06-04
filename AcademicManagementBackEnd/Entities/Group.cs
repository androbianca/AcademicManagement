using System.Collections.Generic;

namespace Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
