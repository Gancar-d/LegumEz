namespace LegumEz.Domain.Plantation.api;

public interface AccessCulture
{
    IEnumerable<Culture> All();
    Culture FromId(Guid cultureId);
}