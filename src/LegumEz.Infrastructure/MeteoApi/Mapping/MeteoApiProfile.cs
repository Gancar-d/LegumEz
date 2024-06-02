using AutoMapper;
using LegumEz.Domain.Meteo;

namespace LegumEz.Infrastructure.MeteoApi.Mapping;

public class MeteoApiProfile : Profile
{
    public MeteoApiProfile()
    {
        CreateMap<ForecastDay, PredictionMeteo>()
            .ForMember(d => d.TemperatureMoyenne, o => o.MapFrom(s => s.Temp))
            .ForMember(d => d.Jour, o => o.MapFrom(s => s.DateTime));
    }
}