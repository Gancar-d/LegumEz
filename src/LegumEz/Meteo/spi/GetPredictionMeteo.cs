namespace LegumEz.Domain.Meteo.spi;

public interface GetPredictionMeteo
{
    IEnumerable<PredictionMeteo> ForLocalisation(Localisation localisation);
}