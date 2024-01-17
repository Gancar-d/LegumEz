using LegumEz.Domain.Cultures;
using LegumEz.Domain.Entity;

namespace LegumEz.Domain.Tests.ConditionGerminationTests
{
    public class ConditionGermination_Should
    {
        [Fact]
        public void ThrowException_IfTemperatureMinimaleIsNull()
        {
            var temperatureOptimale = new Temperature(0, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            Assert.Throws<ArgumentNullException>(() => new ConditionGermination(null, temperatureOptimale, tempsDeLevee));
        }

        [Fact]
        public void ThrowException_IfTemperatureOptimaleIsNull()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            Assert.Throws<ArgumentNullException>(() => new ConditionGermination(temperatureMinimale, null, tempsDeLevee));
        }

        [Fact]
        public void ThrowException_IfCreatedWithTemperatureMinimaleGreaterThanTemperatureOptimale()
        {
            var temperatureMinimale = new Temperature(1, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(0, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            Assert.Throws<ArgumentException>(() => new ConditionGermination(temperatureMinimale, temperatureOptimale, tempsDeLevee));
        }

        [Fact]
        public void ThrowException_IfCreatedWithTemperatureMinimaleEqualToTemperatureOptimale()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(0, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            Assert.Throws<ArgumentException>(() => new ConditionGermination(temperatureMinimale, temperatureOptimale, tempsDeLevee));
        }

        [Fact]
        public void NotThrowException_IfCreatedWithTemperatureMinimaleLessThanTemperatureOptimale()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(1, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            new ConditionGermination(temperatureMinimale, temperatureOptimale, tempsDeLevee);
        }

        [Fact]
        public void ThrowException_IfCreatedWithTempsDeLeveeIsNull()
        {
            var temperatureMinimale = new Temperature(0, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(1, UniteTemperature.Celsius);

            Assert.Throws<ArgumentNullException>(() => new ConditionGermination(temperatureMinimale, temperatureOptimale, null));
        }

        [Fact]
        public void SetTemperatureMinimale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(1, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(2, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            var conditionGermination = new ConditionGermination(temperatureMinimale, temperatureOptimale, tempsDeLevee);

            Assert.Equal(temperatureMinimale, conditionGermination.TemperatureMinimale);
        }

        [Fact]
        public void SetTemperatureOptimale_WhenCreated()
        {
            var temperatureMinimale = new Temperature(1, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(2, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            var conditionGermination = new ConditionGermination(temperatureMinimale, temperatureOptimale, tempsDeLevee);

            Assert.Equal(temperatureOptimale, conditionGermination.TemperatureOptimale);
        }

        [Fact]
        public void SetTempsDeLevee_WhenCreated()
        {
            var temperatureMinimale = new Temperature(1, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(2, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(3, UniteDeTemps.Jours);

            var conditionGermination = new ConditionGermination(temperatureMinimale, temperatureOptimale, tempsDeLevee);

            Assert.Equal(tempsDeLevee, conditionGermination.TempsDeLevee);
        }
    }
}
