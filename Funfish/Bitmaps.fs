module Bitmaps

open System.Drawing
//open System.IO

open Segments
open Curves
open Pictures
open Mapping
open Rectangles
open Vectors
open Points

let paintBitmap (width : int) (height : int) (filename : string) (drawables : Drawable list) = 
    use bitmap = new Bitmap(width, height)
    let g = Graphics.FromImage(bitmap)
    let f it = it + 200. |> float32
    let draw d =
      match d with
      | Line ls -> 
        let (pt1, pt2) = (startPoint ls, endPoint ls)
        let (x1, y1) = (xcoord pt1, ycoord pt1)
        let (x2, y2) = (xcoord pt2, ycoord pt2)
        let pt1' = new PointF(f x1, f y1)
        let pt2' = new PointF(f x2, f y2)
        g.DrawLine(Pens.Black, pt1', pt2')
      | Bezier cs ->
        let (pt1, pt2, pt3, pt4) = (point1 cs, point2 cs, point3 cs, point4 cs)
        let (x1, y1) = (xcoord pt1, ycoord pt1)
        let (x2, y2) = (xcoord pt2, ycoord pt2)
        let (x3, y3) = (xcoord pt3, ycoord pt3)
        let (x4, y4) = (xcoord pt4, ycoord pt4)
        g.DrawBezier(Pens.Black, f x1, f y1, f x2, f y2, f x3, f y3, f x4, f y4)    
    drawables |> List.iter draw
    bitmap.Save(filename) 

