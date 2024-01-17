using LegumEz.Application.Cultures;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.Repositories;
using LegumEz.WebApi.Tests.Builders.DbContext;
using LegumEz.WebApi.Tests.Builders.Mapper;

namespace LegumEz.WebApi.Tests.Builders.Cultures
{
    internal class CultureServiceBuilder
    {
        private ApplicationDbContext _dbContext;

        public CultureServiceBuilder()
        {
            _dbContext = new DbContextBuilder()
                .WithUsingInMemoryDatabase()
                .Build();
        }

        public CultureServiceBuilder WithAllCultures()
        {
            var allCultures = new List<Infrastructure.Persistance.DAL.Cultures.Culture>
            {
                new DALCultureBuilder()
                .WithRandomId()
                .WithName("Tomate")
                .WithDefaultValidConditionGermination()
                .WithDefaultValidConditionCroissance()
                .Build(),
                new DALCultureBuilder()
                .WithRandomId()
                .WithName("Carotte")
                .WithDefaultValidConditionGermination()
                .WithDefaultValidConditionCroissance()
                .Build(),
                new DALCultureBuilder()
                .WithRandomId()
                .WithName("Salade")
                .WithDefaultValidConditionGermination()
                .WithDefaultValidConditionCroissance()
                .Build(),
            };

            _dbContext.Cultures.AddRange(allCultures);
            _dbContext.SaveChanges();

            return this;
        }

        public ICultureService Build()
        {
            var cultureRepository = new CultureRepository(_dbContext, MapperBuilder.Build());

            return new CultureService(cultureRepository);
        }
    }
}
