module PresenceTwin.Api.Features.Shared.InMemoryStore

open System.Collections.Generic
open PresenceTwin.Api.Features.Shared.IKeyValueStore

type public InMemoryKeyValueStore() =
    let store = Dictionary<string, obj>()

    interface IKeyValueStore with
        member this.Set (key: string) (value: obj) : unit = store.[key] <- value

        member this.Get<'T>(key: string) : 'T = store.[key] :?> 'T
