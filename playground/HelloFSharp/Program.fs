// ReSharper disable FSharpInterpolatedString
open System

let greeter (name: string) : unit = printfn $"Hello %s{name}"

let printArgsWithForLoop (args: string[]) : unit =
    for i in 0 .. args.Length - 1 do
        printfn "[Loop] Argument %d: %s" i args.[i]

let printArgsWithIter (args: string[]) : unit =
    let printArg (element: string) : unit = printfn "[Iter] Argument: %s" element
    Array.iter printArg args

let printArgsWithFilterForwardPipe (args: string[]) : unit =
    let isValid (element: string) : bool = not (String.IsNullOrWhiteSpace element)
    let printArg (element: string) : unit = printfn "[Forward Pipe] Argument: %s" element
    let isNoTomato (element: string) : bool = element <> "tomato"

    args
    |> Array.filter isValid
    |> Array.filter isNoTomato
    |> Array.iter printArg

let printArgs (args: string[]) : unit =
    printArgsWithForLoop args
    printfn "-----------------"
    printArgsWithIter args
    printfn "-----------------"
    printArgsWithFilterForwardPipe args
    printfn "-----------------"

// This attribute marks the method as entry point / treat it as main method
[<EntryPoint>]
let myMain argv : int =
    if (argv <> null) then
        printArgs argv

    // The method body is indented as in python
    greeter ("F#")
    // brackets are optional
    greeter "F#"
    // return an integer exit code
    
    let mutable myList = List.Empty
    myList <- 12 :: myList
    
    0
