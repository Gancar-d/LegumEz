using LegumEz.Domain.Repository.AntiCorruptionLayer;
using LegumEz.WebApi.Tests.Builders.Meteo;

namespace LegumEz.WebApi.Tests.Builders.Plantation;

public class GetPredictionMeteoForPlantationBuilder
{
    public static GetPredictionMeteoForPlantation Build()
    {
        var getPredictionMeteo = new GetPredictionMeteoBuilder().WithPredictionsMeteo().Build();
        
        return new GetPredictionMeteoForPlantation(getPredictionMeteo);
    }
}