module PresenceTwin.Api.Features.GetDigitalTwin.Repository.GetDigitalTwinRepository

open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Store.IDigitalTwinStore

type IGetDigitalTwinRepository =
    abstract Get: deviceId: int -> DigitalTwinEntity

type GetDigitalTwinRepository(store: IDigitalTwinStore) =
    interface IGetDigitalTwinRepository with
        member this.Get(deviceId: int) : DigitalTwinEntity = store.Get(deviceId)
