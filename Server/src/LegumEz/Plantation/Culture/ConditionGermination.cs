using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Plantation.Culture
{
    public record ConditionGermination
    {
        public Temperature TemperatureMinimale { get; }
        public Temperature TemperatureOptimale { get; }
        public Temps TempsDeLevee { get; }

        public ConditionGermination(Temperature temperatureMinimale, Temperature temperatureOptimale, Temps tempsDeLevee)
        {
            if (temperatureMinimale == null)
            {
                throw new ArgumentNullException(nameof(temperatureMinimale), "La température minimale est requise");
            }

            if (temperatureOptimale is null)
            {
                throw new ArgumentNullException(nameof(temperatureOptimale), "La rempérature optimale est requise");
            }

            if (tempsDeLevee is null)
            {
                throw new ArgumentNullException(nameof(tempsDeLevee), "Le temps de levée est requis");
            }

            if (temperatureMinimale >= temperatureOptimale)
            {
                throw new ArgumentException("La température minimale doit être strictement inférieure à la température optimale", nameof(temperatureMinimale));
            }

            TemperatureMinimale = temperatureMinimale;
            TemperatureOptimale = temperatureOptimale;
            TempsDeLevee = tempsDeLevee;
        }
    }
}
