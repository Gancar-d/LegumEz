using AutoMapper;
using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.Culture;
using LegumEz.Domain.SharedKernel;
using LegumEz.WebApi.DTO;

namespace LegumEz.WebApi.Mapping
{
    public class PlantationDomainProfile : Profile
    {
        public PlantationDomainProfile()
        {
            CreateMap<Domain.Plantation.Culture.Culture, SimpleCultureDto>();
            CreateMap<Domain.Plantation.Culture.Culture, DetailedCultureDto>();
            CreateMap<ConditionCroissance, ConditionCroissanceDto>();
            CreateMap<ConditionGermination, ConditionGerminationDto>();
            CreateMap<Temperature, TemperatureDto>();
            CreateMap<Temps, TempsDto>();
            CreateMap<Domain.Meteo.PredictionMeteo, PredictionMeteo>();
        }
    }
}
