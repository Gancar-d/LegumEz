using FluentAssertions;
using LegumEz.Domain.Entity;

namespace LegumEz.Domain.Tests.LocalisationTests
{
    public class Localisation_Should
    {
        [Fact]
        public void SetVille_WhenCreated()
        {
            // Arrange
            var ville = "Montpellier";

            // Act
            var localisation = new Localisation(ville, "France");

            // Assert
            Assert.Equal(ville, localisation.Ville);
        }

        [Fact]
        public void SetPays_WhenCreated()
        {
            // Arrange
            var pays = "France";

            // Act
            var localisation = new Localisation("Montpellier", pays);

            // Assert
            Assert.Equal(pays, localisation.Pays);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowArgumentException_WhenVilleIsNullOrEmpty(string ville)
        {
            // Arrange
            var pays = "France";

            // Act
            var exception = Record.Exception(() => new Localisation(ville, pays));

            // Assert
            exception.Should().NotBeNull().And.BeOfType<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowArgumentException_WhenPaysIsNullOrEmpty(string pays)
        {
            // Arrange
            var ville = "Montpellier";

            // Act
            var exception = Record.Exception(() => new Localisation(ville, pays));

            //Assert
            exception.Should().NotBeNull().And.BeOfType<ArgumentException>();
        }
    }
}
