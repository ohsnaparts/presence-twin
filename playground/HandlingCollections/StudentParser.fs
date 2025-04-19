namespace HandlingCollections.StudentCsvParser

open System
open System.IO
open HandlingCollections.Student
open Microsoft.FSharp.Core

type StudentCsvParser() =
    static let NameSeparator = ","
    static let ColumnSeparator = "\t"

    static let tryParseFloat (value: string) : option<float> =
        match Double.TryParse value with
        | true, i -> Some i
        | _ -> None

    static let splitName (name: string) : (string * string) =
        let elements = name.Split(NameSeparator)

        if elements.Length <> 2 then
            raise (
                ArgumentException(
                    $"the name [{name}] is not in the correct format [<Surname>{NameSeparator}<GiveName>]"
                )
            )

        (elements.[0].Trim(), elements.[1].Trim())

    static let convertRowToStudent (row: string) (fallbackScore: float) : Student =
        let elements = row.Split(ColumnSeparator)

        let scores =
            elements
            |> Array.skip 2
            |> Array.map (fun s -> tryParseFloat s |> Option.defaultValue fallbackScore)

        let (surname, givenName) = splitName elements.[0]
        Student(surname, givenName, elements.[1], scores)


    static member private ensureFileExists(filePath: string) : unit =
        if (not (File.Exists(filePath))) then
            raise (System.IO.FileNotFoundException("the file can not be found.", filePath))

    static member public parse(filePath) : Student[] =
        StudentCsvParser.ensureFileExists filePath

        File.ReadAllLines filePath
        |> Array.skip 1 // header
        |> Array.map (fun l -> convertRowToStudent l 50)
