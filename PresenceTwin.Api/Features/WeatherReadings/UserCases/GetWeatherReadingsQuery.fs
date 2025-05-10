module PresenceTwin.Api.Features.WeatherReadings.UserCases.GetWeatherReadingsQuery

open MediatR
open PresenceTwin.Api.WeatherService
open PresenceTwin.Api.models
open PresenceTwin.Api.models.WeatherReading
open System.Threading.Tasks

type GetWeatherReadingsQuery() =
    interface IRequest<WeatherReading[]>

type GetWeatherReadingsHandler(weatherService: IWeatherService) =
    interface IRequestHandler<GetWeatherReadingsQuery, WeatherReading[]> with
        member this.Handle
            (request: GetWeatherReadingsQuery, cancellationToken: System.Threading.CancellationToken)
            : Task<WeatherReading array> =
            let temperature = weatherService.GetTemperatureReading()
            let temperatures = [| temperature |]
            Task.FromResult(temperatures)
