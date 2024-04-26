using LegumEz.Application.Meteo;
using LegumEz.Domain.Cultures;
using Microsoft.Extensions.Logging;

namespace LegumEz.Application.Cultures
{
    public class CultureService : ICultureService
    {
        private readonly ICultureRepository _cultureRepository;
        private readonly IMeteoService _meteoService;
        private readonly ILogger<CultureService> _logger;

        public CultureService(ICultureRepository cultureRepository,
        IMeteoService meteoService,
        ILogger<CultureService> logger)
        {
            _cultureRepository = cultureRepository;
            _meteoService = meteoService;
            _logger = logger;
        }

        public IEnumerable<Culture> GetCultures()
        {
            _logger.LogInformation("Getting all cultures stored in database");
            var allCultures = _cultureRepository.FindAll();
            _logger.LogInformation("Got all the cultures stored in database.");
            
            return allCultures;
        }

        public Culture GetCultureById(Guid cultureId)
        {
            _logger.LogInformation("Getting culture {CultureId} from database", cultureId);
            var culture = _cultureRepository.FindById(cultureId);
            _logger.LogInformation("Got culture {@Culture} from database", culture);
            
            return culture;
        }

        public async Task<int> GetMoisPlantationForCultureAndLocalisation(Guid cultureId, string localisation)
        {
            _logger.LogInformation("Getting mois de plantation for {CultureId} and {Localisation}", cultureId, localisation);
            
            var culture = GetCultureById(cultureId);
            var predictionsMeteos = await _meteoService.GetPredictionsMeteoForLocalisation(localisation);

            var predictionsMeteosByMonth = predictionsMeteos.GroupBy(x => x.Date.Month);
            var moisEtTemperatureProche = predictionsMeteosByMonth.Select(group =>
            {
                int mois = group.Key;
                double temperatureMoyenneProche = group
                    .Select(p => Math.Abs((p.TemperatureMoyenne - culture.ConditionGermination.TemperatureOptimale).Valeur))
                    .Min();

                return new { Mois = mois, TemperatureProche = temperatureMoyenneProche };
            });

            var moisOptimal = moisEtTemperatureProche.OrderBy(x => x.TemperatureProche).First().Mois;
            _logger.LogInformation("Founded {MoisOptimal} as mois optimal pour {@Culture} a {Localisation}",
                moisOptimal, culture, localisation);
            
            return moisOptimal;
        }
    }
}
