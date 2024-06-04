using AutoMapper;
using LegumEz.Domain.Meteo;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;

namespace LegumEz.Infrastructure.MeteoApi.Mapping;

public class MeteoApiProfile : Profile
{
    public MeteoApiProfile()
    {
        CreateMap<ForecastDay, PredictionMeteo>()
            .ForCtorParam(nameof(PredictionMeteo. TemperatureMinimale), o => o.MapFrom(s => new Temperature((float)s.TempMin, UniteTemperature.Celsius)))
            .ForCtorParam(nameof(PredictionMeteo.TemperatureMaximale), o => o.MapFrom(s => new Temperature((float)s.TempMax, UniteTemperature.Celsius)))
            .ForCtorParam(nameof(PredictionMeteo.TemperatureMoyenne), o => o.MapFrom(s => new Temperature((float)s.Temp, UniteTemperature.Celsius)))
            .ForCtorParam(nameof(PredictionMeteo.Jour), o => o.MapFrom(s => DateTime.Parse(s.DateTime)));
    }
}