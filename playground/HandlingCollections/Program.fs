// ReSharper disable FSharpInterpolatedString

open System.IO

type ErrorCodes =
    static member Success = 0
    static member FileNotFound = 2
    static member UnhandledError = 1

let ensureFile(filePath: string): unit =
    if(not(File.Exists(filePath))) then
        raise (System.IO.FileNotFoundException("the file can not be found.", filePath));

let printStudentCount (filePath: string): unit =
    ensureFile filePath
    let rows = File.ReadAllLines filePath
    let studentCount = (rows |> Array.length) - 1 // -1 because of the header    
    printfn $"Student Count: {studentCount}"

let printMeanStudentScore (filePath: string): unit =
    ensureFile filePath
    let rows = File.ReadAllLines filePath
    
    let printMean (row: string) =
        let elements = row.Split("\t")
        let meanScore = elements |> Array.skip 2 |> Array.averageBy float
        printfn "%s scored on exam %s an average of %f" elements.[0] elements.[1] meanScore 
    
    rows
        |> Array.skip 1
        |> Array.iter printMean
 
let printScoreMinMax (filePath: string): unit =
    ensureFile filePath
    
    let printMinMax (row: string): unit =
        let elements = row.Split("\t")
        let scores = elements |> Array.skip 2 |> Array.map float
        let min = scores |> Array.min
        let max = scores |> Array.max
        printfn "Scores of student %s range between %f and %f" elements.[0] min max
    
    File.ReadAllLines filePath |> Array.skip 1 |> Array.iter printMinMax

let printStudentStatistics(filePath: string): unit =
    printStudentCount filePath
    printfn "---------------------"
    printMeanStudentScore filePath
    printfn "---------------------"
    printScoreMinMax filePath


[<EntryPoint>]
let main (args: string[]) : int =
    let studentScoresCsvFilePath = "./StudentScores.txt"
    let mutable errorCode = ErrorCodes.Success
    
    try
        printStudentStatistics studentScoresCsvFilePath
    with
        :? FileNotFoundException as ex ->
            printfn $"Unable to process student scores: {ex.Message}"
            errorCode <- ErrorCodes.FileNotFound
        | ex ->
            printfn $"An unknown exception has been thrown: {ex.Message}"
            errorCode <- ErrorCodes.UnhandledError
    
    errorCode