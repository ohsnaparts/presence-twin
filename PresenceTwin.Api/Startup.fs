module PresenceTwin.Api.Startup

open System
open System.Reflection
open AutoMapper.Contrib.Autofac.DependencyInjection
open Autofac
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.OpenApi.Models

type Startup() =
    member _.ConfigureServices(services: IServiceCollection) : unit =
        services.AddControllers().AddControllersAsServices() |> ignore

        services.AddMediatR(
            Action<MediatRServiceConfiguration>(fun c ->
                c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()) |> ignore)
        )
        |> ignore

        services.AddSwaggerGen(fun c -> c.SwaggerDoc("v1", OpenApiInfo(Title = "Presence Twin API", Version = "v1")))
        |> ignore

    member _.ConfigureContainer(builder: ContainerBuilder) : unit =
        builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly()) |> ignore
        builder.RegisterAutoMapper(Assembly.GetExecutingAssembly()) |> ignore

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) : unit =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseAuthorization() |> ignore
        app.UseRouting() |> ignore
        app.UseSwagger() |> ignore
        app.UseSwaggerUI() |> ignore

        app.UseEndpoints(fun endpoints -> endpoints.MapControllers() |> ignore)
        |> ignore
