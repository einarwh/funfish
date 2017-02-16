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
open Bitmaps
open Svg

type Size = { width : float; height : float}
type Box = { min : Point; max : Point }

let toPoints (drawables : Drawable list) =
  let ps d = 
    match d with 
    | Line ls -> [startPoint ls; endPoint ls]
    | Bezier cs -> [point1 cs; point2 cs; point3 cs; point4 cs]
  drawables |> List.collect ps

let adjust (drawables : Drawable list) : (Size * Drawable list) = 
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
    

[<EntryPoint>]
let main argv =
    let rect = createRectangle (createVector 0. 0.)
                               (createVector 0. 600.)
                               (createVector 600. 0.)
   
    let fish : Picture = createBezierCurvePicture fishCurves
    let maket (f : Picture)  = 
      let fish2 = f |> toss |> flip
      let fish3 = fish2 |> turn |> turn |> turn
      let t = over fish2 fish3 |> over f
      t

    let svg filename (size, drawables) = 
       match size with 
       | { width = w; height = h } ->
         drawables |> paintSvg (int w) (int h) filename

    let png filename (size, drawables) = 
       match size with 
       | { width = w; height = h } ->
         drawables |> paintPng (int w) (int h) filename

    rect |> (fish |> turn) |> adjust |> svg "ok.svg"

    let fish2 = fish |> toss |> flip
    let fish3 = fish2 |> turn |> turn |> turn
    let t = over fish2 fish3 |> over fish

    let tify f = 
      let fish2 = flip (toss f)
      let fish3 = turn (turn (turn fish2))
      over f (over fish2 fish3)
      //over fish2 fish3 |> over f

    let uify (f : Picture) = 
      let fish2 = f |> toss |> flip
      let u1 = over fish2 (fish2 |> turn) 
      let u2 = over (fish2 |> turn |> turn) (fish2 |> turn |> turn |> turn)
      over u1 u2

    let u = fish |> uify

    let side1 = quartet blank blank (t |> turn) t
    let side2 = quartet side1 side1 (t |> turn) t 

    let corner1 = quartet blank blank blank u 
    let corner2 = quartet corner1 side1 (side1 |> turn) u

    let squarelimit2 = //p q r s t u v w x
      let p = corner2
      let q = side2
      let r = corner2 |> turn |> turn |> turn
      let s = side2 |> turn
      let t = fish |> uify
      let u = side2 |> turn |> turn |> turn
      let v = corner2 |> turn
      let w = side2 |> turn |> turn
      let x = corner2 |> turn |> turn
      nonet p q r s t u v w x

    //rect |> (t |> turn) 
    //rect |> (u |> turn) 
    //rect |> (quartet u u u u |> turn)
    //rect |> (v |> turn)
    //rect |> (side1 |> turn)
    //rect |> (side2 |> turn)
    //rect |> (corner1 |> turn)
    //rect |> (corner2 |> turn)
    //rect |> (fish |> turn |> cycle |> turn)
    //rect |> (t |> cycle |> turn)
    //let v = fish |> tify |> turn |> cycle'
    //rect |> (v |> turn)
    rect |> (fish |> turn) |> adjust |> svg "fish.svg"
    rect |> (squarelimit2 |> turn) |> adjust |> svg "limit.svg"

    rect |> (squarelimit2 |> turn) |> adjust |> png "limit.png"

    //rect |> (fish |> turn)
    //rect |> (aboveRatio 1 2 fish (fish |> turn) |> turn)
    //rect |> (besideRatio 1 2 fish (fish |> turn) |> turn)
    //rect |> (squarelimit2 |> turn)

    let letterf' = createSegmentPicture fSegments

    //rect |> (letterf' |> turn)

    let letterp' = createSegmentPicture pSegments

    rect |> (letterp' |> turn)

    //rect |> (besideRatio 1 1 letterf letterp |> turn)
    //rect |> (quartet letterf letterp (flip letterf) (flip letterp) |> turn)

    0 // return an integer exit code
