namespace Entities
{
    public class Alert : BaseEntity
    {
        public string UserCode{get;set;}
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
