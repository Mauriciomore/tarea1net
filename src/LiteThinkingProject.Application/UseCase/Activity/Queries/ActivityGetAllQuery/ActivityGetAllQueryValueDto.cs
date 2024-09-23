namespace LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetAllQuery
{
    public class ActivityGetAllQueryValueDto 
    {
        public Guid Id { get; set; }
        public string ?Title { get; set; }
        public string? Description { get; set; }
        public string ?StateText { get; set; }
    }
}
