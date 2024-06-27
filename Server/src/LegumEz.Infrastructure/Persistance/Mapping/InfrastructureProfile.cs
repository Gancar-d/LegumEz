using AutoMapper;
using LegumEz.Domain.Plantation.Culture;

namespace LegumEz.Infrastructure.Persistance.Mapping
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<DAL.Cultures.Culture, Culture>();
            CreateMap<DAL.Cultures.ConditionCroissance, ConditionCroissance>();
            CreateMap<DAL.Cultures.ConditionGermination, ConditionGermination>();
            CreateMap<DAL.Cultures.Temperature, Domain.SharedKernel.Temperature>();
            CreateMap<DAL.Cultures.Temps, Temps>();
        }
    }
}
