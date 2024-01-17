namespace LegumEz.Infrastructure.Persistance.DAL.Cultures
{
    public enum UniteTemperature
    {
        Celsius,
        Fahrenheit
    }

    public partial record Temperature
    {
        public double Valeur { get; set; }
        public UniteTemperature Unite { get; set; }
    }

}
