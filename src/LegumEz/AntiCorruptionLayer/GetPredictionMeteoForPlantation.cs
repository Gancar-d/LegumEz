using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.spi;

namespace LegumEz.Domain.Repository.AntiCorruptionLayer;

public class GetPredictionMeteoForPlantation : GetPredictionMeteo
{
    private readonly Meteo.spi.GetPredictionMeteo _getPredictionMeteo;
    
    public GetPredictionMeteoForPlantation(Meteo.spi.GetPredictionMeteo getPredictionMeteo)
    {
        _getPredictionMeteo = getPredictionMeteo;
    }
    
    public IEnumerable<PredictionMeteo> ForLocalisation(Localisation localisation)
    {
        var predictionsMeteos = _getPredictionMeteo.ForLocalisation(ConvertLocalisationForPlantation(localisation));

        foreach (var predictionMeteo in predictionsMeteos)
        {
            yield return convertPredictionMeteoForMeteo(predictionMeteo);
        }
    }

    private Meteo.Localisation ConvertLocalisationForPlantation(Localisation localisation)
    {
        return new Meteo.Localisation(localisation.Ville);
    }

    private PredictionMeteo convertPredictionMeteoForMeteo(Meteo.PredictionMeteo predictionMeteo)
    {
        return new PredictionMeteo(predictionMeteo.TemperatureMoyenne, predictionMeteo.Jour);
    }
}