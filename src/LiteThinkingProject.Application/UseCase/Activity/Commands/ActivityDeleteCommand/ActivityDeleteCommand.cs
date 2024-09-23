using AutoMapper;
using LiteThinkingProject.Application.Commons.Interfaces;
using LiteThinkingProject.Application.UseCase.Commons.Handlers;
using LiteThinkingProject.Application.UseCase.Commons.Results;
using MediatR;
using LTPDomain = LiteThinkingProject.Domain.Entities;
namespace LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityDeleteCommand
{
    public class ActivityDeleteCommand : ActivityDeleteCommandModel, IRequest<Result<ActivityDeleteCommandDto>>
    {
        public class ActivityDeleteCommandHandler : UseCaseHandler, IRequestHandler<ActivityDeleteCommand, Result<ActivityDeleteCommandDto>>
        {
            private readonly IRepository<LTPDomain.Activity> _repository;
            private readonly IMapper _mapper;

            public ActivityDeleteCommandHandler(IRepository<LTPDomain.Activity> repository, IMapper mapper) : base()
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<ActivityDeleteCommandDto>> Handle(ActivityDeleteCommand request, CancellationToken cancellationToken)
            {
                var activityEntity = await _repository.GetByIdAsync(request.Id);

                if (activityEntity == null)
                {
                    return NotFound<ActivityDeleteCommandDto>("No se encontro la actividad");
                }

                await _repository.RemoveAsync(activityEntity);

                var response = new ActivityDeleteCommandDto()
                {
                    Success = true
                };

                return Succeded(response);
            }
        }
    }
}
