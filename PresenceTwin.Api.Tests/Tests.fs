module Tests

open System
open Microsoft.AspNetCore.Mvc.Testing
open PresenceTwin.Api.Startup
open Xunit

//
// type public WeatherForecastApiTests() =
//     let factory = new WebApplicationFactory<Startup>()
//     let client = factory.CreateClient()
//
//     [<Fact>]
//     member _.``My test``() = 
//             // let! response = client.GetAsync("/weatherforecast") |> Async.AwaitTask
//             // response.EnsureSuccessStatusCode() |> ignore
//             //
//             // let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
//             Assert.True(true);
//

[<Fact>]
let ``My test``() = 
    // let! response = client.GetAsync("/weatherforecast") |> Async.AwaitTask
    // response.EnsureSuccessStatusCode() |> ignore
    //
    // let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
    Assert.True(true);