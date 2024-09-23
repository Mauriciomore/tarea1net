using LiteThinkingProject.Application.Commons.Interfaces;
using LiteThinkingProject.Application.UseCase.Commons.Handlers;
using LiteThinkingProject.Application.UseCase.Commons.Results;
using LTPDomain = LiteThinkingProject.Domain.Entities;

using MediatR;
using AutoMapper;

namespace LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetAllQuery;

public class ActivityGetAllQuery : IRequest<Result<ActivityGetAllQueryDto>>
{
    public class ActivityGetAllQueryHandler : UseCaseHandler, IRequestHandler<ActivityGetAllQuery,
        Result<ActivityGetAllQueryDto>>
    {
        private readonly IRepository<LTPDomain.Activity> _repository;
        private readonly IMapper _mapper;

        public ActivityGetAllQueryHandler(IRepository<LTPDomain.Activity> repository, IMapper mapper) : base()
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<ActivityGetAllQueryDto>> Handle(ActivityGetAllQuery request, CancellationToken cancellationToken)
        {
            // Obtener todas las actividades desde el repositorio
            var result = await _repository.GetAllAsync();

            // Mapear las entidades de actividad a los DTOs usando AutoMapper
            var activities = _mapper.Map<List<ActivityGetAllQueryValueDto>>(result);

            var response = new ActivityGetAllQueryDto
            {
                Activities = activities
            };

            // Devolver el resultado exitoso
            return Succeded(response);
        }
    }
}
