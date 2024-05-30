using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using LegumEz.Application.Cultures;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;
using LegumEz.Infrastructure.Persistance.Exceptions;
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
        private readonly Guid _invalidRequestedCultureId;

        public CultureControllerShould()
        {
            _logger = new LoggerBuilder<CultureController>().Build();
            _mapper = MapperBuilder.Build();
            _requestedCultureId = Guid.NewGuid();
            _invalidRequestedCultureId = Guid.NewGuid();
            
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

            var expectedCultures = new List<SimpleCultureDto>
            {
                new SimpleCultureDto(Guid.NewGuid(), "Tomate"),
                new SimpleCultureDto(Guid.NewGuid(), "Carotte"),
                new SimpleCultureDto(Guid.NewGuid(), "Salade"),
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

            var expectedCulture = CreateExpectedCulture();

            //-- Act --------------------------------------------------------------
            var response = cultureController.GetCulture(_requestedCultureId);

            //-- Assert -----------------------------------------------------------
            CheckThatACultureIsReturnedGivingId(response, expectedCulture);
        }


        [Fact]
        public async Task Return_best_Periode_giving_a_culture_Id_and_a_Localisation()
        {
            //-- Arrange ----------------------------------------------------------
            var cultureService = new CultureServiceBuilder()
                .WithPredictionMeteo()
                .WithInMemoryDbContext()
                .Build();

            var cultureController = new CultureController(_logger, _mapper, cultureService);

            const string requestedLocalisation = "Montpellier";
            const int expectedMoisPlantation = 4;
            
            //-- Act --------------------------------------------------------------
            var response = await cultureController.GetMoisPlantation(_requestedCultureId, requestedLocalisation);

            //-- Assert -----------------------------------------------------------
            CheckThatReturnedPeriodeIsExpectedOne(response, expectedMoisPlantation);
        }

        [Fact]
        public void Throw_EntityNotFoundException_giving_non_existent_culture_Id()
        {
            //-- Arrange ----------------------------------------------------------
            var cultureService = new CultureServiceBuilder()
                .WithInMemoryDbContext()
                .Build();

            var cultureController = new CultureController(_logger, _mapper, cultureService);

            //-- Act --------------------------------------------------------------
            var action =
                () => cultureController.GetCulture(_invalidRequestedCultureId);

            action.Should()
                .Throw<EntityNotFoundException>()
                .Where(exception => exception.EntityType == typeof(Culture) &&
                                    exception.EntityId == _invalidRequestedCultureId);
        }
        
        private DetailedCultureDto CreateExpectedCulture()
        {
            var temperatureMinimale = new TemperatureDto() { Valeur = 10, Unite = Domain.Cultures.UniteTemperature.Celsius };
            var temperatureOptimale = new TemperatureDto() { Valeur = 20, Unite = Domain.Cultures.UniteTemperature.Celsius };
            var tempsDeLevee = new TempsDto() { Valeur = 1, Unite = Domain.Cultures.UniteDeTemps.Jours };
            var tempsDeCroissance = new TempsDto() { Valeur = 1, Unite = Domain.Cultures.UniteDeTemps.Mois };
            
            var conditionDeGermination = new ConditionGerminationDto()
            {
                TemperatureMinimale = temperatureMinimale,
                TemperatureOptimale = temperatureOptimale,
                TempsDeLevee = tempsDeLevee
            };

            var conditionDeCroissance = new ConditionCroissanceDto()
            {
                TemperatureMinimale = temperatureMinimale,
                TemperatureOptimale = temperatureOptimale,
                TempsDeCroissance = tempsDeCroissance
            };
            
            var expectedCulture = new DetailedCultureDto() {
                Id = _requestedCultureId, 
                Nom = "Carotte",
                ConditionCroissance = conditionDeCroissance,
                ConditionGermination = conditionDeGermination
            };
            return expectedCulture;
        }
        
        private static void CheckThatReturnedPeriodeIsExpectedOne(ActionResult<int> response, int expectedMoisPlantation)
        {
            var okResult = response.Result as OkObjectResult;

            using (new AssertionScope())
            {
                okResult?.CheckIsOk200();

                okResult?.Value.Should().NotBeNull();
                okResult?.Value.Should().BeEquivalentTo(expectedMoisPlantation);
            }
        }


        private static void CheckThatACultureIsReturnedGivingId(ActionResult<DetailedCultureDto> response,
            DetailedCultureDto expectedDetailedCulture)
        {
            var okResult = response.Result as OkObjectResult;

            using (new AssertionScope())
            {
                okResult?.CheckIsOk200();

                okResult?.Value.Should().NotBeNull();
                okResult?.Value.Should().BeEquivalentTo(expectedDetailedCulture);
            }
        }

        private static void CheckThatCulturesAreReturned(List<SimpleCultureDto> expectedCultures,
            ActionResult<IEnumerable<SimpleCultureDto>> response)
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