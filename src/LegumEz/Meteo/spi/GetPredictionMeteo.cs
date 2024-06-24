namespace LegumEz.Domain.Meteo.spi;

public interface GetPredictionMeteo
{
    IEnumerable<PredictionMeteo> ForLocalisation(Localisation localisation);
    IEnumerable<PredictionMeteo> FromDateRange(Localisation localisation, DateTime startDate, DateTime endDate);
}