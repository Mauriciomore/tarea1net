using FluentValidation;

namespace LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityDeleteCommand
{
    public class ActivityDeleteCommandValidator : AbstractValidator<ActivityDeleteCommand>
    {
        public ActivityDeleteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("No se recibio id");



        }
    }
}
