using LegumEz.Domain.Plantation.spi;

namespace LegumEz.Domain.Plantation.api;

public class Plantation
{
    private readonly GetPredictionMeteo _getPredictionMeteo;
    private readonly ICultureRepository _cultureRepository;
    
    public Plantation(ICultureRepository cultureRepository,
        GetPredictionMeteo getPredictionMeteo)
    {
        _cultureRepository = cultureRepository;
        _getPredictionMeteo = getPredictionMeteo;
    }

    public IEnumerable<Culture> GetAllCultures()
    {
        return _cultureRepository.FindAll();
    }
    
    public Culture GetCultureFromId(Guid cultureId)
    {
        return _cultureRepository.FindById(cultureId);
    }
    
    public Mois GetMoisOptimalDePlantationByLocalisation(Guid cultureAPlanterId, Localisation localisation)
    {
        var cultureAPlanter = GetCultureFromId(cultureAPlanterId);
        var predictionsMeteos = _getPredictionMeteo.ForLocalisation(localisation);
        
        return cultureAPlanter.GetMoisOptimalDePlantation(predictionsMeteos);
    }
}