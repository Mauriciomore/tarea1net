using AutoMapper;
using LiteThinkingProject.Application.Commons.Interfaces;
using LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetAllQuery;
using LiteThinkingProject.Application.UseCase.Commons.Handlers;
using LiteThinkingProject.Application.UseCase.Commons.Results;
using MediatR;
using LTPDomain = LiteThinkingProject.Domain.Entities;

namespace LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetByIdQuery
{
    public class ActivityGetByIdQuery:ActivityGetByIdQueryModel,IRequest<Result<ActivityGetByIdQueryDto>>
    {
        public class ActivityGetByIdQueryHandler: UseCaseHandler,IRequestHandler<ActivityGetByIdQuery, 
            Result<ActivityGetByIdQueryDto>>
        {
            private readonly IRepository<LTPDomain.Activity> _repository;
            private readonly IMapper _mapper;

            public ActivityGetByIdQueryHandler(IRepository<LTPDomain.Activity> repository, IMapper mapper) : base()
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<ActivityGetByIdQueryDto>> Handle(ActivityGetByIdQuery request, CancellationToken cancellationToken)
            {
                //recuperar la actividad con el id
                var activity = await _repository.GetByIdAsync(request.Id);
                // Mapear las entidades de actividad a los DTOs usando AutoMapper
                var activities = _mapper.Map<ActivityGetByIdQueryDto>(activity);
                return Succeded(activities);
            }
        }

    }
}
