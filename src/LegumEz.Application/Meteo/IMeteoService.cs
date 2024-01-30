using LegumEz.Domain.PredictionsMeteos;

namespace LegumEz.Application.Meteo;

public interface IMeteoService
{
     Task<IEnumerable<PredictionMeteo>> GetPredictionsMeteoForLocalisation(string localisation);
}