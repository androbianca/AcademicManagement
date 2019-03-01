namespace Entities
{
    public class Registration :BaseEntity
    {
        public string Code { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Account Account { get; set; }
    }
}
