using AutoMapper;
using LiteThinkingProject.Application.Commons.Interfaces;
using LiteThinkingProject.Application.UseCase.Commons.Handlers;
using LiteThinkingProject.Application.UseCase.Commons.Results;
using MediatR;
using LTPDomain = LiteThinkingProject.Domain.Entities;

namespace LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityUpdateCommand
{
    public class ActivityUpdateCommand : ActivityUpdateCommandModel, IRequest<Result<ActivityUpdateCommandDto>>
    {
        public class ActivityUpdateCommandHandler : UseCaseHandler, IRequestHandler<ActivityUpdateCommand, Result<ActivityUpdateCommandDto>>
        {
            private readonly IRepository<LTPDomain.Activity> _repository;
            private readonly IMapper _mapper;

            public ActivityUpdateCommandHandler(IRepository<LTPDomain.Activity> repository, IMapper mapper) : base()
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<ActivityUpdateCommandDto>> Handle(ActivityUpdateCommand request, CancellationToken cancellationToken)
            {
                var activityEntity = await _repository.GetByIdAsync(request.Id);

                if (activityEntity == null)
                {
                    return NotFound<ActivityUpdateCommandDto>("No se encontro la actividad");
                }

                activityEntity = _mapper.Map(request, activityEntity);

                await _repository.UpdateAsync(activityEntity);

                var response = new ActivityUpdateCommandDto()
                {
                    Success = true
                };

                return Succeded(response);
            }
        }
    }
}
