namespace LegumEz.Domain.SharedKernel
{
    public enum UniteTemperature
    {
        Celsius,
        Fahrenheit
    }

    public partial record Temperature(double Valeur, UniteTemperature Unite);
}
