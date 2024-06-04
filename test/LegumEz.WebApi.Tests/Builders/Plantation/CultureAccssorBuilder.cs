using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.api;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.Repositories;
using LegumEz.WebApi.Tests.Builders.DbContext;
using LegumEz.WebApi.Tests.Builders.Mapper;

namespace LegumEz.WebApi.Tests.Builders.Plantation;

public class CultureAccessorBuilder
{
    private ApplicationDbContext? _dbContext = null;

    public CultureAccessorBuilder WithInMemoryDatabase()
    {
        _dbContext = new DbContextBuilder()
            .WithUsingInMemoryDatabase()
            .Build();

        return this;
    }
    
    public IAccessCulture Build()
    {
        if (_dbContext is null)
        {
            throw new CannotBuildException($"Cannot build {nameof(CultureRepository)}. Required parameter {nameof(_dbContext)} was null. Consider using {nameof(WithInMemoryDatabase)} method before building.");
        }
        
        var repository = new CultureRepository(_dbContext, MapperBuilder.Build());
        return new CultureAccessor(repository);
    }
}