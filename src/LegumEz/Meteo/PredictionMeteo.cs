using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Meteo
{
    public record PredictionMeteo
    {
        public Temperature TemperatureMinimale { get; }
        public Temperature TemperatureMaximale { get; }
        public Temperature TemperatureMoyenne { get; }
        public DateTime Jour { get; }

        public PredictionMeteo(Temperature temperatureMinimale,
            Temperature temperatureMaximale,
            DateTime jour)
        {
            if (temperatureMinimale == null)
            {
                throw new ArgumentNullException(nameof(temperatureMinimale), "La température minimale est requise");
            }

            if (temperatureMaximale == null)
            {
                throw new ArgumentNullException(nameof(temperatureMaximale), "La température maximale est requise");
            }

            if (temperatureMinimale > temperatureMaximale)
            {
                throw new ArgumentException("La température minimale doit être inférieure à la température maximale", nameof(temperatureMinimale));
            }

            TemperatureMinimale = temperatureMinimale;
            TemperatureMaximale = temperatureMaximale;
            TemperatureMoyenne = CalculerTemperatureMoyenne(temperatureMinimale, temperatureMaximale);
            Jour = jour;
        }

        private static Temperature CalculerTemperatureMoyenne(Temperature temperatureMinimale, Temperature temperatureMaximale)
        {
            var valeurTemperatureMoyenne = (temperatureMinimale.Valeur + temperatureMaximale.Valeur) / 2;

            return new Temperature(valeurTemperatureMoyenne, temperatureMinimale.Unite);
        }

    }
}
