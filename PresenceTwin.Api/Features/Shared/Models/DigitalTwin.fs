module PresenceTwin.Api.Features.Shared.Models.DigitalTwin

open PresenceTwin.Api.Features.Shared.Models.DigitalTwinState

type DigitalTwin =
    { DeviceId: int
      Reported: DigitalTwinState
      Desired: DigitalTwinState }

module DigitalTwin =
    let create deviceId : DigitalTwin =
        { DeviceId = deviceId
          Reported = DigitalTwinState.empty
          Desired = DigitalTwinState.empty }
