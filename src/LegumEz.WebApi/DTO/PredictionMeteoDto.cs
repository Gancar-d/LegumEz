namespace LegumEz.WebApi.DTO;

public record PredictionMeteoDto(
    TemperatureDto TemperatureMinimale,
    TemperatureDto TemperatureMaximale,
    TemperatureDto TemperatureMoyenne,
    DateTime Jour);