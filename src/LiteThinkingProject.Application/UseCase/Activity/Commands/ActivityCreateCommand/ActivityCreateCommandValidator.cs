using FluentValidation;

namespace LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityCreateCommand
{
    public class ActivityCreateCommandValidator : AbstractValidator<ActivityCreateCommand>
    {
        public ActivityCreateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("No tiene ID");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Debe tener un titulo");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Debe tener una descripcion");


        }
    }
}
