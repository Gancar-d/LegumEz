using LegumEz.Domain.Plantation.api;
using LegumEz.Domain.Plantation.spi;

namespace LegumEz.Domain.Plantation;

public class PlantationOptimizer : IOptimizePlantation
{
    private readonly IGetPredictionMeteo _getPredictionMeteo;
    
    public PlantationOptimizer(IGetPredictionMeteo getPredictionMeteo)
    {
        _getPredictionMeteo = getPredictionMeteo;
    }

    public Mois GetMoisOptimalDePlantationByLocalisation(Culture.Culture cultureAPlanter, Localisation localisation)
    {
        var predictionsMeteos = _getPredictionMeteo.ForLocalisation(localisation);
        
        return cultureAPlanter.GetMoisOptimalDePlantation(predictionsMeteos);
    }
}