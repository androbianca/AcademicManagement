namespace Entities
{
    public class PotentialUser : BaseEntity
    {
        public string UserCode { get; set; }

        public bool isStudent { get; set; }

        public Student Student { get; set; }

        public Professor Professor { get; set; }

        public Account Account { get; set; }

    }
}
