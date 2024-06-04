using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Plantation.Culture
{
    public record ConditionCroissance
    {
        public Temperature TemperatureMinimale { get; }
        public Temperature TemperatureOptimale { get; }
        public Temps TempsDeCroissance { get; }

        public ConditionCroissance(Temperature temperatureMinimale, Temperature temperatureOptimale, Temps tempsDeCroissance)
        {
            if (temperatureMinimale is null)
            {
                throw new ArgumentNullException(nameof(temperatureMinimale), "La température minimale est requise");
            }

            if (temperatureOptimale is null)
            {
                throw new ArgumentNullException(nameof(temperatureOptimale), "La rempérature optimale est requise");
            }

            if (temperatureMinimale >= temperatureOptimale)
            {
                throw new ArgumentException("La température minimale doit être strictement inférieure à la température optimale", nameof(temperatureMinimale));
            }

            TemperatureMinimale = temperatureMinimale;
            TemperatureOptimale = temperatureOptimale;
            TempsDeCroissance = tempsDeCroissance ?? throw new ArgumentNullException(nameof(tempsDeCroissance), "Le temps de croissance est requis");
        }
    }
}
