module Funfish

open System.IO
open NGraphics

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
open Lettery
open Fishy
open Fishier
open Lensy
open Limit
open HueLimit
open Svgy

// fswatch ./funfish/ | xargs -I {} cp {} ./svgwatcher/svgimages/
// qlmanage -t -s 1000 -o . picture.svg 
// rsvg-convert -h 32 icon.svg > icon-32.png

let writeSvg (filename : string) (canvas : GraphicCanvas) = 
  use writer = new StreamWriter(filename)
  canvas.Graphic.WriteSvg(writer)


let hendersonNonet width height = 
  let h = createPicture [ hShape ]
  let e = createPicture [ eShape ]
  let n = createPicture [ nShape ]
  let d = createPicture [ dShape1; dShape2 ]
  let r = createPicture [ rShape1; rShape2 ]
  let s = createPicture [ sShape ]
  let o = createPicture [ oShape1; oShape2 ]
  let box = { a = { x = 0.; y = 0. }
              b = { x = width; y = 0. } 
              c = { x = 0.; y = height } }
        
  box |> nonet h e n d e r s o n |> renderSvg width height "henderson.svg"

let hendersonTtile width height = 
  let fish = createPicture hendersonFishShapes
  let box = { a = { x = width / 4.; y = height / 4. }
              b = { x = width / 2.; y = 0. } 
              c = { x = 0.; y = height / 2. } }
        
  box |> ttile fish |> renderSvg width height "fish-t-tile.svg"

let hendersonSquareLimit width height = 
  let fish = createPicture hendersonFishShapes
  let box = { a = { x = 0.; y = 0. }
              b = { x = width; y = 0. } 
              c = { x = 0.; y = height } }
        
  box |> squareLimit 4 fish |> renderSvg width height "square-limit-4.svg"

let hueFish hue filename width height = 
  let fish = createLensPicture fishShapes
  let box = { a = { x = width / 4.; y = height / 4. }
              b = { x = width / 2.; y = 0. } 
              c = { x = 0.; y = height / 2. } }

  let lens = box, hue
  lens |> fish |> renderSvg width height filename

let blackFish = hueFish Blackish "fish-black.svg" 
let greyFish = hueFish Greyish "fish-grey.svg" 
let whiteFish = hueFish Whiteish "fish-white.svg" 

let hueSquareLimit n width height = 
  let fish = createLensPicture fishShapes
  let box = { a = { x = 0.; y = 0. }
              b = { x = width; y = 0. } 
              c = { x = 0.; y = height } }

  let lens = box, Greyish
  let filename = sprintf "squarelimit-hue-%d.svg" n
  lens |> squareLimit' 4 fish |> renderSvg width height filename

[<EntryPoint>]
let main argv =
  hendersonNonet 400. 400.
  hendersonTtile 400. 400.
  hendersonSquareLimit 400. 400.
  blackFish 400. 400.
  greyFish 400. 400.
  whiteFish 400. 400.
  hueSquareLimit 4 400. 400.
  0
  
  (*
  let rect = createRectangle (createVector 0. 0.)
                             (createVector 0. 600.)
                             (createVector 600. 0.)
 
  rect |> (fish |> turn) |> svg "fish.svg"
  rect |> (squarelimit2 |> turn) |> svg "limit2.svg"
  rect |> (squarelimit2 |> turn) |> png "limit2.png"
  rect |> (squarelimit 3 |> turn) |> svg "limit3.svg"
  rect |> (squarelimit 4 |> turn) |> svg "limit4.svg"

  //let box = { a = { x =   0.; y =   0. }
  //            b = { x = 600.; y =   0. } 
  //            c = { x =   0.; y = 600. } }

  //let svg = renderSvg 600. 600.

  //let f = createPicture [ fShape ]
  //let h = createPicture [ hShape ]
  //let e = createPicture [ eShape ]
  //let n = createPicture [ nShape ]
  //let d = createPicture [ dShape1; dShape2 ]
  //let r = createPicture [ rShape1; rShape2 ]
  //let s = createPicture [ sShape ]
  //let o = createPicture [ oShape1; oShape2 ]

  //let hendersonFish = createPicture hendersonFishShapes

  //let henderson = nonet h e n d e r s o n

  //box |> henderson |> svg "henderson.svg"
  //box |> f |> svg "letter-f.svg"
  //box |> n |> svg "letter-n.svg"
  //box |> above f n |> svg "above-fn.svg"
  //box |> beside f n |> svg "beside-fn.svg"
  //box |> beside f n |> svg "beside-fn.svg"
  //box |> hendersonFish |> svg "h-fish.svg"
  //box |> ttile hendersonFish |> svg "tile-t.svg"
  //box |> utile hendersonFish |> svg "tile-u.svg"
  //box |> squareLimit 3 hendersonFish |> svg "squarelimit-3.svg"
  *)

