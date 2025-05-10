module PresenceTwin.Api.Startup

open System.Reflection
open Autofac
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open PresenceTwin.Api.WeatherForecast

type Startup() =
    member _.ConfigureServices(services: IServiceCollection) : unit = services.AddControllers().AddControllersAsServices() |> ignore

    member _.ConfigureContainer(builder: ContainerBuilder) : unit =
        builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly())
        |> ignore

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) : unit =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseHttpsRedirection() |> ignore        
        app.UseAuthorization() |> ignore
        app.UseRouting() |> ignore

        app.UseEndpoints(fun endpoints -> endpoints.MapControllers() |> ignore)
        |> ignore
