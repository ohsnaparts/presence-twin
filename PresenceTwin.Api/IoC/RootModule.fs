module PresenceTwin.IoC.RootModule

open Autofac
open PresenceTwin.Api.WeatherForecast

type public RootModule() =
    inherit Module()

    override this.Load(builder: ContainerBuilder) : unit =
        builder.RegisterType<WeatherForecast>().As<IWeatherForecast>().SingleInstance()
        |> ignore
