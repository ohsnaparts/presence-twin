module PresenceTwin.Api.Features.Shared.Store.IKeyValueStore

type public IKeyValueStore =
    abstract member Set: key: string -> value: obj -> unit
    abstract member Get<'T> : key: string -> 'T
