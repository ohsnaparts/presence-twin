module PresenceTwin.IoC.RootModule

open Autofac
open PresenceTwin.Api.Features.GetDigitalTwin.Repository.GetDigitalTwinRepository
open PresenceTwin.Api.Features.PersistDigitalTwin.Repositories.PersistDigitalTwinRepository
open PresenceTwin.Api.Features.Shared.Store.IDigitalTwinStore
open PresenceTwin.Api.Features.Shared.Store.InMemoryDigitalTwinStore
open PresenceTwin.Api.WeatherService

type public RootModule() =
    inherit Module()

    override this.Load(builder: ContainerBuilder) : unit =
        builder.RegisterType<WeatherService>().As<IWeatherService>().SingleInstance()
        |> ignore

        builder
            .RegisterType<InMemoryDigitalTwinStore>()
            .As<IDigitalTwinStore>()
            .SingleInstance()
        |> ignore

        builder
            .RegisterType<PersistDigitalTwinRepository>()
            .As<IPersistDigitalTwinRepository>()
        |> ignore

        builder.RegisterType<GetDigitalTwinRepository>().As<IGetDigitalTwinRepository>()
        |> ignore
