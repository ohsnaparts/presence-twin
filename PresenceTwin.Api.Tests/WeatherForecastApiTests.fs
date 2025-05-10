module PresenceTwin.Api.Tests.WeatherForecastApiTests

open System.Text.Json
open System.Threading.Tasks
open FluentAssertions
open Microsoft.AspNetCore.Mvc.Testing
open PresenceTwin.Api.Startup
open PresenceTwin.Api.WeatherService
open PresenceTwin.Api.models.WeatherReading
open Xunit


type public WeatherForecastApiTests() =
    let factory = new WebApplicationFactory<Startup>()
    let client = factory.CreateClient()

    [<Fact>]
    member public this.``My test``() =
        async {
            let! forecasts = this.getWeatherReadingsAsync ()

            forecasts.Should().HaveCount(5) |> ignore

            forecasts
                .Should()
                .AllSatisfy(fun f -> f.Temperature.Celsius.Should().BeGreaterThan(0) |> ignore)
            |> ignore
        }
    
    member private this.deserializeJson<'T>(json: string) : 'T =
        let jsonSerializerOptions = JsonSerializerOptions()
        jsonSerializerOptions.PropertyNameCaseInsensitive <- true
        JsonSerializer.Deserialize<'T>(json, jsonSerializerOptions)

    member private this.getWeatherReadingsAsync() : Async<WeatherReading array> =
        async {
            let! response = client.GetAsync("/weatherforecast") |> Async.AwaitTask
            response.EnsureSuccessStatusCode() |> ignore

            let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            Assert.NotEmpty(content)

            // in async blocks we need to explicitly return the result
            return this.deserializeJson<WeatherReading array> (content)
        }
