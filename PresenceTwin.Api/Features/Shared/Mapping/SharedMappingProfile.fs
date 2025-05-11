module PresenceTwin.Api.Features.Shared.Mapping.SharedMappingProfile

open AutoMapper
open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Models.DigitalTwin

type public SharedMappingProfile() =
    inherit Profile()

    do base.CreateMap<DigitalTwin, DigitalTwinEntity>() |> ignore
