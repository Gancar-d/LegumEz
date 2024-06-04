using AutoMapper;
using LegumEz.Domain.Meteo;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;

namespace LegumEz.Infrastructure.MeteoApi.Mapping;

public class MeteoApiProfile : Profile
{
    public MeteoApiProfile()
    {
        CreateMap<ForecastDay, PredictionMeteo>()
            .ForCtorParam("temperatureMinimale", o => o.MapFrom(s => new Temperature((float)s.TempMin, UniteTemperature.Celsius)))
            .ForCtorParam("temperatureMaximale", o => o.MapFrom(s => new Temperature((float)s.TempMax, UniteTemperature.Celsius)))
            .ForCtorParam("temperatureMoyenne", o => o.MapFrom(s => new Temperature((float)s.Temp, UniteTemperature.Celsius)))
            .ForCtorParam("jour", o => o.MapFrom(s => DateTime.Parse(s.DateTime)));
    }
}