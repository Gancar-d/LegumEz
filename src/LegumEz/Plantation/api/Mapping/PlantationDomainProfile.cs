using AutoMapper;
using LegumEz.Domain.Plantation.api.dto;
using LegumEz.Domain.Plantation.Culture;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Plantation.api.mapping
{
    public class PlantationDomainProfile : Profile
    {
        public PlantationDomainProfile()
        {
            CreateMap<Culture.Culture, SimpleCultureDto>();
            CreateMap<Culture.Culture, DetailedCultureDto>();
            CreateMap<ConditionCroissance, ConditionCroissanceDto>();
            CreateMap<ConditionGermination, ConditionGerminationDto>();
            CreateMap<Temperature, TemperatureDto>();
            CreateMap<Temps, TempsDto>();
            CreateMap<Meteo.PredictionMeteo, PredictionMeteo>();
        }
    }
}
