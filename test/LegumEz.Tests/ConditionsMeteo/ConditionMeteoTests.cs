using LegumEz.Domain.ConditionsMeteos;
using LegumEz.Domain.Cultures;

namespace LegumEz.Domain.Tests.ConditionsMeteo
{
    public class ConditionMeteoShould
    {
        [Fact]
        public void SetTemperatureMinimale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            var conditionMeteo = new ConditionMeteo(temperatureMinimale, temperatureMaximale, date);

            Assert.Equal(temperatureMinimale, conditionMeteo.TemperatureMinimale);
        }

        [Fact]
        public void SetTemperatureMaximale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            var conditionMeteo = new ConditionMeteo(temperatureMinimale, temperatureMaximale, date);

            Assert.Equal(temperatureMaximale, conditionMeteo.TemperatureMaximale);
        }

        [Fact]
        public void SetTemperatureMoyenne_WhenCreated()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            var conditionMeteo = new ConditionMeteo(temperatureMinimale, temperatureMaximale, date);

            Assert.Equal(15, conditionMeteo.TemperatureMoyenne.Valeur);
        }

        [Fact]
        public void SetDate_WhenCreated()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            var conditionMeteo = new ConditionMeteo(temperatureMinimale, temperatureMaximale, date);

            Assert.Equal(date, conditionMeteo.Date);
        }

        [Theory]
        [InlineData(10, null)]
        [InlineData(null, 20)]
        public void ThrowException_IfAnyTemperatureIsNull_WhenCreated(int? valeurTemperatureMinimale, int? valeurTemperatureMaximale)
        {
            var temperatureMinimale = valeurTemperatureMinimale.HasValue ? new Temperature(valeurTemperatureMinimale.Value, UniteTemperature.Celsius) : null;
            var temperatureMaximale = valeurTemperatureMaximale.HasValue ? new Temperature(valeurTemperatureMaximale.Value, UniteTemperature.Celsius) : null;
            var date = new DateTime(2020, 1, 1);

            Assert.Throws<ArgumentNullException>(() => new ConditionMeteo(temperatureMinimale, temperatureMaximale, date));
        }

        [Fact]
        public void ThrowException_IfTemperatureMinimaleIsGreaterThanTemperatureMaximale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(20, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(10, UniteTemperature.Celsius);
            var date = new DateTime(2020, 1, 1);

            Assert.Throws<ArgumentException>(() => new ConditionMeteo(temperatureMinimale, temperatureMaximale, date));
        }
    }
}
