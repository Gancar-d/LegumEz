namespace LegumEz.WebApi.Tests.Builders;

public class CannotBuildException : Exception
{
    public CannotBuildException(string message) : base(message)
    {
        
    }
}