using LegumEz.Domain.Meteo.spi;
using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.spi;

namespace LegumEz.Domain.AntiCorruptionLayer;

public class GetPredictionMeteoForPlantation : IGetPredictionMeteo
{
    private readonly GetPredictionMeteo _getPredictionMeteo;
    
    public GetPredictionMeteoForPlantation(GetPredictionMeteo getPredictionMeteo)
    {
        _getPredictionMeteo = getPredictionMeteo;
    }
    
    public IEnumerable<PredictionMeteo> ForLocalisation(Localisation localisation)
    {
        var predictionsMeteos = _getPredictionMeteo.ForLocalisation(ConvertLocalisationForPlantation(localisation));

        foreach (var predictionMeteo in predictionsMeteos)
        {
            yield return ConvertPredictionMeteoForMeteo(predictionMeteo);
        }
    }

    private static Meteo.Localisation ConvertLocalisationForPlantation(Localisation localisation)
    {
        return new Meteo.Localisation(localisation.Ville);
    }

    private static PredictionMeteo ConvertPredictionMeteoForMeteo(Meteo.PredictionMeteo predictionMeteo)
    {
        return new PredictionMeteo(predictionMeteo.TemperatureMoyenne, predictionMeteo.Jour);
    }
}