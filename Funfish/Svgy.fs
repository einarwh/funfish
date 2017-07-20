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
  | Curve { point1 = v1
            point2 = v2 
            point3 = v3 
            point4 = v4 } ->
    Curve { point1 = m v1
            point2 = m v2 
            point3 = m v3 
            point4 = m v4 }


let shapeVectors = function 
  | Polygon { points = pts } -> pts

let getVectors (shapes : Shape list) = 
  shapes |> List.collect shapeVectors

let bound (shapes : Shape list) = 
  let vectors = shapes |> List.collect shapeVectors
  let xmax = vectors |> List.map (fun { x = x; y = _ } -> x) |> List.max
  let ymax = vectors |> List.map (fun { x = _; y = y } -> y) |> List.max
  (xmax, ymax)

let createPicture (shapes : Shape list) : Picture = 
   fun box ->
     let m = mapper box
     shapes |> List.map (mapShape m)

let renderSvg (width : float) (height : float) (filename : string) (shapes : Shape list) = 
  let size = Size(width, height)
  let canvas = GraphicCanvas(size)
  let color, pen = Colors.Black, Pens.Black
  let p x y = Point(x, height - y) // Point(x, ymax - y)?
  let drawShape = function 
  | Polygon { points = pts } ->
    match pts |> List.map (fun { x = x; y = y } -> p x y) with 
    | startPoint :: t ->
      let move = MoveTo(startPoint) :> PathOp
      let lines = t |> List.map (fun pt -> LineTo(pt) :> PathOp) 
      let close = ClosePath() :> PathOp
      let ops = (move :: lines) @ [ close ] 
      canvas.DrawPath(ops, pen)
    | _ -> ()
  | Curve { point1 = { x = x1; y = y1 }
            point2 = { x = x2; y = y2 }
            point3 = { x = x3; y = y3 } 
            point4 = { x = x4; y = y4 } } ->
    let pt1, pt2, pt3, pt4 = p x1 y1, p x2 y2, p x3 y3, p x4 y4
    let move  = new MoveTo(pt1) :> PathOp
    let curve = new CurveTo(pt2, pt3, pt4) :> PathOp
    canvas.DrawPath([move; curve], pen)  
  shapes |> List.iter drawShape
  use writer = new StreamWriter(filename)
  canvas.Graphic.WriteSvg(writer)
  