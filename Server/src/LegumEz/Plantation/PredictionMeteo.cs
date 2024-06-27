using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Plantation
{
    public record PredictionMeteo(
        Temperature TemperatureMoyenne,
        DateTime Journee)
    {
        public Temperature TemperatureMoyenne { get; } = TemperatureMoyenne ?? throw new ArgumentNullException(nameof(TemperatureMoyenne), "La température moyenne est requise");
    }
}
