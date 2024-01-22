using LegumEz.Domain.Entity;

namespace LegumEz.Application.Meteo;

public interface IMeteoService
{
     Task<IEnumerable<ConditionMeteo>> GetPredictionsMeteoForLocalisation(string localisation);
}