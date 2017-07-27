module Funfish

open System.IO
open NGraphics

open Vectors
open Boxes
open Letters
open Fishy
open Fishier
open Fishegg
open Lizard
open Lenses
open Shades
open Limited
open Unlimited
open Svg

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

let hendersonEgg width height = 
  let fish = createPicture hendersonFishShapes
  let box = { a = { x = 100.; y = 100. }
              b = { x = 3200.; y = 0. } 
              c = { x = 0.; y = 600. } }

  let depth = 3
  let band = egg depth 16 fish        
  box |> band |> renderSvg width height (sprintf "henderson-egg-%d.svg" depth)


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
  let filename = sprintf "squarelimit-hue-%d-%d.svg" n (int width)
  lens |> squareLimit' 4 fish |> renderSvg width height filename

let singleLizard width height = 
  let lizard = createLensPicture lizardShapes
  let box = { a = { x = width / 4.; y = height / 4. }
              b = { x = width / 2.; y = 0. } 
              c = { x = 0.; y = height / 2. } }
  let lens = box, Greyish
  lens |> lizard |> renderSvg width height "single-lizard.svg"

let rec qquartet (n : int) (p : LensPicture) =
  let p' = if n = 1 then p else qquartet (n - 1) p
  quartet' p' p' p' p'

let quartetLizard width height = 
  let lizard1 = createLensPicture lizardShapes
  let lizard2 = lizard1 |> Shades.rehue
  let box = { a = { x = width / 4.; y = height / 4. }
              b = { x = width / 2.; y = 0. } 
              c = { x = 0.; y = height / 2. } }
  let lens = box, Blackish
  let lizardNW = lizard1
  let lizardNE = lizard2 |> Shades.turn
  let lizardSW = lizard2 |> Shades.turn |> Shades.turn |> Shades.turn
  let lizardSE = lizard1 |> Shades.turn |> Shades.turn
  let q = quartet' lizardNW 
                   lizardNE
                   lizardSW
                   lizardSE
  let qq = qquartet 3 q
  lens |> qq |> renderSvg width height "quartet-lizards.svg"

let escherEgg depth width height = 
  let fish = createLensPicture fishShapes
  let box = { a = { x = 0.; y = 100. }
              b = { x = 3600.; y = 0. } 
              c = { x = 0.; y = 600. } }

  let band = egg' depth 18 fish
  let lens = box, Hollow
  lens |> band |> renderSvg width height (sprintf "escher-egg-%d-3600x800.svg" depth)

let escherEgg' depth width height = 
  let fish = createLensPicture fishShapes
  let box = { a = { x = 0.; y = 000. }
              b = { x = 3200.; y = 0. } 
              c = { x = 0.; y = 800. } }

  let band = egg' depth 12 fish
  let lens = box, Hollow
  lens |> band |> renderSvg width height (sprintf "escher-egg-tall-%d-3200x800.svg" depth)

let escherEggStretch depth width height = 
  let fish = createLensPicture fishShapes
  let box = { a = { x = 0.; y = 0. }
              b = { x = 3200.; y = 0. } 
              c = { x = 0.; y = 800. } }

  let band = egg' depth 10 fish
  let lens = box, Hollow
  lens |> band |> renderSvg width height (sprintf "escher-egg-stretch-%d-3200x800.svg" depth)

let fisheggfish width height = 
  let fish = createLensPicture fisheggShapes
  let box = { a = { x = 100.; y = 100. }
              b = { x = 400.; y = 0. } 
              c = { x = 0.; y = 400. } }

  let lens = box, Hollow
  lens |> fish |> renderSvg width height (sprintf "fishegg.svg")

let fishegg depth width height = 
  let fish = createLensPicture fisheggShapes
  let box = { a = { x = 0.; y = 0. }
              b = { x = width; y = 0. } 
              c = { x = 0.; y = height } }

  let band = egg' depth 10 fish
  let lens = box, Hollow
  lens |> band |> renderSvg width height (sprintf "eggscher-%d-%dx%d.svg" depth (int width) (int height))


[<EntryPoint>]
let main argv =
  hendersonNonet 400. 400.
  hendersonTtile 400. 400.
  hendersonSquareLimit 400. 400.
  blackFish 400. 400.
  greyFish 400. 400.
  whiteFish 400. 400.
  hueSquareLimit 4 400. 400.
  hueSquareLimit 5 2000. 2000.
  singleLizard 400. 400.
  quartetLizard 800. 800.
  hendersonEgg 3600. 800.
  fisheggfish 600. 600.
  fishegg 3 3200. 920.
  fishegg 2 3200. 920.
  fishegg 3 3200. 1000.
  fishegg 2 3200. 1000.
  0
  