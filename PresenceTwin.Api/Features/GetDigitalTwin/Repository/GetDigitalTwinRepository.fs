module PresenceTwin.Api.Features.GetDigitalTwin.Repository.GetDigitalTwinRepository

open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Store.IKeyValueStore

type IGetDigitalTwinRepository =
    abstract Get: deviceId: string -> DigitalTwinEntity

type GetDigitalTwinRepository(store: IKeyValueStore) =
    interface IGetDigitalTwinRepository with
        member this.Get(deviceId: string) : DigitalTwinEntity = store.Get<DigitalTwinEntity>(deviceId)
