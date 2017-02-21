module Drawing

open Segments
open Curves
open Pictures
open Mapping
open Rectangles
open Vectors
open Points

let createBezierCurvePicture (curves : Curve list) : Picture = 
  fun rect ->
    let m = mapper rect
    let toVector pt =
      createVector (xcoord pt) (ycoord pt) 
    let toPoint v = 
      createPoint (x v) (y v)
    let drawSegment (s : Segment) : Drawable =
      let pt1 = startPoint s
      let pt2 = endPoint s
      let pt1' = pt1 |> toVector |> m |> toPoint
      let pt2' = pt2 |> toVector |> m |> toPoint
      Line (createSegment pt1' pt2')
    let drawCurve (c : Curve) : Drawable =
      let pt1 = point1 c
      let pt2 = point2 c
      let pt3 = point3 c
      let pt4 = point4 c
      let pt1' = pt1 |> toVector |> m |> toPoint
      let pt2' = pt2 |> toVector |> m |> toPoint
      let pt3' = pt3 |> toVector |> m |> toPoint
      let pt4' = pt4 |> toVector |> m |> toPoint
      Bezier (createCurve pt1' pt2' pt3' pt4')
    let debug = false
    if debug then
      let lines = 
        [ createSegment (createPoint 0. 0.) (createPoint 0. 1.)
          createSegment (createPoint 0. 0.) (createPoint 1. 0.)
          createSegment (createPoint 0. 0.) (createPoint 1. 1.)
          createSegment (createPoint 1. 1.) (createPoint 0. 1.)
          createSegment (createPoint 1. 1.) (createPoint 1. 0.)     
          createSegment (createPoint 1. 0.) (createPoint 0. 1.) ]
      (curves |> List.map drawCurve) @ (lines |> List.map drawSegment)
    else
      curves |> List.map drawCurve

let createSegmentPicture (segments : Segment list) : Picture = 
  fun rect -> 
    let m = mapper rect
    let toVector pt =
      createVector (xcoord pt) (ycoord pt) 
    let toPoint v = 
      createPoint (x v) (y v)
    let drawSegment (seg : Segment) : Drawable =
      let pt1 = startPoint seg
      let pt2 = endPoint seg
      let pt1' = pt1 |> toVector |> m |> toPoint
      let pt2' = pt2 |> toVector |> m |> toPoint
      Line (createSegment pt1' pt2')
    segments |> List.map drawSegment
