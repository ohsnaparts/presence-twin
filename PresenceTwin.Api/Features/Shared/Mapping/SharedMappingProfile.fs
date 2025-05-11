module PresenceTwin.Api.Features.Shared.Mapping.SharedMappingProfile

open AutoMapper
open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Models.DigitalTwin
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

type public SharedMappingProfile() =
    inherit Profile()

    do
        base.CreateMap<DigitalTwin, DigitalTwinEntity>() |> ignore
        base.CreateMap<DigitalTwinViewModel, DigitalTwin>() |> ignore
        base.CreateMap<DigitalTwinEntity, DigitalTwinViewModel>() |> ignore
        base.CreateMap<DigitalTwinViewModel, DigitalTwinEntity>() |> ignore
