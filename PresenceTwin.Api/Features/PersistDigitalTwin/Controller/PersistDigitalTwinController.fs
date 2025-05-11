namespace PresenceTwin.Api.Controllers

open MediatR
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.PersistDigitalTwin.UseCases.PersistDigitalTwinRequest
open PresenceTwin.Api.Features.Shared.DigitalTwin

[<ApiController>]
[<Route("[controller]")>]
type public PersistDigitalTwinController(logger: ILogger<PersistDigitalTwinController>, mediator: IMediator) =
    inherit ControllerBase()

    [<HttpPut>]
    member this.Persist(twin: DigitalTwin) =
        async {
            let! _ = mediator.Send(PersistDigitalTwinRequest(twin)) |> Async.AwaitTask
            return OkResult()
        }
        |> Async.StartAsTask
