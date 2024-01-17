using FluentAssertions;
using LegumEz.Application.Cultures;
using LegumEz.WebApi.Controllers;
using LegumEz.WebApi.Tests.ActionResultHelpers;
using LegumEz.WebApi.Tests.Builders.Cultures;
using LegumEz.WebApi.Tests.Builders.Logger;
using LegumEz.WebApi.Tests.Builders.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LegumEz.WebApi.Tests.Cultures
{
    public class CultureControllerShould
    {
        [Fact]
        public void Return_all_Culture_stored_in_database()
        {
            //-- Arrange ----------------------------------------------------------
            var logger = new LoggerBuilder<CultureController>().Build();
            var mapper = MapperBuilder.Build();
            var cultureService = new CultureServiceBuilder().WithAllCultures().Build();

            var cultureController = new CultureController(logger, mapper, cultureService);

            var expectedCultures = new List<CultureDto>
            {
                new CultureDto(Guid.NewGuid(), "Tomate"),
                new CultureDto(Guid.NewGuid(), "Carotte"),
                new CultureDto(Guid.NewGuid(), "Salade"),
            };

            //-- Act ----------------------------------------------------------
            var response = cultureController.GetCultures();

            //-- Assert ----------------------------------------------------------
            CheckThatCulturesAreReturned(expectedCultures, response);
        }

        private static void CheckThatCulturesAreReturned(List<CultureDto> expectedCultures, ActionResult<IEnumerable<CultureDto>> response)
        {
            var okResult = response.Result as OkObjectResult;

            Assert.Multiple(() =>
            {
                okResult?.CheckIsOk200();

                okResult?.Value.Should().NotBeNull();
                okResult?.Value.Should().BeEquivalentTo(expectedCultures, options => options
                    .For(x => x)
                    .Exclude(x => x.Id));
            });
        }
    }
}