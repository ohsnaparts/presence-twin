module CardGame.Program

open CardGame.Cards

type ErrorCodes =
    static member public Success = 0
    static member public UnhandledError = 1

[<EntryPoint>]
let main args: int =
    try
        Cards.deck
        |> List.groupBy (fun (Card (suit, _)) -> suit)
        |> List.iter (fun (suit, group) -> printfn $"{suit}: {group}")
        ErrorCodes.Success
    with
    | ex -> 
        printfn $"An unknown exception has been thrown: {ex.Message}"
        ErrorCodes.UnhandledError