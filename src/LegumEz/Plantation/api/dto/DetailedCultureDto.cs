using LegumEz.Domain.Plantation;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Plantation.api.dto
{
    public record DetailedCultureDto
    {
        public Guid Id { get; init; }
        public string Nom { get; init; }
        public ConditionGerminationDto ConditionGermination { get; init; }
        public ConditionCroissanceDto ConditionCroissance { get; init; }
    }

    public record ConditionGerminationDto
    {
        public TemperatureDto TemperatureMinimale { get; init; }
        public TemperatureDto TemperatureOptimale { get; init; }
        public TempsDto TempsDeLevee { get; init; }
    }

    public record ConditionCroissanceDto
    {
        public TemperatureDto TemperatureMinimale { get; init; }
        public TemperatureDto TemperatureOptimale { get; init; }
        public TempsDto TempsDeCroissance { get; init; }
    }
    
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
