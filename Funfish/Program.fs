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
open Fishy
open Limit
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

    let svg = renderSvg 600. 600.

    let f = createPicture [ fShape ]
    let h = createPicture [ hShape ]
    let e = createPicture [ eShape ]
    let n = createPicture [ nShape ]
    let d = createPicture [ dShape1; dShape2 ]
    let r = createPicture [ rShape1; rShape2 ]
    let s = createPicture [ sShape ]
    let o = createPicture [ oShape1; oShape2 ]

    let hendersonFish = createPicture hendersonFishShapes

    let henderson = nonet h e n d e r s o n

    box |> henderson |> svg "henderson.svg"

    box |> f |> svg "letter-f.svg"

    box |> n |> svg "letter-n.svg"

    box |> above f n |> svg "above-fn.svg"

    box |> beside f n |> svg "beside-fn.svg"

    box |> beside f n |> svg "beside-fn.svg"

    box |> hendersonFish |> svg "h-fish.svg"

    box |> ttile hendersonFish |> svg "tile-t.svg"

    box |> utile hendersonFish |> svg "tile-u.svg"

    box |> squareLimit 3 hendersonFish |> svg "squarelimit-3.svg"

    0 // return an integer exit code
