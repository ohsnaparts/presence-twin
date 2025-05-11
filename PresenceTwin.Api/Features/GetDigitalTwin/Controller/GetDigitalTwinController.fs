namespace PresenceTwin.Api.Controllers

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.WeatherReadings.ViewModels.TemperatureViewModel
open PresenceTwin.Features.WeatherReadings.ViewModels.WeatherReadingViewModel


[<ApiController>]
[<Route("[controller]")>]
type public ReadDigitalTwinController(logger: ILogger<ReadDigitalTwinController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() : Task<WeatherReadingViewModel> =
        Task.FromResult(WeatherReadingViewModel(TemperatureViewModel(12.42), DateTime.Now))
