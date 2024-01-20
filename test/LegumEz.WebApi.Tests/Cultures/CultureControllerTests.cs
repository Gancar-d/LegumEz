using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using LegumEz.Application.Cultures;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;
using LegumEz.WebApi.Controllers;
using LegumEz.WebApi.Tests.ActionResultHelpers;
using LegumEz.WebApi.Tests.Builders.Cultures;
using LegumEz.WebApi.Tests.Builders.DbContext;
using LegumEz.WebApi.Tests.Builders.Logger;
using LegumEz.WebApi.Tests.Builders.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LegumEz.WebApi.Tests.Cultures
{
    public class CultureControllerShould
    {
        private readonly ILogger<CultureController> _logger;
        private readonly IMapper _mapper;

        private readonly Guid _requestedCultureId;

        public CultureControllerShould()
        {
            _logger = new LoggerBuilder<CultureController>().Build();
            _mapper = MapperBuilder.Build();
            _requestedCultureId = Guid.NewGuid();
            
            InitDb();
        }

        private void InitDb()
        {
            using var dbContext = new DbContextBuilder()
                .WithUsingInMemoryDatabase()
                .Build();
            
            dbContext.Database.EnsureDeleted();
            
            var allCultures = new List<Culture>
            {
                new DALCultureBuilder()
                    .WithId(_requestedCultureId)
                    .WithName("Carotte")
                    .WithDefaultValidConditionGermination()
                    .WithDefaultValidConditionCroissance()
                    .Build(),
                new DALCultureBuilder()
                    .WithRandomId()
                    .WithName("Tomate")
                    .WithDefaultValidConditionGermination()
                    .WithDefaultValidConditionCroissance()
                    .Build(),
                new DALCultureBuilder()
                    .WithRandomId()
                    .WithName("Salade")
                    .WithDefaultValidConditionGermination()
                    .WithDefaultValidConditionCroissance()
                    .Build(),
            };

            dbContext.Cultures.AddRange(allCultures);
            dbContext.SaveChanges();
        }

        [Fact]
        public void Return_all_Culture_stored_in_database()
        {
            //-- Arrange ----------------------------------------------------------
            var cultureService = new CultureServiceBuilder().WithInMemoryDbContext().Build();

            var cultureController = new CultureController(_logger, _mapper, cultureService);

            var expectedCultures = new List<CultureDto>
            {
                new CultureDto(Guid.NewGuid(), "Tomate"),
                new CultureDto(Guid.NewGuid(), "Carotte"),
                new CultureDto(Guid.NewGuid(), "Salade"),
            };

            //-- Act --------------------------------------------------------------
            var response = cultureController.GetCultures();

            //-- Assert -----------------------------------------------------------
            CheckThatCulturesAreReturned(expectedCultures, response);
        }

        [Fact]
        public void Return_expected_Culture_giving_Id()
        {
            //-- Arrange ----------------------------------------------------------
            var cultureService = new CultureServiceBuilder()
                .WithInMemoryDbContext()
                .Build();

            var cultureController = new CultureController(_logger, _mapper, cultureService);

            var expectedCulture = new CultureDto(_requestedCultureId, "Carotte");
            
            //-- Act --------------------------------------------------------------
            var response = cultureController.GetCulture(_requestedCultureId);

            //-- Assert -----------------------------------------------------------
            CheckThatACultureIsReturnedGivingId(response, expectedCulture);
        }

        private static void CheckThatACultureIsReturnedGivingId(ActionResult<CultureDto> response,
            CultureDto expectedCulture)
        {
            var okResult = response.Result as OkObjectResult;

            using (new AssertionScope())
            {
                okResult?.CheckIsOk200();

                okResult?.Value.Should().NotBeNull();
                okResult?.Value.Should().BeEquivalentTo(expectedCulture);
            }
        }

        private static void CheckThatCulturesAreReturned(List<CultureDto> expectedCultures,
            ActionResult<IEnumerable<CultureDto>> response)
        {
            var okResult = response.Result as OkObjectResult;

            using (new AssertionScope())
            {
                okResult?.CheckIsOk200();

                okResult?.Value.Should().NotBeNull();
                okResult?.Value.Should().BeEquivalentTo(expectedCultures, options => options
                    .For(x => x)
                    .Exclude(x => x.Id));
            }
        }
    }
}