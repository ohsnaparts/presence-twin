module PresenceTwin.Api.models.Temperature

type public Temperature(celsius: float) =
    member val Celsius = celsius with get, set
    member this.Fahrenheit with get() =
        32.0 + (this.Celsius / 0.5556)
        
    new() = Temperature(0.0)
   
   
