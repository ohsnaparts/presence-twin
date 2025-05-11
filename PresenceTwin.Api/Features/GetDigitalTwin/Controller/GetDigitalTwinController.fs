namespace PresenceTwin.Api.Controllers

open System.Threading.Tasks
open MediatR
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.GetDigitalTwin.UseCases.GetDigitalTwinRequest
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel


[<ApiController>]
[<Route("[controller]")>]
type public ReadDigitalTwinController(logger: ILogger<ReadDigitalTwinController>, mediator: IMediator) =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get(deviceId: string) : Task<DigitalTwinViewModel> =
        async {
            let! twin = mediator.Send(GetDigitalTwinRequest(deviceId)) |> Async.AwaitTask
            return twin
        }
        |> Async.StartAsTask
