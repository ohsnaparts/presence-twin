module PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinStateViewModel

open System

type DigitalTwinStateViewModel =
    { LastUpdated: DateTimeOffset
      Properties: Map<string, obj> }

module DigitalTwinStateViewModel =
    let empty: DigitalTwinStateViewModel =
        { LastUpdated = DateTimeOffset.UtcNow
          Properties = Map.empty }


