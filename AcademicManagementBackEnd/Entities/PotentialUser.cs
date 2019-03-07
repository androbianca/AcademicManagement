namespace Entities
{
    public class PotentialUser : BaseEntity
    {
        public string UserCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Year { get; set; }
        public string Group { get; set; }
        public string Photo { get; set; }
    }
}
