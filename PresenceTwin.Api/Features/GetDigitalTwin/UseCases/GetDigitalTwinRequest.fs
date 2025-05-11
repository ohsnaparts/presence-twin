module PresenceTwin.Api.Features.GetDigitalTwin.UseCases.GetDigitalTwinRequest

open System.Threading.Tasks
open AutoMapper
open MediatR
open PresenceTwin.Api.Features.GetDigitalTwin.Repository.GetDigitalTwinRepository
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

// TODO: split request from handler (all)

type public GetDigitalTwinRequest(deviceId: string) =
    member val DeviceId: string = deviceId with get
    interface IRequest<DigitalTwinViewModel>


type public GetDigitalTwinRequestHandler(repository: IGetDigitalTwinRepository, mapper: IMapper) =
   interface IRequestHandler<GetDigitalTwinRequest, DigitalTwinViewModel> with
         member this.Handle (request: GetDigitalTwinRequest, cancellationToken: System.Threading.CancellationToken): System.Threading.Tasks.Task<DigitalTwinViewModel> =
             let twinEntity = repository.Get(request.DeviceId)
             let twinViewModel = mapper.Map<DigitalTwinViewModel>(twinEntity)
             Task.FromResult(twinViewModel)