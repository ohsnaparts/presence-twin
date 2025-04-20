// ReSharper disable FSharpInterpolatedString
open StudentProcessing.Optional
open StudentProcessing.StudentCsvParser
open System.IO

type ErrorCodes =
    static member Success = 0
    static member FileNotFound = 2
    static member UnhandledError = 1

let ensureFile (filePath: string) : unit =
    if (not (File.Exists(filePath))) then
        raise (System.IO.FileNotFoundException("the file can not be found.", filePath))

[<EntryPoint>]
let main (args: string[]) : int =
    let studentScoresCsvFilePath = "./StudentScores.csv"
    let mutable errorCode = ErrorCodes.Success
    // to explore generics, I created my own version of `option`
    let maxLines: Optional<int> = 
        match args with
        | [| _; maxLines |] -> Something(int maxLines)
        | _ -> Nothing

    try
        StudentCsvParser.parse studentScoresCsvFilePath maxLines 
        |> Array.sortBy (fun s -> s.Average.Value)
        |> Array.iter (printfn "%O")
        // https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/plaintext-formatting
    with
    | :? FileNotFoundException as ex ->
        printfn $"Unable to process student scores: {ex.Message}"
        errorCode <- ErrorCodes.FileNotFound
    | ex ->
        printfn $"An unknown exception has been thrown: {ex.Message}"
        errorCode <- ErrorCodes.UnhandledError

    errorCode
