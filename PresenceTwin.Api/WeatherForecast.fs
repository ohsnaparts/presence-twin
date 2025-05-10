module PresenceTwin.Api.WeatherForecast

open System

type public IWeatherForecast =
    abstract member GetTemperatureF: unit -> float

type public WeatherForecast() =
    interface IWeatherForecast with
        member _.GetTemperatureF() =
            let degrees = Random.Shared.NextDouble()
            let fahrenheit = 32.0 + (degrees / 0.5556)
            fahrenheit