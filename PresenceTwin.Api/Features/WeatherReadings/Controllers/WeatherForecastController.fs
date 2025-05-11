namespace PresenceTwin.Api.Controllers

open System.Threading.Tasks
open AutoMapper
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.WeatherReadings.UserCases.GetWeatherReadingsRequest
open PresenceTwin.Features.WeatherReadings.ViewModels.WeatherReadingViewModel

[<ApiController>]
[<Route("[controller]")>]
type public WeatherForecastController
    (logger: ILogger<WeatherForecastController>, mediatr: MediatR.IMediator, mapper: IMapper) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() : Task<WeatherReadingViewModel array> =
        async {
            let! readings = mediatr.Send(GetWeatherReadingsQuery()) |> Async.AwaitTask
            // TODO: refactor use case layer to return viewmodels
            let viewModels = mapper.Map<WeatherReadingViewModel array>(readings)
            return viewModels
        }
        |> Async.StartAsTask
