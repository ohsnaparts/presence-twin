module StudentProcessing.Optional

type Optional<'T> =
    | Something of 'T
    | Nothing
    
    member public this.Value: 'T =
        match this with
        | Something s -> s
        | Nothing -> raise (System.InvalidOperationException("No value present."))
    
    static member public defaultValue (defaultValue: 'T) (optional: Optional<'T>): 'T =
        match optional with
        | Something s -> s
        | Nothing -> defaultValue
