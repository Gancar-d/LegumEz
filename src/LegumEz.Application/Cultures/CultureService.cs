using System.Collections;
using AutoMapper;
using LegumEz.Application.Meteo;
using LegumEz.Domain.Plantation;
using Microsoft.Extensions.Logging;

namespace LegumEz.Application.Cultures
{
    public class CultureService : ICultureService
    {
        private readonly ICultureRepository _cultureRepository;
        private readonly IMeteoService _meteoService;
        private readonly ILogger<CultureService> _logger;
        private readonly IMapper _mapper;

        public CultureService(ICultureRepository cultureRepository,
        IMeteoService meteoService,
        ILogger<CultureService> logger,
        IMapper mapper)
        {
            _cultureRepository = cultureRepository;
            _meteoService = meteoService;
            _logger = logger;
            _mapper = mapper;
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

            var moisOptimal = culture.GetMeilleurMoisPlantation(_mapper.Map<IEnumerable<Domain.Plantation.PredictionMeteo>>(predictionsMeteos));
            
            _logger.LogInformation("Founded {MoisOptimal} as mois optimal pour {@Culture} a {Localisation}",
                moisOptimal, culture, localisation);
            
            return moisOptimal;
        }
    }
}
