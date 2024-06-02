using AutoMapper;
using LegumEz.Application.Cultures;
using LegumEz.Domain.Cultures;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.Application.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Culture, SimpleCultureDto>();
            CreateMap<Culture, DetailedCultureDto>();
            CreateMap<ConditionCroissance, ConditionCroissanceDto>();
            CreateMap<ConditionGermination, ConditionGerminationDto>();
            CreateMap<Temperature, TemperatureDto>();
            CreateMap<Temps, TempsDto>();
        }
    }
}
