namespace LegumEz.Infrastructure.MeteoApi;

public sealed class MeteoForecast
{
    public IEnumerable<ForecastDay> Days { get; set; }
}

public sealed class ForecastDay
{
    public string DateTime { get; set; }
    public int Temp { get; set; }
}