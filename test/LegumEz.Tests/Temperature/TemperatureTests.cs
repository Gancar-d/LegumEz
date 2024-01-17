using LegumEz.Domain.Cultures;
using LegumEz.Domain.Entity;

namespace LegumEz.Domain.Tests.TemperatureTests
{
    public class Temperature_Should
    {
        [Fact]
        public void SetUnite_WhenCreated()
        {
            var temperature = new Temperature(1, UniteTemperature.Celsius);

            Assert.Equal(UniteTemperature.Celsius, temperature.Unite);
        }

        [Fact]
        public void SetValue_WhenCreated()
        {
            var temperature = new Temperature(1.0, UniteTemperature.Celsius);

            Assert.Equal(1.0, temperature.Valeur);
        }




    }
}
