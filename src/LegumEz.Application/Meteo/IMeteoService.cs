using LegumEz.Domain.Meteo;

namespace LegumEz.Application.Meteo;

public interface IMeteoService
{
     Task<IEnumerable<PredictionMeteo>> GetPredictionsMeteoForLocalisation(string localisation);
}