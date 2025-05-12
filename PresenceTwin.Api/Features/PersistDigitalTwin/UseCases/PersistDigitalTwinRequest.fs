module PresenceTwin.Api.Features.PersistDigitalTwin.UseCases.PersistDigitalTwinRequest

open System.Threading.Tasks
open MediatR
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.PersistDigitalTwin.Repositories.PersistDigitalTwinRepository
open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Mapping.SharedMappings
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

type PersistDigitalTwinRequest(twin: DigitalTwinViewModel) =
    member val Twin = twin with get
    interface IRequest

type PersistDigitalTwinRequestHandler
    (logger: ILogger<PersistDigitalTwinRequestHandler>, repository: IPersistDigitalTwinRepository) =
    interface IRequestHandler<PersistDigitalTwinRequest> with
        member this.Handle
            (request: PersistDigitalTwinRequest, cancellationToken: System.Threading.CancellationToken)
            : System.Threading.Tasks.Task =
            request.Twin |> DigitalTwinViewModelMapping.toEntity |> repository.Set
            Task.CompletedTask
