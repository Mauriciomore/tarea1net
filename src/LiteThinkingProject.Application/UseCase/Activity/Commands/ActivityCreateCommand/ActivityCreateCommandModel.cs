namespace LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityCreateCommand
{
    public class ActivityCreateCommandModel
    {
        public Guid Id { get; set; }
        public string ? Title { get; set; }
        public string ? Description { get; set; }
    }
}
