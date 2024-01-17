using LegumEz.Domain.Cultures;
using LegumEz.Domain.Entity;

namespace LegumEz.Domain.Tests.ConditionDeCroissanceTests
{
    public class ConditionDeCroissance_Should
    {
        [Fact]
        public void ThrowException_IfTemperatureMinimaleIsNull()
        {
            var temperatureOptimale = new Temperature(0, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            Assert.Throws<ArgumentNullException>(() => new ConditionCroissance(null, temperatureOptimale, tempsDeCroissance));
        }

        [Fact]
        public void ThrowException_IfTemperatureOptimaleIsNull()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            Assert.Throws<ArgumentNullException>(() => new ConditionCroissance(temperatureMinimale, null, tempsDeCroissance));
        }

        [Fact]
        public void ThrowException_IfCreatedWithTemperatureMinimaleGreaterThanTemperatureOptimale()
        {
            var temperatureMinimale = new Temperature(1, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(0, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            Assert.Throws<ArgumentException>(() => new ConditionCroissance(temperatureMinimale, temperatureOptimale, tempsDeCroissance));
        }

        [Fact]
        public void ThrowException_IfCreatedWithTemperatureMinimaleEqualToTemperatureOptimale()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(0, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            Assert.Throws<ArgumentException>(() => new ConditionCroissance(temperatureMinimale, temperatureOptimale, tempsDeCroissance));
        }

        [Fact]
        public void NotThrowException_IfCreatedWithTemperatureMinimaleLessThanTemperatureOptimale()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(1, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            new ConditionCroissance(temperatureMinimale, temperatureOptimale, tempsDeCroissance);
        }

        [Fact]
        public void NotThrowException_IfCreatedWithTempsDeCroissanceGreaterThanZero()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(1, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            new ConditionCroissance(temperatureMinimale, temperatureOptimale, tempsDeCroissance);
        }

        [Fact]
        public void ThrowException_IfCreatedWithTempsDeCroissanceIsNull()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(1, UniteTemperature.Celsius);

            Assert.Throws<ArgumentNullException>(() => new ConditionCroissance(temperatureMinimale, temperatureOptimale, null));
        }

        [Fact]
        public void SetTemperatureMinimale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(1, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(2, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            var conditionDeCroissance = new ConditionCroissance(temperatureMinimale, temperatureOptimale, tempsDeCroissance);

            Assert.Equal(temperatureMinimale, conditionDeCroissance.TemperatureMinimale);
        }

        [Fact]
        public void SetTemperatureOptimale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(1, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(2, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            var conditionDeCroissance = new ConditionCroissance(temperatureMinimale, temperatureOptimale, tempsDeCroissance);

            Assert.Equal(temperatureOptimale, conditionDeCroissance.TemperatureOptimale);
        }

        [Fact]
        public void SetTempsDeCroissance_WhenCreated()
        {
            var temperatureMinimale = new Temperature(1, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(2, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

            var conditionDeCroissance = new ConditionCroissance(temperatureMinimale, temperatureOptimale, tempsDeCroissance);

            Assert.Equal(tempsDeCroissance, conditionDeCroissance.TempsDeCroissance);
        }
    }
}
