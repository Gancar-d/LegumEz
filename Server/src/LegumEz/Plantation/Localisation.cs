namespace LegumEz.Domain.Plantation;

public record Localisation(string Ville)
{
    public string Ville { get; } = Ville ?? throw new ArgumentNullException(nameof(Ville), "La ville est requise");
};