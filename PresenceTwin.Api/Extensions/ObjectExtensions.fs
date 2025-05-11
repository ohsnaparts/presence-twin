module PresenceTwin.Api.Extensions.ObjectExtensions

open System.Runtime.CompilerServices
open System.Text.Json


[<Extension>]
type ObjectExtensions =
    [<Extension>]
    static member inline ToJson(o: obj) =
        let jsonSerializerOptions = JsonSerializerOptions()
        jsonSerializerOptions.PropertyNameCaseInsensitive <- true
        JsonSerializer.Serialize(o, jsonSerializerOptions)
