module PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity

open System.Collections.Generic

type public DigitalTwinEntity(id: string) =
    member val Id: string = id with get, set
    member val Reported: IDictionary<string, obj> = Dictionary<string, obj>() with get, set
    member val Desired: IDictionary<string, obj> = Dictionary<string, obj>() with get, set
    
    new() = DigitalTwinEntity("")
