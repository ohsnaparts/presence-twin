// ReSharper disable FSharpInterpolatedString

module StudentProcessing.Student

open StudentProcessing.TestResult

type Student(surname: string, givenName: string, id: string, scores: TestResult[]) =
    let getScore (result: TestResult): float = result.getEffectiveScore()
    let calculateAverage () = scores |> Array.map getScore |> Array.average
    let calculateSum () = scores |> Array.map getScore |> Array.sum
    let calculateMin () = scores |> Array.map getScore |> Array.min
    let calculateMax () = scores |> Array.map getScore |> Array.max

    let _average: Lazy<float> = lazy (calculateAverage ())
    let _sum: Lazy<float> = lazy (calculateSum ())
    let _min: Lazy<float> = lazy (calculateMin ())
    let _max: Lazy<float> = lazy (calculateMax ())

    member val Surname = surname with get
    member val GivenName = givenName with get
    member val Id = id with get
    member val Scores = scores with get
    member this.Average = _average
    member this.Sum = _sum
    member this.Min = _min
    member this.Max = _max

    override this.ToString() : string =
        sprintf
            "Scores of student %s-%s range between %f and %f (mean %f)"
            this.Surname
            this.GivenName
            this.Min.Value
            this.Max.Value
            this.Average.Value
