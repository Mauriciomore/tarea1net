using AutoMapper;
using LiteThinkingProject.Application.Commons.Interfaces;
using LiteThinkingProject.Application.UseCase.Commons.Handlers;
using LiteThinkingProject.Application.UseCase.Commons.Results;
using MediatR;
using LTPDomain = LiteThinkingProject.Domain.Entities;

namespace LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityCreateCommand
{
    public class ActivityCreateCommand : ActivityCreateCommandModel, IRequest<Result<ActivityCreateCommandDto>>
    {
        public class ActivityCreateCommandHandler : UseCaseHandler, IRequestHandler<ActivityCreateCommand, Result<ActivityCreateCommandDto>>
        {
            private readonly IRepository<LTPDomain.Activity> _repository;
            private readonly IMapper _mapper;

            public ActivityCreateCommandHandler(IRepository<LTPDomain.Activity> repository, IMapper mapper) : base()
            {
                _repository = repository;
                _mapper = mapper;
            }

          
            public async Task<Result<ActivityCreateCommandDto>> Handle(ActivityCreateCommand request, CancellationToken cancellationToken)
            {
         
                var activityEntity = _mapper.Map<LTPDomain.Activity>(request);

                // Guardar la entidad en la base de datos
                await _repository.AddAsync(activityEntity);

                var response = new ActivityCreateCommandDto()
                {
                    Success = true
                };

                return Succeded(response);
            }
        }
    }
}
