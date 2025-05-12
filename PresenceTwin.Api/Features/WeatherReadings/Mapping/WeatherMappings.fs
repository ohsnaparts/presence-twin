module PresenceTwin.Api.Features.WeatherReadings.Mapping.WeatherMappings

open PresenceTwin.Api.Features.WeatherReadings.ViewModels.TemperatureViewModel
open PresenceTwin.Api.models.Temperature
open PresenceTwin.Api.models.WeatherReading
open PresenceTwin.Features.WeatherReadings.ViewModels.WeatherReadingViewModel

module TemperatureMapping =
    let toViewModel (temperature: Temperature) : TemperatureViewModel =
        TemperatureViewModel(temperature.Celsius)

    let toDomain (viewModel: TemperatureViewModel) : Temperature = Temperature(viewModel.Celsius)

module WeatherReadingMapping =
    let toViewModel (reading: WeatherReading) : WeatherReadingViewModel =
        WeatherReadingViewModel(TemperatureMapping.toViewModel reading.Temperature, reading.TakenAt)
    
    let toViewModels (readings: WeatherReading array) : WeatherReadingViewModel array =
        readings |> Array.map toViewModel

    let toDomain (viewModel: WeatherReadingViewModel) : WeatherReading =
        WeatherReading(TemperatureMapping.toDomain viewModel.Temperature, viewModel.takenAt)
    
    
