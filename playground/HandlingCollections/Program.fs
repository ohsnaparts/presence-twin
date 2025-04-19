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
    let studentScoresCsvFilePath = "./StudentScores.txt"
    let mutable errorCode = ErrorCodes.Success

    try
        let students = StudentCsvParser.parse studentScoresCsvFilePath
        for student in students do
            printfn "%s" (student.ToString())
    with
    | :? FileNotFoundException as ex ->
        printfn $"Unable to process student scores: {ex.Message}"
        errorCode <- ErrorCodes.FileNotFound
    | ex ->
        printfn $"An unknown exception has been thrown: {ex.Message}"
        errorCode <- ErrorCodes.UnhandledError

    errorCode
