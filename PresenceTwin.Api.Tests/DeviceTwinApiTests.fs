module PresenceTwin.Api.Tests.DeviceTwinApiTests

open System
open System.Collections.Generic
open System.Net.Http.Json
open System.Threading.Tasks
open FluentAssertions
open Microsoft.AspNetCore.Mvc.Testing
open PresenceTwin.Api.Features.Shared.ViewModels
open PresenceTwin.Api.Features.Shared.ViewModels.DigitalTwinViewModel
open PresenceTwin.Api.Startup
open Xunit

type public DeviceTwinApiTests() =
    let factory = new WebApplicationFactory<Startup>()
    let client = factory.CreateClient()

    [<Fact>]
    member public this.``Persists and retrieves a digital twin``() =
        async
            {
                let mutable twin = DigitalTwinViewModel()
                twin.DeviceId <- Guid.NewGuid().ToString()
                twin.Desired <- Dictionary<string, obj>()
                twin.Reported <- Dictionary<string, obj>()
                
                let! _ = this.persistDigitalTwin(twin) |> Async.AwaitTask
                let! actual = this.getDigitalTwin(twin.DeviceId) |> Async.AwaitTask
                
                actual.DeviceId.Should().Be(twin.DeviceId) |> ignore
            }
        |> Async.StartAsTask

    member private this.persistDigitalTwin(twin: DigitalTwinViewModel) : Task<unit> =
        async {
            let! response = client.PutAsJsonAsync("/PersistDigitalTwin", twin) |> Async.AwaitTask
            response.EnsureSuccessStatusCode() |> ignore
        }
        |> Async.StartAsTask

    member private this.getDigitalTwin(deviceId: string) : Task<DigitalTwinViewModel> =
        async {
            let! response =
                client.GetFromJsonAsync<DigitalTwinViewModel>($"/ReadDigitalTwin?deviceId={deviceId}")
                |> Async.AwaitTask

            return response
        } |> Async.StartAsTask
