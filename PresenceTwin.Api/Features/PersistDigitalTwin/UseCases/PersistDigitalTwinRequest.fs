module PresenceTwin.Api.Features.PersistDigitalTwin.UseCases.PersistDigitalTwinRequest

open System.Threading.Tasks
open MediatR
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.Shared.DigitalTwin

type PersistDigitalTwinRequest(twin: DigitalTwin) =
    member val Twin = twin with get
    interface IRequest
    
type PersistDigitalTwinRequestHandler(logger: ILogger<PersistDigitalTwinRequestHandler>) =
    interface IRequestHandler<PersistDigitalTwinRequest> with
        member this.Handle (request: PersistDigitalTwinRequest, cancellationToken: System.Threading.CancellationToken): System.Threading.Tasks.Task =
            logger.LogDebug("{context}: {message}", this.GetType().Name, $"Handle {request.Twin}");            Task.CompletedTask