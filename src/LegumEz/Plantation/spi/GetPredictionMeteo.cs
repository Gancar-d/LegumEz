namespace LegumEz.Domain.Plantation.spi;

public interface GetPredictionMeteo
{
    public IEnumerable<PredictionMeteo> ForLocalisation(Localisation localisation);
}