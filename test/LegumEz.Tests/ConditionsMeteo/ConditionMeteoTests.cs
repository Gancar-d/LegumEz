using LegumEz.Domain.Meteo;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Tests.ConditionsMeteo
{
    public class ConditionMeteoShould
    {
        [Fact]
        public void SetTemperatureMinimale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var temperatureMoyenne = new Temperature(15, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            var conditionMeteo = new PredictionMeteo(temperatureMinimale, temperatureMaximale, temperatureMoyenne, date);

            Assert.Equal(temperatureMinimale, conditionMeteo.TemperatureMinimale);
        }

        [Fact]
        public void SetTemperatureMaximale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var temperatureMoyenne = new Temperature(15, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            var conditionMeteo = new PredictionMeteo(temperatureMinimale, temperatureMaximale, temperatureMoyenne, date);

            Assert.Equal(temperatureMaximale, conditionMeteo.TemperatureMaximale);
        }

        [Fact]
        public void SetTemperatureMoyenne_WhenCreated()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var temperatureMoyenne = new Temperature(15, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            var conditionMeteo = new PredictionMeteo(temperatureMinimale, temperatureMaximale, temperatureMoyenne, date);

            Assert.Equal(15, conditionMeteo.TemperatureMoyenne.Valeur);
        }

        [Fact]
        public void SetDate_WhenCreated()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var temperatureMoyenne = new Temperature(15, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            var conditionMeteo = new PredictionMeteo(temperatureMinimale, temperatureMaximale, temperatureMoyenne, date);

            Assert.Equal(date, conditionMeteo.Jour);
        }

        [Theory]
        [InlineData(null, 20, 15)]
        [InlineData(10, null, 15)]
        [InlineData(10, 20, null)]
        public void ThrowException_IfAnyTemperatureIsNull_WhenCreated(int? valeurTemperatureMinimale, int? valeurTemperatureMaximale, int? valeurTemperatureMoyenne)
        {
            var temperatureMinimale = valeurTemperatureMinimale.HasValue ? new Temperature(valeurTemperatureMinimale.Value, UniteTemperature.Celsius) : null;
            var temperatureMaximale = valeurTemperatureMaximale.HasValue ? new Temperature(valeurTemperatureMaximale.Value, UniteTemperature.Celsius) : null;
            var temperatureMoyenne = valeurTemperatureMoyenne.HasValue ? new Temperature(valeurTemperatureMoyenne.Value, UniteTemperature.Celsius) : null;
            var date = new DateTime(2020, 1, 1);

            Assert.Throws<ArgumentNullException>(() => new PredictionMeteo(temperatureMinimale, temperatureMaximale, temperatureMoyenne, date));
        }

        [Fact]
        public void ThrowException_IfTemperatureMinimaleIsGreaterThanTemperatureMaximale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(20, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMoyenne = new Temperature(15, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            Assert.Throws<ArgumentException>(() => new PredictionMeteo(temperatureMinimale, temperatureMaximale, temperatureMoyenne, date));
        }
    }
}
