﻿namespace PresenceTwin.Api.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PresenceTwin.Api.WeatherForecast

[<ApiController>]
[<Route("[controller]")>]
type public WeatherForecastController (logger : ILogger<WeatherForecastController>, weatherForecast: IWeatherForecast) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() =
        let rng = System.Random()
        [|
            for index in 0..4 ->
                weatherForecast.GetTemperatureF()
        |]