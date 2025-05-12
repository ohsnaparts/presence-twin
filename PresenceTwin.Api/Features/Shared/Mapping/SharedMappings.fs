module PresenceTwin.Api.Features.Shared.Mapping.SharedMappings

open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinEntity
open PresenceTwin.Api.Features.Shared.Infrastructure.DigitalTwinStateRecord
open PresenceTwin.Api.Features.Shared.Models.DigitalTwin
open PresenceTwin.Api.Features.Shared.Models.DigitalTwinState
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinStateViewModel
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel

module DigitalTwinStateMapping =
    let toEntity (state: DigitalTwinState) : DigitalTwinStateRecord =
        { LastUpdated = state.LastUpdated
          Properties = state.Properties }

module DigitalTwinStateViewModelMapping =
    let toRecord (viewModel: DigitalTwinStateViewModel) : DigitalTwinStateRecord =
        { LastUpdated = viewModel.LastUpdated
          Properties = viewModel.Properties }

module DigitalTwinMapping =
    let toEntity (domain: DigitalTwin) : DigitalTwinEntity =
        { DeviceId = domain.DeviceId
          Reported = domain.Reported |> DigitalTwinStateMapping.toEntity
          Desired = domain.Desired |> DigitalTwinStateMapping.toEntity }

module DigitalTwinStateRecordMapping =
    let toViewModel (record: DigitalTwinStateRecord) : DigitalTwinStateViewModel =
        { LastUpdated = record.LastUpdated
          Properties = record.Properties }

    let toDomain (record: DigitalTwinStateRecord) : DigitalTwinState =
        { LastUpdated = record.LastUpdated
          Properties = record.Properties }


module DigitalTwinViewModelMapping =
    let toEntity (viewModel: DigitalTwinViewModel) : DigitalTwinEntity =
        { DeviceId = viewModel.DeviceId
          Reported = viewModel.Reported |> DigitalTwinStateViewModelMapping.toRecord
          Desired = viewModel.Desired |> DigitalTwinStateViewModelMapping.toRecord }

module DigitalTwinEntityMapping =
    let toViewModel (entity: DigitalTwinEntity) : DigitalTwinViewModel =
        { DeviceId = entity.DeviceId
          Reported = entity.Reported |> DigitalTwinStateRecordMapping.toViewModel
          Desired = entity.Desired |> DigitalTwinStateRecordMapping.toViewModel }

    let toDomain (entity: DigitalTwinEntity) : DigitalTwin =
        { DeviceId = entity.DeviceId
          Reported = entity.Reported |> DigitalTwinStateRecordMapping.toDomain
          Desired = entity.Desired |> DigitalTwinStateRecordMapping.toDomain }
