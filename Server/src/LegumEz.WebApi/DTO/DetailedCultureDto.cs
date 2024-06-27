using LegumEz.Domain.Plantation.Culture;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.WebApi.DTO
{
    public record DetailedCultureDto(
        Guid Id,
        string Nom,
        ConditionGerminationDto ConditionGermination,
        ConditionCroissanceDto ConditionCroissance);

    public record ConditionGerminationDto(
        TemperatureDto TemperatureMinimale,
        TemperatureDto TemperatureOptimale,
        TempsDto TempsDeLevee);

    public record ConditionCroissanceDto(
        TemperatureDto TemperatureMinimale,
        TemperatureDto TemperatureOptimale,
        TempsDto TempsDeCroissance);
    
    public record TempsDto
    {
        public int Valeur;
        public UniteDeTemps Unite;
    }

    public record TemperatureDto
    {
        public double Valeur { get; init; }
        public UniteTemperature Unite { get; init; }
    }
}
