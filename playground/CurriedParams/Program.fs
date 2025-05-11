// For more information see https://aka.ms/fsharp-console-apps

// curried parameters
// function parameters which support partial application.
//
// When an argument is supplied, the result is a function that expects any remaining parameters. When all arguments have
// been supplied, the result a result.

type ErrorCodes =
    static member Success = 0
    static member FileNotFound = 2
    static member UnhandledError = 1

let add (a: int) (b: int) : int = a + b
let z = add // int -> int -> int
let d = add 2 // int -> int
let e = d 3 // int
let c = add 2 3 // int (same as e)


let quote (symbol: char) (str: string) = $"{symbol}{str}{symbol}"
// partial application of a curried function
let singleQuote = quote '''
let doubleQuote = quote '"'

[<EntryPoint>]
let main args : int =
    try
        printfn "%s" (singleQuote "It was the best time of my liiiife 🎶")
        printfn "%s" (doubleQuote "It was the best time of my liiiife 🎵")
        ErrorCodes.Success
    with ex ->
        printfn $"An unknown exception has been thrown: {ex.Message}"
        ErrorCodes.UnhandledError
