using AutoMapper;
using LegumEz.Domain.Plantation.api.mapping;
using LegumEz.Infrastructure.MeteoApi.Mapping;

namespace LegumEz.WebApi.Tests.Builders.Mapper
{
    internal class MapperBuilder
    {
        public MapperBuilder()
        {
        }

        public static IMapper Build()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PlantationDomainProfile());
                cfg.AddProfile(new Infrastructure.Persistance.Mapping.InfrastructureProfile());
                cfg.AddProfile(new MeteoApiProfile());
            });

            return new AutoMapper.Mapper(configuration);
        }
    }
}
