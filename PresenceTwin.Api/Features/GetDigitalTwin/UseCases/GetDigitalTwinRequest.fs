module PresenceTwin.Api.Features.GetDigitalTwin.UseCases.GetDigitalTwinRequest

open System.Threading.Tasks
open MediatR
open PresenceTwin.Api.Features.GetDigitalTwin.Repository.GetDigitalTwinRepository
open PresenceTwin.Api.Features.Shared.Mapping.SharedMappings
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

// TODO: split request from handler (all)

type public GetDigitalTwinRequest(deviceId: int) =
    member val DeviceId: int = deviceId with get
    interface IRequest<DigitalTwinViewModel>


type public GetDigitalTwinRequestHandler(repository: IGetDigitalTwinRepository) =
    interface IRequestHandler<GetDigitalTwinRequest, DigitalTwinViewModel> with
        member this.Handle
            (request: GetDigitalTwinRequest, cancellationToken: System.Threading.CancellationToken)
            : System.Threading.Tasks.Task<DigitalTwinViewModel> =
            let twin =
                repository.Get(request.DeviceId) |> DigitalTwinEntityMapping.toViewModel

            Task.FromResult(twin)
