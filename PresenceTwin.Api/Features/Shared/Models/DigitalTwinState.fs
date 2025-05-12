module PresenceTwin.Api.Features.Shared.Models.DigitalTwinState

open System

type DigitalTwinState =
    { LastUpdated: DateTimeOffset
      Properties: Map<string, obj> }

module DigitalTwinState =
    let empty =
        { LastUpdated = DateTimeOffset.UtcNow
          Properties = Map.empty }
