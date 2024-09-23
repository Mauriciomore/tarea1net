namespace LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityUpdateCommand
{
    public class ActivityUpdateCommandModel
    {
            public Guid Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public bool State { get; set; }
    }
}
