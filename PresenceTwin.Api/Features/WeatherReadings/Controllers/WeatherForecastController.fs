namespace PresenceTwin.Api.Controllers

open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.WeatherReadings.Mapping.WeatherMappings
open PresenceTwin.Api.Features.WeatherReadings.UserCases.GetWeatherReadingsRequest
open PresenceTwin.Features.WeatherReadings.ViewModels.WeatherReadingViewModel

[<ApiController>]
[<Route("[controller]")>]
type public WeatherForecastController
    (logger: ILogger<WeatherForecastController>, mediatr: MediatR.IMediator) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() : Task<WeatherReadingViewModel array> =
        async {
            let! readings = mediatr.Send(GetWeatherReadingsQuery()) |> Async.AwaitTask
            let viewModels = readings |> WeatherReadingMapping.toViewModels
            return viewModels
        }
        |> Async.StartAsTask
