namespace LegumEz.Domain.Meteo.api;

public interface IMeteoForecast
{
    IEnumerable<PredictionMeteo> FromDateRange(Localisation localisation, DateTime startDate, DateTime endDate);
}