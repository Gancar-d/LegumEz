using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Plantation
{
    public record PredictionMeteo
    {
        public Temperature TemperatureMoyenne { get; }
        public DateTime Jour { get; }

        public PredictionMeteo(Temperature temperatureMoyenne,
            DateTime jour)
        {
            if (TemperatureMoyenne == null)
            {
                throw new ArgumentNullException(nameof(TemperatureMoyenne), "La température moyenne est requise");
            }

            TemperatureMoyenne = temperatureMoyenne;
            Jour = jour;
        }
    }
}
