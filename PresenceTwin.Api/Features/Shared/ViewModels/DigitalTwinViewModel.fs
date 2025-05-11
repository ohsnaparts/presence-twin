module PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

open System.Collections.Generic

type DigitalTwinViewModel() =
    member val DeviceId: string = "" with get,set
    member val Reported: IDictionary<string, obj> = null with get,set
    member val Desired: IDictionary<string, obj> = null with get,set
