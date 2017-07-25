module Svg

open System.IO

open NGraphics

open Vectors
open Boxes
open Lenses
open Pictures
open Shades
open Shapes  
open Styling

let mapper { a = a; b = b; c = c }  
           { x = x; y = y } =
   a + b * x + c * y

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
  | Path (start, beziers) ->
    let mapBezier { controlPoint1 = cp1
                    controlPoint2 = cp2 
                    endPoint = ep } =
      { controlPoint1 = m cp1 
        controlPoint2 = m cp2 
        endPoint = m ep }
    Path (m start, beziers |> List.map mapBezier)
  | Line { lineStart = v1 
           lineEnd = v2 } ->
    Line { lineStart = m v1 
           lineEnd = m v2 }

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
    | Hollow -> StyleColor.Black
  else
    match hue with 
    | Blackish -> StyleColor.Black
    | Greyish -> StyleColor.Grey
    | Whiteish -> StyleColor.White
    | Hollow -> StyleColor.White

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
  | Hollow -> 
    if name = "primary" then StyleColor.White  
    else if name = "eye-outer" then StyleColor.White  
    else if name = "eye-inner" then StyleColor.Black 
    else StyleColor.Black

let getEyeLiner sw hue =  
  { strokeColor = getColor "secondary" hue 
    strokeWidth = sw / 1.5 }
    
let getPathStyle name sw hue = 
  match hue with
  | Hollow ->
    let stroke = Some <| getEyeLiner sw hue
    let fill = if name = "eye-inner" then Some { fillColor = Black } else None
    { stroke = stroke; fill = fill }    
  | _ -> 
    let stroke = if name = "eye-outer" then Some <| getEyeLiner sw hue else None
    let fill = Some { fillColor = getColor name hue }
    { stroke = stroke; fill = fill }

let getLineStyle name sw hue = 
  if name = "control-point" then 
    let stroke = Some { strokeColor = StyleColor.Red; strokeWidth = 0.5 }
    { stroke = stroke; fill = None }
  else
    getDefaultStyle name sw hue

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
  | Line { lineStart = v1
           lineEnd = v2 } ->
    Line { lineStart = m v1 
           lineEnd = m v2 }, getDefaultStyle name hue sw
                     
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
    | Red -> Colors.Red
  Pen(color, sw)

let getFillBrush { fillColor = fc } = 
  match fc with 
  | Black -> Brushes.Black 
  | Grey -> Brushes.Gray
  | White -> Brushes.White
  | Red -> Brushes.Red
  
let renderSvg (width : float) (height : float) (filename : string) (styledShapes : (Shape * Style) list) = 
  let size = Size(width, height)
  let canvas = GraphicCanvas(size)
  let p x y = Point(x, height - y) 
  let getPen style = 
    match style.stroke with 
    | Some stroke -> getStrokePen stroke 
    | None -> Pens.Black
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
    let close = ClosePath() :> PathOp
    let ops = (move :: curves) @ [ close ] 
    canvas.DrawPath(ops, pen, brush) 
    // DEBUG
    let debug = false
    if debug then 
      let drawCross x y = 
        canvas.DrawLine(p (x-2.) (y-2.), p (x+2.) (y+2.), Pens.Red)
        canvas.DrawLine(p (x-2.) (y+2.), p (x+2.) (y-2.), Pens.Red)
      let drawBezierPoints { controlPoint1 = { x = x1; y = y1 }
                             controlPoint2 = { x = x2; y = y2 }
                             endPoint = _ } =
        drawCross x1 y1
        drawCross x2 y2
      beziers |> List.iter drawBezierPoints
  | Line { lineStart = { x = x1; y = y1 }
           lineEnd   = { x = x2; y = y2 } } ->
    let move = MoveTo(p x1 y1) :> PathOp
    let line = LineTo(p x2 y2) :> PathOp
    canvas.DrawPath([move; line], getPen style)
    
  styledShapes |> List.iter (fun (shape, style) -> drawShape style shape)
  use writer = new StreamWriter(filename)
  canvas.Graphic.WriteSvg(writer)

