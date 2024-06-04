namespace LegumEz.Domain.Meteo;

public record Localisation
{
    public Localisation(string ville)
    {
        Ville = ville;
    }
    public string Ville { get; init; }
}