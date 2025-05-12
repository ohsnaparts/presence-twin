module PresenceTwin.Api.Features.Shared.Store.IDigitalTwinStore

open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity

type public IDigitalTwinStore =
    abstract member Set: deviceId: int -> twin: DigitalTwinEntity -> unit
    abstract member Get : deviceId: int  -> DigitalTwinEntity
