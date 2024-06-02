
using LegumEz.Domain.Plantation;

namespace LegumEz.Application.Cultures
{
    public interface ICultureService
    {
        IEnumerable<Culture> GetCultures();
        Culture GetCultureById(Guid cultureId);
        Task<int> GetMoisPlantationForCultureAndLocalisation(Guid cultureId, string localisation);
    }
}
