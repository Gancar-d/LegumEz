
namespace LegumEz.Domain.Plantation.api;

public interface IOptimizePlantation
{
    Mois GetMoisOptimalDePlantationByLocalisation(Culture.Culture culture, Localisation localisation);
}