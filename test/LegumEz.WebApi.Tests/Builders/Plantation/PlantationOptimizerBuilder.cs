using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.api;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.Repositories;
using LegumEz.WebApi.Tests.Builders.DbContext;
using LegumEz.WebApi.Tests.Builders.Mapper;

namespace LegumEz.WebApi.Tests.Builders.Plantation;

internal class PlantationOptimizerBuilder
{
    public OptimizePlantation Build()
    {
        var getPredictionMeteoForPlantation = GetPredictionMeteoForPlantationBuilder.Build();
        
        return new PlantationOptimizer(getPredictionMeteoForPlantation);
    }
}