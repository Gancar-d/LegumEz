using LegumEz.Domain.Plantation.api;
using LegumEz.Domain.Plantation.spi;

namespace LegumEz.Domain.Plantation;

internal class CultureAccessor : AccessCulture
{
    private readonly ICultureRepository _cultureRepository;
    
    public CultureAccessor(ICultureRepository cultureRepository)
    {
        _cultureRepository = cultureRepository;
    }
    
    public IEnumerable<Culture> All()
    {
        return _cultureRepository.FindAll();
    }

    public Culture FromId(Guid cultureId)
    {
        return _cultureRepository.FindById(cultureId);
    }
}