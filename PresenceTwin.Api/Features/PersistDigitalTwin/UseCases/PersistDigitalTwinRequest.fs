module PresenceTwin.Api.Features.PersistDigitalTwin.UseCases.PersistDigitalTwinRequest

open System.Text.Json
open System.Threading.Tasks
open AutoMapper
open MediatR
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.Shared.Models.DigitalTwin
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

type PersistDigitalTwinRequest(twin: DigitalTwinViewModel) =
    member val Twin = twin with get
    interface IRequest

type PersistDigitalTwinRequestHandler(logger: ILogger<PersistDigitalTwinRequestHandler>, mapper: IMapper) =
    interface IRequestHandler<PersistDigitalTwinRequest> with
        member this.Handle
            (request: PersistDigitalTwinRequest, cancellationToken: System.Threading.CancellationToken)
            : System.Threading.Tasks.Task =
                let domainTwin = mapper.Map<DigitalTwin>(request.Twin)
                let json = JsonSerializer.Serialize(domainTwin, JsonSerializerOptions())
                logger.LogDebug("{context}: {message}", this.GetType().Name, $"Handle {json}")
                Task.CompletedTask