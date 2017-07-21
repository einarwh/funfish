module Svgy

open System.IO

open NGraphics

open Vectory
open Boxes
open Lensy
open Monochromes
open Shades
open Shapes  
open Styling

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

let getStrokeWidth { a = a; b = b; c = c } =
  let s = min (size b) (size c)
  s / 80.

let mapBezier m = function 
| { controlPoint1 = cp1
    controlPoint2 = cp2
    endPoint = ep } ->
  { controlPoint1 = m cp1
    controlPoint2 = m cp2
    endPoint = m ep }

let getDefaultColor name hue = 
  if name = "secondary" then 
    match hue with 
    | Blackish -> StyleColor.White
    | Greyish -> StyleColor.White
    | Whiteish -> StyleColor.Black
  else
    match hue with 
    | Blackish -> StyleColor.Black
    | Greyish -> StyleColor.Grey
    | Whiteish -> StyleColor.White

let getDefaultStyle name hue sw = 
  let stroke = 
    { strokeWidth = sw 
      strokeColor = getDefaultColor name hue }
  { stroke = Some stroke; fill = None }

let getColor name = function 
  | Blackish -> 
    if name = "primary" then StyleColor.Black  
    else if name = "eye-outer" then StyleColor.White 
    else if name = "eye-inner" then StyleColor.Black 
    else StyleColor.White 
  | Greyish -> 
    if name = "primary" then StyleColor.Grey 
    else if name = "eye-outer" then StyleColor.White 
    else if name = "eye-inner" then StyleColor.Grey 
    else StyleColor.White 
  | Whiteish -> 
    if name = "primary" then StyleColor.White  
    else if name = "eye-outer" then StyleColor.White  
    else if name = "eye-inner" then StyleColor.Black 
    else StyleColor.Black


let getEyeLiner sw hue =  
  { strokeColor = getColor "secondary" hue 
    strokeWidth = sw / 1.5 }
    
let getPathStyle name sw hue = 
  let stroke = if name = "eye-outer" then Some <| getEyeLiner sw hue else None
  let fill = Some { fillColor = getColor name hue }
  { stroke = stroke; fill = fill }

let mapNamedShape (box : Box, hue : Hue) (name, shape) : (Shape * Style) = 
  let m = mapper box
  let sw = getStrokeWidth box
  match shape with
  | Polygon { points = pts } ->
    Polygon { points = pts |> List.map m }, getDefaultStyle name hue sw
  | Curve { point1 = v1
            point2 = v2 
            point3 = v3 
            point4 = v4 } ->
    Curve { point1 = m v1
            point2 = m v2 
            point3 = m v3 
            point4 = m v4 }, getDefaultStyle name hue sw
  | Path (start, beziers) ->
    let style = getPathStyle name sw hue
    Path (m start, beziers |> List.map (mapBezier m)), style
                     
let shapeVectors = function 
  | Polygon { points = pts } -> pts

let getVectors (shapes : Shape list) = 
  shapes |> List.collect shapeVectors

let bound (shapes : Shape list) = 
  let vectors = shapes |> List.collect shapeVectors
  let xmax = vectors |> List.map (fun { x = x; y = _ } -> x) |> List.max
  let ymax = vectors |> List.map (fun { x = _; y = y } -> y) |> List.max
  (xmax, ymax)

let getStyle box = 
  let sw = getStrokeWidth box
  { stroke = Some { strokeWidth = sw
                    strokeColor = StyleColor.Black } 
    fill = None }

let createPicture (shapes : Shape list) : Picture = 
   fun box ->
     let m = mapper box
     let style = getStyle box
     shapes |> List.map (mapShape m) |> List.map (fun s -> s, style)

let createLensPicture (shapes : (string * Shape) list) : LensPicture = 
   fun lens ->
     shapes |> List.map (mapNamedShape lens)

let getStrokePen { strokeWidth = sw; strokeColor = sc } = 
  let color = 
    match sc with 
    | Black -> Colors.Black 
    | Grey -> Colors.Gray
    | White -> Colors.White
  Pen(color, sw)

let getFillBrush { fillColor = fc } = 
  match fc with 
  | Black -> Brushes.Black 
  | Grey -> Brushes.Gray
  | White -> Brushes.White
  
let renderSvg (width : float) (height : float) (filename : string) (styledShapes : (Shape * Style) list) = 
  let size = Size(width, height)
  let canvas = GraphicCanvas(size)
  let color, defaultPen = Colors.Black, Pens.Black
  let p x y = Point(x, height - y) // Point(x, ymax - y)?
  let getPen style = 
    match style.stroke with 
    | Some stroke -> getStrokePen stroke 
    | None -> defaultPen
  let drawShape (style : Style) = function 
  | Polygon { points = pts } ->
    match pts |> List.map (fun { x = x; y = y } -> p x y) with 
    | startPoint :: t ->
      let move = MoveTo(startPoint) :> PathOp
      let lines = t |> List.map (fun pt -> LineTo(pt) :> PathOp) 
      let close = ClosePath() :> PathOp
      let ops = (move :: lines) @ [ close ] 
      canvas.DrawPath(ops, getPen style)
    | _ -> ()
  | Curve { point1 = { x = x1; y = y1 }
            point2 = { x = x2; y = y2 }
            point3 = { x = x3; y = y3 } 
            point4 = { x = x4; y = y4 } } ->
    let pt1, pt2, pt3, pt4 = p x1 y1, p x2 y2, p x3 y3, p x4 y4
    let move  = new MoveTo(pt1) :> PathOp
    let curve = new CurveTo(pt2, pt3, pt4) :> PathOp    
    canvas.DrawPath([move; curve], getPen style)  
  | Path ({ x = x; y = y }, beziers) ->
    let move = MoveTo(p x y) :> PathOp
    let toCurve { controlPoint1 = { x = x1; y = y1 }
                  controlPoint2 = { x = x2; y = y2 }
                  endPoint =      { x = x3; y = y3 } } =
      CurveTo(p x1 y1, p x2 y2, p x3 y3) :> PathOp
    let curves = beziers |> List.map toCurve
    let pen = 
      match style.stroke with 
      | Some stroke -> getStrokePen stroke
      | None -> null
    let brush = 
      match style.fill with 
      | Some fill -> getFillBrush fill
      | None -> null
    canvas.DrawPath(move :: curves, pen, brush)    
    
  styledShapes |> List.iter (fun (shape, style) -> drawShape style shape)
  use writer = new StreamWriter(filename)
  canvas.Graphic.WriteSvg(writer)

let renderSvg' (width : float) (height : float) (filename : string) (styledShapes : (string * Shape * Style) list) = 
  let size = Size(width, height)
  let canvas = GraphicCanvas(size)
  let color, defaultPen = Colors.Black, Pens.Black
  let p x y = Point(x, height - y) // Point(x, ymax - y)?
  let getPen style = match style.stroke with Some stroke -> defaultPen.WithWidth(stroke.strokeWidth) | None -> defaultPen
  let drawShape (name : string) (style : Style) = function 
  | Polygon { points = pts } ->
    match pts |> List.map (fun { x = x; y = y } -> p x y) with 
    | startPoint :: t ->
      let move = MoveTo(startPoint) :> PathOp
      let lines = t |> List.map (fun pt -> LineTo(pt) :> PathOp) 
      let close = ClosePath() :> PathOp
      let ops = (move :: lines) @ [ close ] 
      canvas.DrawPath(ops, getPen style)
    | _ -> ()
  | Curve { point1 = { x = x1; y = y1 }
            point2 = { x = x2; y = y2 }
            point3 = { x = x3; y = y3 } 
            point4 = { x = x4; y = y4 } } ->
    let pt1, pt2, pt3, pt4 = p x1 y1, p x2 y2, p x3 y3, p x4 y4
    let move  = new MoveTo(pt1) :> PathOp
    let curve = new CurveTo(pt2, pt3, pt4) :> PathOp
    canvas.DrawPath([move; curve], getPen style)  
  styledShapes |> List.iter (fun (name, shape, style) -> drawShape name style shape)
  use writer = new StreamWriter(filename)
  canvas.Graphic.WriteSvg(writer)


(**
let createSvgPicture (canvas : GraphicCanvas) (shapes : Shape list) : Picture = 
  fun box -> 
    let height = canvas.Graphic.Size.Height
    let color = Colors.Black
    let p x y = Point(x, height - y)
    let pen = Pens.Black.WithWidth(0.5);
    let drawShape : Shape -> unit = function 
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

**)

  