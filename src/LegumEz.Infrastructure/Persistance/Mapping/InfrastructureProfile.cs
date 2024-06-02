using AutoMapper;

namespace LegumEz.Infrastructure.Persistance.Mapping
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<DAL.Cultures.Culture, Domain.Plantation.Culture>();
            CreateMap<DAL.Cultures.ConditionCroissance, Domain.Plantation.ConditionCroissance>();
            CreateMap<DAL.Cultures.ConditionGermination, Domain.Plantation.ConditionGermination>();
            CreateMap<DAL.Cultures.Temperature, Domain.SharedKernel.Temperature>();
            CreateMap<DAL.Cultures.Temps, Domain.Plantation.Temps>();
        }
    }
}
