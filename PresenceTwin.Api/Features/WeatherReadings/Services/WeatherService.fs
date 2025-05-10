module PresenceTwin.Api.WeatherService

open System
open PresenceTwin.Api.models.Temperature
open PresenceTwin.Api.models.WeatherReading

type public IWeatherService =
    abstract member GetTemperatureReading: unit -> WeatherReading

type public WeatherService() =
    interface IWeatherService with
        member this.GetTemperatureReading() : WeatherReading =
            let celsius = Random.Shared.NextDouble() * 40.0
            let temperature = Temperature(celsius)
            WeatherReading(temperature, DateTime.Now)
