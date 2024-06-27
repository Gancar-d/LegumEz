namespace LegumEz.Domain.Plantation.spi;

public interface IGetPredictionMeteo
{
    public IEnumerable<PredictionMeteo> ForLocalisation(Localisation localisation);
}