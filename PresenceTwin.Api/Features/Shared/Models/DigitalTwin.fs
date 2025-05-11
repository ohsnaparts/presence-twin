module PresenceTwin.Api.Features.Shared.Models.DigitalTwin

open System.Collections.Generic

type DigitalTwin(deviceId: string, reported: IDictionary<string, obj>, desired: IDictionary<string, obj>) =
    member val DeviceId: string = deviceId with get,set
    member val Reported: IDictionary<string, obj> = reported with get, set
    member val Desired: IDictionary<string, obj> = desired with get, set