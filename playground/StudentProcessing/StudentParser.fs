namespace StudentProcessing.StudentCsvParser

open System
open System.IO
open StudentProcessing
open StudentProcessing.Optional
open StudentProcessing.Student
open Microsoft.FSharp.Core
open TestResult

type StudentCsvParser() =
    static let NameSeparator = ","
    static let ColumnSeparator = "\t"

    static let tryParseFloat (value: string) : Option<float> =
        let mutable result: Option<float> = None

        let (parseable, parsed) = Double.TryParse value

        if parseable then
            result <- Some(parsed)
        else
            result <- Some(TestResult.getEffectiveScore (value))

        result

    static let splitName (name: string) : (string * string) =
        let elements = name.Split(NameSeparator)

        match elements with
        | [| surname; givenName |] -> (surname.Trim(), givenName.Trim())
        | [| surname |] -> (surname.Trim(), "(None)")
        | _ ->
            raise (
                ArgumentException(
                    $"the name [{name}] is not in the correct format [<Surname>{NameSeparator}<GiveName>]"
                )
            )
      
    
    static let convertRowToStudent (invalidScoreFallback: TestResult) (row: string) : Student =
        let elements = row.Split(ColumnSeparator)

        let scores =
            elements |> Array.skip 2 |> Array.choose tryParseFloat |> Array.map Scored

        let (surname, givenName) = splitName elements.[0]
        Student(surname, givenName, elements.[1], scores)


    static member private ensureFileExists(filePath: string) : unit =
        if (not (File.Exists(filePath))) then
            raise (System.IO.FileNotFoundException("the file can not be found.", filePath))

    static member public parse (filePath) (maxLines: Optional<int>) : Student[] =
        StudentCsvParser.ensureFileExists filePath
        let lines = File.ReadAllLines filePath

        lines
        |> Array.skip 1 // header
        |> Array.take (Optional.defaultValue (lines.Length - 1) maxLines)
        |> Array.map (convertRowToStudent TestResult.NA)
