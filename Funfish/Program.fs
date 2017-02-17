module Funfish

open Points
open Vectors
open Rectangles

open Segments
open Curves
open Data
open Pictures
open Mapping
open Drawing
open Render
open Letters
open SquareLimit

[<EntryPoint>]
let main argv =
    let rect = createRectangle (createVector 0. 0.)
                               (createVector 0. 600.)
                               (createVector 600. 0.)
   
    rect |> (fish |> turn) |> svg "fish.svg"
    rect |> (fish |> turn) |> svg "fish.svg"
    rect |> (squarelimit2 |> turn) |> svg "limit.svg"
    rect |> (squarelimit2 |> turn) |> png "limit.png"

    0 // return an integer exit code
