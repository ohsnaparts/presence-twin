module PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinStateViewModel


type DigitalTwinViewModel =
    { DeviceId: int
      Reported: DigitalTwinStateViewModel
      Desired: DigitalTwinStateViewModel }

module DigitalTwinViewModel =
    let create (deviceId: int) =
        { DeviceId = deviceId
          Desired = DigitalTwinStateViewModel.empty
          Reported = DigitalTwinStateViewModel.empty }
