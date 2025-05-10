module PresenceTwin.Api.Tests.WeatherForecastApiTests

open System.Text.Json
open FluentAssertions
open Microsoft.AspNetCore.Mvc.Testing
open PresenceTwin.Api.Startup
open Xunit


type public WeatherForecastApiTests() =
    let factory = new WebApplicationFactory<Startup>()
    let client = factory.CreateClient()

    [<Fact>]
    member _.``My test``() =
        async {
            let! response = client.GetAsync("/weatherforecast") |> Async.AwaitTask
            response.EnsureSuccessStatusCode() |> ignore

            let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            Assert.NotEmpty(content)

            let forecasts = JsonSerializer.Deserialize<float[]>(content)

            forecasts
                .Should()
                .AllSatisfy(fun temp -> temp.Should().BeGreaterThanOrEqualTo(0) |> ignore)
                |> ignore
        }
