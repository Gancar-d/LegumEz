namespace LegumEz.Domain.Cultures
{
    public enum UniteTemperature
    {
        Celsius,
        Fahrenheit
    }

    public partial record Temperature
    {
        public double Valeur { get; }
        public UniteTemperature Unite { get; }

        public Temperature(double valeur, UniteTemperature unite)
        {
            Valeur = valeur;
            Unite = unite;
        }
    }
}
