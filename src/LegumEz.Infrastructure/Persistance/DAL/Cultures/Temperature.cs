namespace LegumEz.Infrastructure.Persistance.DAL.Cultures
{
    public enum UniteTemperature
    {
        Celsius,
        Fahrenheit
    }

    public partial record Temperature(double Valeur, UniteTemperature Unite);
}
