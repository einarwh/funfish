module Svgy

open System.IO

open NGraphics

open Vectory
open Boxes
open Monochromes
open Shapes  

let mapper { a = a; b = b; c = c } = function  
  | { x = x; y = y } -> a + b * x + c * y

let mirror ymax { x = x; y = y } =
  { x = x; y = ymax - y}

let mapShape m = function 
  | Polygon { points = pts } ->
    Polygon { points = pts |> List.map m }

let bound { a = a; b = b; c = c } = 
  let corners = [ a; a + b; a + c; a + b + c ]
  let xmax = corners |> List.map (fun { x = x; y = _ } -> x) |> List.max
  let ymax = corners |> List.map (fun { x = _; y = y } -> y) |> List.max
  (xmax, ymax)

let createSvgPicture
  (filename : string)
  (shapes : Shape list) 
  : Picture = 
   fun box ->
     let width, height = bound box
     let size = Size(width, height)
     let canvas = GraphicCanvas(size)
     let color, pen = Colors.Black, Pens.Black
     let p x y = Point(x, y)
     let drawShape = function 
     | Polygon { points = pts } ->
       match pts with 
       | { x = x; y = y } :: t ->
         let move = MoveTo(x, y) :> PathOp
         let lines = t |> List.map (fun { x = x; y = y } -> LineTo(p x y) :> PathOp) 
         let close = ClosePath() :> PathOp
         let ops = (move :: lines) @ [ close ] 
         canvas.DrawPath(ops, pen)
       | _ -> ()
     let m = (mapper box) >> (mirror height)
     shapes |> List.map (mapShape m) |> List.iter drawShape
     use writer = new StreamWriter(filename)
     canvas.Graphic.WriteSvg(writer)
