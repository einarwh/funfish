open Expecto

open Vectors
open Rectangles

[<Tests>]
let tests =
  testCase "rect" <| fun () ->
    let o = createVector 1. 1.
    let h = createVector 0. 3.
    let v = createVector 2. 0.
    let rect = createRectangle o h v
    let rect' = turn rect
    let subject = "Hello world"
    Expect.equal subject "Hello World"
                 "The strings should equal"

[<EntryPoint>]
let main args =
  runTestsInAssembly defaultConfig args