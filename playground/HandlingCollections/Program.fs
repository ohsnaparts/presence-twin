// ReSharper disable FSharpInterpolatedString

open HandlingCollections
open HandlingCollections.StudentCsvParser
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

    try
        StudentCsvParser.parse studentScoresCsvFilePath
        |> Array.sortByDescending (fun s -> s.Average.Value)
        |> Array.iter (fun s -> printfn $"{s}")
    with
    | :? FileNotFoundException as ex ->
        printfn $"Unable to process student scores: {ex.Message}"
        errorCode <- ErrorCodes.FileNotFound
    | ex ->
        printfn $"An unknown exception has been thrown: {ex.Message}"
        errorCode <- ErrorCodes.UnhandledError

    errorCode
