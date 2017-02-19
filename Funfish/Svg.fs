module Svg

open System.IO

open NGraphics

open Segments
open Curves
open Pictures
open Points

let paintSvg (width : int) (height: int) (filename : string) (drawables : Drawable list) = 
  let size = new Size(float width, float height)
  let p x y = new NGraphics.Point(x, y)
  let canvas = new GraphicCanvas(size)
  let color, pen = Colors.Black, Pens.Black
  let drawPoint x y = 
    let x0, x1 = x - 2., x + 2.
    let y0, y1 = y - 2., y + 2.
    canvas.DrawLine(p x0 y0, p x1 y1, Colors.Blue)
    canvas.DrawLine(p x0 y1, p x1 y0, Colors.Blue)
  let draw d =
    match d with
    | Line ls -> 
      let (pt1, pt2) = (startPoint ls, endPoint ls)
      let (x1, y1) = (xcoord pt1, ycoord pt1)
      let (x2, y2) = (xcoord pt2, ycoord pt2)
      canvas.DrawLine(p x1 y1, p x2 y2, color)
    | Bezier cs ->
      let (pt1, pt2, pt3, pt4) = (point1 cs, point2 cs, point3 cs, point4 cs)
      let (x1, y1) = (xcoord pt1, ycoord pt1)
      let (x2, y2) = (xcoord pt2, ycoord pt2)
      let (x3, y3) = (xcoord pt3, ycoord pt3)
      let (x4, y4) = (xcoord pt4, ycoord pt4)
      let move  = new MoveTo(x1, y1) :> PathOp
      let curve = new CurveTo(p x2 y2, p x3 y3, p x4 y4) :> PathOp
      canvas.DrawPath([move; curve], pen)
      // Debugging: view control points.
      //drawPoint x2 y2
      //drawPoint x3 y3
  drawables |> List.iter draw
  use writer = new StreamWriter(filename)
  canvas.Graphic.WriteSvg(writer)
