using FluentValidation;

namespace LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityUpdateCommand
{
        public class ActivityUpdateCommandValidator : AbstractValidator<ActivityUpdateCommand>
        {
            public ActivityUpdateCommandValidator()
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

            RuleFor(x => x.State)
                .NotNull()
                .NotEmpty()
                .WithMessage("Debe tener un estado");

        }
    }
}
