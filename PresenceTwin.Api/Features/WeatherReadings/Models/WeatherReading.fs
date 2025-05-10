module PresenceTwin.Api.models.WeatherReading

open System
open PresenceTwin.Api.models.Temperature

type public WeatherReading(temperature: Temperature, takenAt: DateTime) =
    member val TakenAt = takenAt with get, set
    member val Temperature = temperature with get, set
    
    new() = WeatherReading(Temperature(0.0), DateTime.MinValue)

