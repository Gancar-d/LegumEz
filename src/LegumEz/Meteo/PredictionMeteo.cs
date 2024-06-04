using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Meteo
{
    public record PredictionMeteo(
        Temperature TemperatureMinimale,
        Temperature TemperatureMaximale,
        Temperature TemperatureMoyenne,
        DateTime Jour)
    {
        public Temperature TemperatureMinimale { get; } = TemperatureMinimale ?? throw new ArgumentNullException(nameof(TemperatureMinimale), "La température minimale est requise");
        public Temperature TemperatureMaximale { get; } = TemperatureMaximale ?? throw new ArgumentNullException(nameof(TemperatureMaximale), "La température maximale est requise");
        public Temperature TemperatureMoyenne { get; } = TemperatureMoyenne ?? throw new ArgumentNullException(nameof(TemperatureMoyenne), "La température moyenne est requise");
    }
}
