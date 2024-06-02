using AutoMapper;
using LegumEz.Application.Cultures;
using LegumEz.Domain.Plantation;
using LegumEz.Domain.SharedKernel;
using PredictionMeteo = LegumEz.Domain.Meteo.PredictionMeteo;

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
            CreateMap<LegumEz.Domain.Meteo.PredictionMeteo, LegumEz.Domain.Plantation.PredictionMeteo>();
        }
    }
}
