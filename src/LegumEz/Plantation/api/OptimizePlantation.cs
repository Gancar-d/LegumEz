
namespace LegumEz.Domain.Plantation.api;

public interface OptimizePlantation
{
    Mois GetMoisOptimalDePlantationByLocalisation(Culture culture, Localisation localisation);
}