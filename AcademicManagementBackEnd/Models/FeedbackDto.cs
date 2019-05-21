using System;

namespace Models
{
    public class FeedbackDto
    {
        public string Body { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid? StudentId { get; set; }
    }
}
