module Runner

open Expecto

open FsCheck
open FsCheck.Arb

type Overrides() =
    static member Float() =
        Arb.Default.Float()
        |> filter (fun f -> not <| System.Double.IsNaN(f) &&
                            not <| System.Double.IsInfinity(f) &&
                            abs f < 10000. && 
                            abs f > 0.00001) 

[<EntryPoint>]
let main args = 
  Arb.register<Overrides>() |> ignore
  runTestsInAssembly defaultConfig args