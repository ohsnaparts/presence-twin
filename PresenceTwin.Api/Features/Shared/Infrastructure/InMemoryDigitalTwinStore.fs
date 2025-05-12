module PresenceTwin.Api.Features.Shared.Store.InMemoryDigitalTwinStore

open System.Collections.Generic
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Extensions.ObjectExtensions
open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Store.IDigitalTwinStore

type public InMemoryDigitalTwinStore(logger: ILogger<InMemoryDigitalTwinStore>) =
    let store = Dictionary<int, DigitalTwinEntity>()

    interface IDigitalTwinStore with
        member this.Set (deviceId: int) (twin: DigitalTwinEntity) : unit =
            logger.LogDebug(
                "Persisting item with key:{key} and value:{value} to the key value store",
                deviceId,
                ObjectUtils.toJson(twin)
            )

            store.[deviceId] <- twin

        member this.Get(deviceId: int) : DigitalTwinEntity = store.[deviceId]
