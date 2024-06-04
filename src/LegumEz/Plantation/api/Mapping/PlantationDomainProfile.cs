using AutoMapper;
using LegumEz.Domain.Plantation.api.dto;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Plantation.api.mapping
{
    public class PlantationDomainProfile : Profile
    {
        public PlantationDomainProfile()
        {
            CreateMap<Culture, SimpleCultureDto>();
            CreateMap<Culture, DetailedCultureDto>();
            CreateMap<ConditionCroissance, ConditionCroissanceDto>();
            CreateMap<ConditionGermination, ConditionGerminationDto>();
            CreateMap<Temperature, TemperatureDto>();
            CreateMap<Temps, TempsDto>();
            CreateMap<Meteo.PredictionMeteo, PredictionMeteo>();
        }
    }
}
