using FluentValidation;

namespace LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetByIdQuery
{
    public class ActivityGetByIdQueryValidator : AbstractValidator<ActivityGetByIdQuery>
    {
        public ActivityGetByIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("No Proporciono el Id");
        }
    }
}
