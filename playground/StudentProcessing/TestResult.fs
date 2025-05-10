module StudentProcessing.TestResult


// Discriminated Unions
type TestResult =
    | Absent
    | Excused
    | NA
    | Scored of float
        
    static member public FromString(s: string) : TestResult =
        if s = "A" then
            Absent
        elif s = "E" then
            Excused
        elif s = "N/A" then
            NA
        else
            let value = s |> float
            Scored value
    
    static member public getEffectiveScore(str: string): float =
        TestResult.FromString(str).getEffectiveScore()
        
    static member public getEffectiveScore(result: TestResult) : float =
        match result with
        | Absent -> 0.0
        | Excused -> 50.0
        | NA -> 50
        | Scored score -> score

    member public this.getEffectiveScore() : float = TestResult.getEffectiveScore (this)
