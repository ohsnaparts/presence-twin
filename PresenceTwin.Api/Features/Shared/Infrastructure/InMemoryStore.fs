module PresenceTwin.Api.Features.Shared.Store.InMemoryStore

open System.Collections.Generic
open System.Text.Json
open Microsoft.Extensions.Logging
open PresenceTwin.Api.Extensions.ObjectExtensions
open PresenceTwin.Api.Features.Shared.Store.IKeyValueStore

type public InMemoryKeyValueStore(logger: ILogger<InMemoryKeyValueStore>) =
    let store = Dictionary<string, obj>()

    interface IKeyValueStore with
        member this.Set (key: string) (value: obj) : unit =
            logger.LogDebug("Persisting item with key:{key} and value:{value} to the key value store", key, value.ToJson())
            store.[key] <- value

        member this.Get<'T>(key: string) : 'T = store.[key] :?> 'T
