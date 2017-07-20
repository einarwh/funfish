module Funfish

//open Points
//open Vectors
//open Rectangles

//open Segments
//open Curves
//open Data
//open Pictures
//open Mapping
//open Drawing
//open Render
//open Letters
//open SquareLimit

open Vectory
open Boxes
open Monochromes
open Lettery
open Svgy

// fswatch ./funfish/ | xargs -I {} cp {} ./svgwatcher/svgimages/
// qlmanage -t -s 1000 -o . picture.svg 
// rsvg-convert -h 32 icon.svg > icon-32.png

let svg filename p = 
  ()

[<EntryPoint>]
let main argv =
    (*
    let rect = createRectangle (createVector 0. 0.)
                               (createVector 0. 600.)
                               (createVector 600. 0.)
   
    rect |> (fish |> turn) |> svg "fish.svg"
    rect |> (squarelimit2 |> turn) |> svg "limit2.svg"
    rect |> (squarelimit2 |> turn) |> png "limit2.png"
    rect |> (squarelimit 3 |> turn) |> svg "limit3.svg"
    rect |> (squarelimit 4 |> turn) |> svg "limit4.svg"
    *)

    let box = { a = { x =   0.; y =   0. }
                b = { x = 600.; y =   0. } 
                c = { x =   0.; y = 600. } }

    let f = createSvgPicture "fletter.svg" [ fShape ]

    box |> f

    0 // return an integer exit code
