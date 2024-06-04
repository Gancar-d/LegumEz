using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.Culture;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.WebApi.Tests.Builders.Cultures;

public class DomainCultureBuilder
{
    private Guid _id;
    private string _nom;
    private ConditionGermination _conditionGermination;
    private ConditionCroissance _conditionCroissance;

    public DomainCultureBuilder WithRandomId()
    {
        _id = Guid.NewGuid();

        return this;
    }

    public DomainCultureBuilder WithId(Guid id)
    {
        _id = id;

        return this;
    }

    public DomainCultureBuilder WithNom(string nom)
    {
        _nom = nom;

        return this;
    }

    public DomainCultureBuilder WithDefaultValidConditionGermination()
    {
        var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
        var temperatureOptimale = new Temperature(20, UniteTemperature.Celsius);
        var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

        _conditionGermination = new ConditionGermination(
            temperatureMinimale,
            temperatureOptimale,
            tempsDeLevee);

        return this;
    }

    public DomainCultureBuilder WithDefaultValidConditionCroissance()
    {
        var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
        var temperatureOptimale = new Temperature(20, UniteTemperature.Celsius);
        var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);

        _conditionCroissance = new ConditionCroissance(
            temperatureMinimale,
            temperatureOptimale,
            tempsDeCroissance);

        return this;
    }

    public Culture Build()
    {
        return new Culture(
            _id,
            _nom,
            _conditionGermination,
            _conditionCroissance
        );
    }
}