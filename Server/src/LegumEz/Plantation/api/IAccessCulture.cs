namespace LegumEz.Domain.Plantation.api;

public interface IAccessCulture
{
    IEnumerable<Culture.Culture> All();
    Culture.Culture FromId(Guid cultureId);
}