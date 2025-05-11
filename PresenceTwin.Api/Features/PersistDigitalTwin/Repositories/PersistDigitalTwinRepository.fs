module PresenceTwin.Api.Features.PersistDigitalTwin.Repositories.PersistDigitalTwinRepository

open PresenceTwin.Api.Extensions.ObjectExtensions
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Store.IKeyValueStore

type public IPersistDigitalTwinRepository =
    abstract member Set: twin: DigitalTwinEntity -> unit

type public PersistDigitalTwinRepository(logger: ILogger<PersistDigitalTwinRepository>, store: IKeyValueStore) =
    interface IPersistDigitalTwinRepository with
        member this.Set (twin: DigitalTwinEntity) : unit =
            logger.LogDebug("Persisting entity with Id={id} and Value={value}", id, twin.ToJson())
            store.Set twin.DeviceId twin
