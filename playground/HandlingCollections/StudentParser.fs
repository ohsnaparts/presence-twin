namespace HandlingCollections.StudentCsvParser

open System.IO
open HandlingCollections.Student

type StudentCsvParser() =

    static let convertRowToStudent (row: string) : Student =
        let elements = row.Split("\t")
        Student(elements.[0], elements.[1], elements.[2..] |> Array.map float)

    static member private ensureFileExists(filePath: string) : unit =
        if (not (File.Exists(filePath))) then
            raise (System.IO.FileNotFoundException("the file can not be found.", filePath))

    static member public parse(filePath) : Student[] =
        StudentCsvParser.ensureFileExists filePath

        File.ReadAllLines filePath
        |> Array.skip 1 // header
        |> Array.map convertRowToStudent
