using LegumEz.Domain.AntiCorruptionLayer;
using LegumEz.WebApi.Tests.Builders.Meteo;

namespace LegumEz.WebApi.Tests.Builders.Plantation;

public static class GetPredictionMeteoForPlantationBuilder
{
    public static GetPredictionMeteoForPlantation Build()
    {
        var getPredictionMeteo = new GetPredictionMeteoBuilder().WithPredictionsMeteo().Build();
        
        return new GetPredictionMeteoForPlantation(getPredictionMeteo);
    }
}