module PresenceTwin.Api.Features.PersistDigitalTwin.UseCases.PersistDigitalTwinRequest

open System.Threading.Tasks
open AutoMapper
open MediatR
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.PersistDigitalTwin.Repositories.PersistDigitalTwinRepository
open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

type PersistDigitalTwinRequest(twin: DigitalTwinViewModel) =
    member val Twin = twin with get
    interface IRequest

type PersistDigitalTwinRequestHandler
    (logger: ILogger<PersistDigitalTwinRequestHandler>, mapper: IMapper, repository: IPersistDigitalTwinRepository) =
    interface IRequestHandler<PersistDigitalTwinRequest> with
        member this.Handle
            (request: PersistDigitalTwinRequest, cancellationToken: System.Threading.CancellationToken)
            : System.Threading.Tasks.Task =
            let twin = mapper.Map<DigitalTwinEntity>(request.Twin)
            repository.Set twin
            Task.CompletedTask
