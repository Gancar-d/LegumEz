using LegumEz.Domain.Plantation.api;
using LegumEz.Domain.Plantation.spi;

namespace LegumEz.Domain.Plantation;

public class CultureAccessor : IAccessCulture
{
    private readonly ICultureRepository _cultureRepository;
    
    public CultureAccessor(ICultureRepository cultureRepository)
    {
        _cultureRepository = cultureRepository;
    }
    
    public IEnumerable<Culture.Culture> All()
    {
        return _cultureRepository.FindAll();
    }

    public Culture.Culture FromId(Guid cultureId)
    {
        return _cultureRepository.FindById(cultureId);
    }
}