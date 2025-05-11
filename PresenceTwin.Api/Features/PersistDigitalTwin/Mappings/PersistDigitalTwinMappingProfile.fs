module PresenceTwin.Api.Features.PersistDigitalTwin.Mappings.PersistDigitalTwinMappingProfile

open AutoMapper
open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Models.DigitalTwin
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

type public PersistDigitalTwinMappingProfile() =
    inherit Profile()
    
    do
        base.CreateMap<DigitalTwinViewModel, DigitalTwin>() |> ignore
        base.CreateMap<DigitalTwinViewModel, DigitalTwinEntity>() |> ignore