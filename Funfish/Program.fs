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

// fswatch ./funfish/ | xargs -I {} cp {} ./svgwatcher/svgimages/
// qlmanage -t -s 1000 -o . picture.svg 
// rsvg-convert -h 32 icon.svg > icon-32.png

[<EntryPoint>]
let main argv =
    let rect = createRectangle (createVector 0. 0.)
                               (createVector 0. 600.)
                               (createVector 600. 0.)
   
    rect |> (fish |> turn) |> svg "fish.svg"
    rect |> (squarelimit2 |> turn) |> svg "limit2.svg"
    rect |> (squarelimit2 |> turn) |> png "limit2.png"
    rect |> (squarelimit 3 |> turn) |> svg "limit3.svg"
    rect |> (squarelimit 4 |> turn) |> svg "limit4.svg"

    0 // return an integer exit code
