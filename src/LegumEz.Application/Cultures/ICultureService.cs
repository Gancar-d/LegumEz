
using LegumEz.Domain.Cultures;

namespace LegumEz.Application.Cultures
{
    public interface ICultureService
    {
        IEnumerable<Culture> GetCultures();
        Culture GetCultureById(Guid cultureId);
    }
}
