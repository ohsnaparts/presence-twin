module PresenceTwin.Api.Features.WeatherReadings.Mapping.WeatherMappingsProfile

open AutoMapper
open PresenceTwin.Api.Features.WeatherReadings.ViewModels.TemperatureViewModel
open PresenceTwin.Api.models.Temperature
open PresenceTwin.Api.models.WeatherReading
open PresenceTwin.Features.WeatherReadings.ViewModels.WeatherReadingViewModel

type public WeatherMappingsProfile() =
    inherit Profile()
    
    do
        base.CreateMap<WeatherReading, WeatherReadingViewModel>() |> ignore
        base.CreateMap<Temperature, TemperatureViewModel>() |> ignore
