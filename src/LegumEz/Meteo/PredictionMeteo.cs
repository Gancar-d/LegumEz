using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Meteo
{
    public record PredictionMeteo
    {
        public Temperature TemperatureMinimale { get; }
        public Temperature TemperatureMaximale { get; }
        public Temperature TemperatureMoyenne { get; }
        public DateTime Jour { get; }

        public PredictionMeteo(
            Temperature temperatureMinimale,
            Temperature temperatureMaximale,
            Temperature temperatureMoyenne,
            DateTime jour)
        {
            TemperatureMinimale = temperatureMinimale ??
                                  throw new ArgumentNullException(nameof(temperatureMinimale),
                                      "La température minimale est requise");
            TemperatureMaximale = temperatureMaximale ??
                                  throw new ArgumentNullException(nameof(temperatureMaximale),
                                      "La température maximale est requise");
            TemperatureMoyenne = temperatureMoyenne ??
                                 throw new ArgumentNullException(nameof(temperatureMoyenne),
                                     "La température moyenne est requise");

            Jour = jour;
            
            if (TemperatureMaximale < TemperatureMinimale)
            {
                throw new ArgumentException(
                    "La temperature minimale ne peut pas être superieure à la temperature maximale",
                    nameof(temperatureMinimale));
            }
            
            if (TemperatureMoyenne < TemperatureMinimale || TemperatureMoyenne > TemperatureMaximale)
            {
                throw new ArgumentException(
                    "La temperature moyenne doit être comprise entre la temperature minimale et maximale",
                    nameof(temperatureMoyenne));
            }
        }
    }
}