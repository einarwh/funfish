module Render

open Points
open Vectors
open Rectangles

open Segments
open Curves
open Data
open Pictures
open Mapping
open Drawing
open Bitmaps
open Svg

type Size = { width : float; height : float}
type Box = { min : Point; max : Point }

let private toPoints (drawables : Drawable list) =
  let ps d = 
    match d with 
    | Line ls -> [startPoint ls; endPoint ls]
    | Bezier cs -> [point1 cs; point2 cs; point3 cs; point4 cs]
  drawables |> List.collect ps

let private adjust (drawables : Drawable list) : (Size * Drawable list) = 
  let points = toPoints drawables
  let xs = points |> List.map xcoord
  let ys = points |> List.map ycoord
  let xmin, xmax = xs |> List.min, xs |> List.max
  let ymin, ymax = ys |> List.min, ys |> List.max
  let w = xmax - xmin 
  let h = ymax - ymin 
  let size = { width = w; height = h }
  let adjust d =
    let adjustPoint (p : Points.Point) : Points.Point = 
      let x' = (xcoord p) - xmin
      let y' = (ycoord p) - ymin
      createPoint x' y'
    let adjustLine (s : Segment) : Segment =
      let pt1, pt2 = startPoint s |> adjustPoint, endPoint s |> adjustPoint
      createSegment pt1 pt2
    let adjustBezier (c : Curve) : Curve =
      let pt1, pt2, pt3, pt4 = point1 c |> adjustPoint, point2 c |> adjustPoint, point3 c |> adjustPoint, point4 c |> adjustPoint
      createCurve pt1 pt2 pt3 pt4
    match d with 
    | Line ls -> Line (adjustLine ls)
    | Bezier (cs : Curve) -> Bezier (adjustBezier cs)
  let adjusted = drawables |> List.map adjust
  (size, adjusted)

let private render filename drawables paint = 
  let (size, drawables') = drawables |> adjust
  match size with 
  | { width = w; height = h } ->
    drawables' |> paint (int w) (int h) filename

let svg filename drawables = 
  render filename drawables paintSvg
      
let png filename drawables = 
  render filename drawables paintPng
