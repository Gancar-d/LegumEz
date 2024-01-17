namespace LegumEz.Domain.Cultures
{
    public enum UniteDeTemps
    {
        Jours,
        Semaines,
        Mois
    }

    public record Temps
    {
        public int Valeur { get; }
        public UniteDeTemps Unite { get; }

        public Temps(int valeur, UniteDeTemps unite)
        {
            if (valeur <= 0)
            {
                throw new ArgumentException("La valeur doit être strictement positive", nameof(valeur));
            }

            Valeur = valeur;
            Unite = unite;
        }
    }
}
