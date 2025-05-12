module PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinStateRecord

open System

type DigitalTwinStateRecord =
    { LastUpdated: DateTimeOffset
      Properties: Map<string, obj> }

module DigitalTwinStateRecord =
    let empty =
        { LastUpdated = DateTimeOffset.UtcNow
          Properties = Map.empty }

