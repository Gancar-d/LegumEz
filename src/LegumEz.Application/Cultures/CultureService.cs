using LegumEz.Application.Meteo;
using LegumEz.Domain.Cultures;

namespace LegumEz.Application.Cultures
{
    public class CultureService : ICultureService
    {
        private readonly ICultureRepository _cultureRepository;
        private readonly IMeteoService _meteoService;

        public CultureService(ICultureRepository cultureRepository,
        IMeteoService meteoService)
        {
            _cultureRepository = cultureRepository;
            _meteoService = meteoService;
        }

        public IEnumerable<Culture> GetCultures()
        {
            return _cultureRepository.FindAll();
        }

        public Culture GetCultureById(Guid cultureId)
        {
            return _cultureRepository.FindById(cultureId);
        }

        public async Task<int> GetMoisPlantationForCultureAndLocalisation(Guid cultureId, string localisation)
        {
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

            return moisOptimal;
        }
    }
}
