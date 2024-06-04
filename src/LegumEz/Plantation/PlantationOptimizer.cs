using LegumEz.Domain.Plantation.api;
using LegumEz.Domain.Plantation.spi;

namespace LegumEz.Domain.Plantation;

internal class PlantationOptimizer : OptimizePlantation
{
    private readonly GetPredictionMeteo _getPredictionMeteo;
    
    public PlantationOptimizer(GetPredictionMeteo getPredictionMeteo)
    {
        _getPredictionMeteo = getPredictionMeteo;
    }

    public Mois GetMoisOptimalDePlantationByLocalisation(Culture cultureAPlanter, Localisation localisation)
    {
        var predictionsMeteos = _getPredictionMeteo.ForLocalisation(localisation);
        
        return cultureAPlanter.GetMoisOptimalDePlantation(predictionsMeteos);
    }
}