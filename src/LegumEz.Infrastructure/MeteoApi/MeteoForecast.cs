namespace LegumEz.Infrastructure.MeteoApi;

public sealed class MeteoForecast
{
    public IEnumerable<ForecastDay> Days { get; set; }
}

public sealed class ForecastDay
{
    public string DateTime { get; set; }
    public decimal Temp { get; set; }
    public decimal TempMax { get; set; }
    public decimal TempMin { get; set; }
}