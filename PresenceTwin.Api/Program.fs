namespace PresenceTwin.Api

#nowarn "20"

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Reflection
open System.Threading.Tasks
open Autofac
open Autofac.Extensions.DependencyInjection
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

// static class of error codes
type ExitCode =
    static member Success = 0
    static member Failure = 1


module Program =
    
    [<EntryPoint>]
    let main args =
        let mutable exitCode = ExitCode.Success

        try
            Host
                .CreateDefaultBuilder(args)
                .UseServiceProviderFactory(AutofacServiceProviderFactory()) // TODO: how does this work
                .ConfigureWebHostDefaults(fun webBuilder -> webBuilder.UseStartup<PresenceTwin.Api.Startup.Startup>() |> ignore)
                .Build()
                .Run()
        with ex ->
            printfn $"An error occurred: {ex.Message}"
            // assign exit code (we can not return from within with as it expects a unit / void)
            exitCode <- ExitCode.Failure

        exitCode
