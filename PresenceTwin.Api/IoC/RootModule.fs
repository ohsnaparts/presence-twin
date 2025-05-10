module PresenceTwin.IoC.RootModule

open Autofac
open PresenceTwin.Api.Features.Shared.IKeyValueStore
open PresenceTwin.Api.Features.Shared.InMemoryStore
open PresenceTwin.Api.WeatherService

type public RootModule() =
    inherit Module()

    override this.Load(builder: ContainerBuilder) : unit =
        builder.RegisterType<WeatherService>().As<IWeatherService>().SingleInstance()
        |> ignore

        builder
            .RegisterType<InMemoryKeyValueStore>()
            .As<IKeyValueStore>()
            .SingleInstance()
        |> ignore
