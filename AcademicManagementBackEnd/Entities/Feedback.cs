using System;

namespace Entities
{
    public class Feedback : BaseEntity
    {
        public string Body { get; set; }
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public Guid? StudentId { get; set; }
        public Student Student { get; set; }

    }
}
