using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.Culture;

namespace LegumEz.Domain.Tests.TempsTests
{
    public class Temps_Should
    {
        [Fact]
        public void SetUniteDeTemps_WhenCreated()
        {
            var temps = new Temps(1, UniteDeTemps.Jours);

            Assert.Equal(UniteDeTemps.Jours, temps.Unite);
        }

        [Fact]
        public void SetValue_WhenCreated()
        {
            var temps = new Temps(1, UniteDeTemps.Jours);

            Assert.Equal(1, temps.Valeur);
        }

        [Fact]
        public void ThrowException_IfCreatedWithNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => new Temps(-1, UniteDeTemps.Jours));
        }

        [Fact] 
        public void ThrowException_IfCreatedWithZeroValue()
        {
            Assert.Throws<ArgumentException>(() => new Temps(0, UniteDeTemps.Jours));
        }
    }
}
