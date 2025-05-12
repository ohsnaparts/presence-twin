module PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity

open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinStateRecord

type DigitalTwinEntity =
    { DeviceId: int
      Reported: DigitalTwinStateRecord
      Desired: DigitalTwinStateRecord }

module DigitalTwinEntity =
    let create (deviceId: int) : DigitalTwinEntity =
        { DeviceId = deviceId
          Reported = DigitalTwinStateRecord.empty
          Desired = DigitalTwinStateRecord.empty }
