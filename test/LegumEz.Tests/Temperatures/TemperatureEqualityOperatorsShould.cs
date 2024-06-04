using LegumEz.Domain.Plantation;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Tests.Temperatures
{
    public class TemperatureEqualityOperatorsShould
    {
        [Fact]
        public void ReturnTrue_WhenEqual()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(1.0, UniteTemperature.Celsius);

            Assert.True(temperature1 == temperature2);
        }

        [Fact]
        public void ReturnFalse_WhenNotEqual()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(2.0, UniteTemperature.Celsius);

            Assert.False(temperature1 == temperature2);
        }

        [Fact]
        public void ReturnFalse_WhenCompareWithDifferentUnites()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(1.0, UniteTemperature.Fahrenheit);

           Assert.False(temperature1 == temperature2);
        }

        [Fact]
        public void ThrowException_WhenAddWithDifferentUnites()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(1.0, UniteTemperature.Fahrenheit);

            Assert.Throws<InvalidOperationException>(() => temperature1 + temperature2);
        }

        [Fact]
        public void ThrowException_WhenSubstractedWithDifferentUnites()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(1.0, UniteTemperature.Fahrenheit);

            Assert.Throws<InvalidOperationException>(() => temperature1 - temperature2);
        }

        [Fact]
        public void ReturnTemperatureWithSameUnite_WhenAdded()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(1.0, UniteTemperature.Celsius);

            var result = temperature1 + temperature2;

            Assert.Equal(UniteTemperature.Celsius, result.Unite);
        }

        [Fact]
        public void ReturnTemperatureWithSameUnite_WhenSubstracted()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(1.0, UniteTemperature.Celsius);

            var result = temperature1 - temperature2;

            Assert.Equal(UniteTemperature.Celsius, result.Unite);
        }

        [Fact]
        public void ReturnTemperatureWithCorrectValue_WhenAdded()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(1.0, UniteTemperature.Celsius);

            var result = temperature1 + temperature2;

            Assert.Equal(2.0, result.Valeur);
        }

        [Fact]
        public void ReturnTemperatureWithCorrectValue_WhenSubstracted()
        {
            var temperature1 = new Temperature(1.0, UniteTemperature.Celsius);
            var temperature2 = new Temperature(1.0, UniteTemperature.Celsius);

            var result = temperature1 - temperature2;

            Assert.Equal(0.0, result.Valeur);
        }
    }
}
