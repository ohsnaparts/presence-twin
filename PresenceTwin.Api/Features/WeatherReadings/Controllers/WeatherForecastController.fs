namespace PresenceTwin.Api.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open AutoMapper
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.WeatherReadings.UserCases
open PresenceTwin.Api.Features.WeatherReadings.UserCases.GetWeatherReadingsQuery
open PresenceTwin.Api.WeatherService
open PresenceTwin.Api.models.WeatherReading
open PresenceTwin.Features.WeatherReadings.ViewModels
open PresenceTwin.Features.WeatherReadings.ViewModels.WeatherReadingViewModel

[<ApiController>]
[<Route("[controller]")>]
type public WeatherForecastController(logger: ILogger<WeatherForecastController>, mediatr: MediatR.IMediator, mapper: IMapper) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() : Task<WeatherReadingViewModel array> =
        async {
            let! readings = mediatr.Send(GetWeatherReadingsQuery()) |> Async.AwaitTask
            let viewModels = mapper.Map<WeatherReadingViewModel array>(readings);
            return viewModels
        }
        |> Async.StartAsTask
