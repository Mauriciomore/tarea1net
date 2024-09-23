using AutoMapper;
using LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityCreateCommand;
using LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityDeleteCommand;
using LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityUpdateCommand;
using LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetAllQuery;
using LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetByIdQuery;
using LiteThinkingProject.Domain.Entities;

namespace LiteThinkingProject.Application.Commons.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Mappeos para el query de obtener todos
            CreateMap<Activity, ActivityGetAllQueryValueDto>()
           .ForMember(dest => dest.StateText, opt => opt.MapFrom(src => src.State ? "Completado" : "No completado"));


            //Mappeos para el query de obtener por id
            CreateMap<Activity, ActivityGetByIdQueryDto>().
            ForMember(dest => dest.StateText, opt => opt.MapFrom(src => src.State ? "Completado" : "No completado"));
            CreateMap<ActivityGetByIdQueryModel, ActivityGetByIdQuery>();



            //Mappeos para el comando de creación
            CreateMap<ActivityCreateCommandModel, ActivityCreateCommand>();
            CreateMap<ActivityCreateCommandModel, Activity>()
       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
       .ForMember(dest => dest.State, opt => opt.MapFrom(src => false)); // Se inicializa en false


            //Mappeos para el comando de actualización
            CreateMap<ActivityUpdateCommandModel, ActivityUpdateCommand>();
            CreateMap<ActivityUpdateCommandModel, Activity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));

            //Mappeos para el comando de eliminación
            CreateMap<ActivityDeleteCommandModel, ActivityDeleteCommand>();
        }
    }
}