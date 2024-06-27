using LegumEz.Domain.Meteo.api;
using LegumEz.Domain.Meteo.spi;

namespace LegumEz.Domain.Meteo;

public class MeteoForecaster : IMeteoForecast
{
    private readonly GetPredictionMeteo _getPredictionMeteo;
    
    public MeteoForecaster(GetPredictionMeteo getPredictionMeteo)
    {
        _getPredictionMeteo = getPredictionMeteo;
    }
    
    public IEnumerable<PredictionMeteo> FromDateRange(Localisation localisation, DateTime startDate, DateTime endDate)
    {
        return _getPredictionMeteo.FromDateRange(localisation, startDate, endDate);
    }
}