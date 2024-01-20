using LegumEz.Application.Cultures;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.Repositories;
using LegumEz.WebApi.Tests.Builders.DbContext;
using LegumEz.WebApi.Tests.Builders.Mapper;

namespace LegumEz.WebApi.Tests.Builders.Cultures
{
    internal class CultureServiceBuilder
    {
        private ApplicationDbContext? _dbContext;

        public CultureServiceBuilder WithInMemoryDbContext()
        {
            _dbContext = new DbContextBuilder()
                .WithUsingInMemoryDatabase()
                .Build();

            return this;
        }
        
        public ICultureService Build()
        {
            if (_dbContext is null)
            {
                throw new CannotBuildException($"Cannot build {nameof(CultureService)}. Required parameter {nameof(_dbContext)} was null. Consider using {nameof(WithInMemoryDbContext)} method before building.");
            }
                
            var cultureRepository = new CultureRepository(_dbContext, MapperBuilder.Build());

            return new CultureService(cultureRepository);
        }
    }
}
