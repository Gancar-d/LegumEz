using AutoMapper;
using LegumEz.Domain.Meteo;
using LegumEz.WebApi.DTO;

namespace LegumEz.WebApi.Mapping;

public class MeteoDomainProfile : Profile
{
    public MeteoDomainProfile()
    {
        CreateMap<PredictionMeteo, PredictionMeteoDto>();
    }
}