module PresenceTwin.Api.Features.WeatherReadings.ViewModels.TemperatureViewModel

type public TemperatureViewModel(celsius: float) =
    member val public Celsius = celsius with get, set
    
    new() = TemperatureViewModel(0);


