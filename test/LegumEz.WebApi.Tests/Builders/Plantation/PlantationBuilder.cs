using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.Repositories;
using LegumEz.WebApi.Tests.Builders.DbContext;
using LegumEz.WebApi.Tests.Builders.Mapper;

namespace LegumEz.WebApi.Tests.Builders.Plantation;

internal class PlantationBuilder
{
    private ApplicationDbContext? _dbContext; 
    
    public PlantationBuilder WithInMemoryDbContext()
    {
        _dbContext = new DbContextBuilder()
            .WithUsingInMemoryDatabase()
            .Build();
            
        return this;
    }
    
    public Domain.Plantation.api.Plantation Build()
    {
        if (_dbContext is null)
        {
            throw new CannotBuildException($"Cannot build {nameof(CultureRepository)}. Required parameter {nameof(_dbContext)} was null. Consider using {nameof(WithInMemoryDbContext)} method before building.");
        }
        
        var cultureRepository = new CultureRepository(_dbContext, MapperBuilder.Build());
        var getPredictionMeteoForPlantation = GetPredictionMeteoForPlantationBuilder.Build();
        
        return new Domain.Plantation.api.Plantation(cultureRepository, getPredictionMeteoForPlantation);
    }
}