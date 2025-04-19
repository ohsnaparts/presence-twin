// ReSharper disable FSharpInterpolatedString

module HandlingCollections.Student

type Student(name: string, id: string, scores: float[]) =
    let calculateAverage () = scores |> Array.average
    let calculateSum () = scores |> Array.sum
    let calculateMin () = scores |> Array.min
    let calculateMax () = scores |> Array.max

    let _average: Lazy<float> = lazy (calculateAverage ())
    let _sum: Lazy<float> = lazy (calculateSum ())
    let _min: Lazy<float> = lazy (calculateMin ())
    let _max: Lazy<float> = lazy (calculateMax ())

    member val Name = name with get
    member val Id = id with get
    member val Scores = scores with get
    member this.Average = _average
    member this.Sum = _sum
    member this.Min = _min
    member this.Max = _max

    override this.ToString() : string =
        sprintf
            "Scores of student %s range between %f and %f (mean %f)"
            this.Name
            this.Min.Value
            this.Max.Value
            this.Average.Value
