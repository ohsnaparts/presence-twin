module PresenceTwin.Features.WeatherReadings.ViewModels.WeatherReadingViewModel

open System
open PresenceTwin.Api.Features.WeatherReadings.ViewModels.TemperatureViewModel

type public WeatherReadingViewModel(temperature: TemperatureViewModel, takenAt: DateTime) =
    member val public Temperature = temperature with get, set
    member val public takenAt = takenAt with get, set
    
    new() = WeatherReadingViewModel(null, DateTime.MinValue)