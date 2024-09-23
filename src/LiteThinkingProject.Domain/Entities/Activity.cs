namespace LiteThinkingProject.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public  string ?Title { get; set; }
        public string ?Description { get; set; }
        
        public bool State { get; set; }
    }
}


