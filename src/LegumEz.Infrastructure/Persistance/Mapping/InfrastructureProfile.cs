using AutoMapper;

namespace LegumEz.Infrastructure.Persistance.Mapping
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<DAL.Cultures.Culture, Domain.Cultures.Culture>();
            CreateMap<DAL.Cultures.ConditionCroissance, Domain.Cultures.ConditionCroissance>();
            CreateMap<DAL.Cultures.ConditionGermination, Domain.Cultures.ConditionGermination>();
            CreateMap<DAL.Cultures.Temperature, Domain.SharedKernel.Temperature>();
            CreateMap<DAL.Cultures.Temps, Domain.Cultures.Temps>();
        }
    }
}
