module PresenceTwin.IoC.RootModule

open Autofac
open PresenceTwin.Api.WeatherService

type public RootModule() =
    inherit Module()

    override this.Load(builder: ContainerBuilder) : unit =
        builder.RegisterType<WeatherService>().As<IWeatherService>().SingleInstance()
        |> ignore
