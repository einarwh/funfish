module Drawing

open System.Drawing

//open NGraphics

open Segments
open Curves
open Pictures
open Mapping
open Rectangles
open Vectors
open Points

//let size = new Size(800., 800.)
//let canvas = Platforms.Current.CreateImageCanvas(size)
//canvas.GetImage().Save

type BitmapPainter(width : int, height : int, filename : string) =
    
    let bitmap = new Bitmap(width, height)
    let g = Graphics.FromImage(bitmap)

    member this.CreateBezierCurvePicture (curves : Curve list) = 
      fun rect ->
        let drawCurve (pt1 : Point) (pt2 : Point) (pt3 : Point) (pt4 : Point) =
          let f it = it + 200. |> float32 
          let x1 = xcoord pt1 |> f
          let y1 = ycoord pt1 |> f
          let x2 = xcoord pt2 |> f
          let y2 = ycoord pt2 |> f
          let x3 = xcoord pt3 |> f
          let y3 = ycoord pt3 |> f
          let x4 = xcoord pt4 |> f
          let y4 = ycoord pt4 |> f
          g.DrawBezier(Pens.Black, x1, y1, x2, y2, x3, y3, x4, y4)
        let m = mapper rect
        let toVector pt =
          createVector (xcoord pt) (ycoord pt) 
        let toPoint v = 
          createPoint (x v) (y v)
        let drawCurve (c : Curve) =
          let pt1 = point1 c
          let pt2 = point2 c
          let pt3 = point3 c
          let pt4 = point4 c
          //printfn "draw curve (%f, %f) -> (%f, %f)" (xcoord pt1) (ycoord pt1) (xcoord pt2) (ycoord pt2)
          let pt1' = pt1 |> toVector |> m |> toPoint
          let pt2' = pt2 |> toVector |> m |> toPoint
          let pt3' = pt3 |> toVector |> m |> toPoint
          let pt4' = pt4 |> toVector |> m |> toPoint
          //printfn "draw segment' (%f, %f) -> (%f, %f)" (xcoord pt1') (ycoord pt1') (xcoord pt2') (ycoord pt2')
          drawCurve pt1' pt2' pt3' pt4'
        //let o = origin rect
        //let h = horizontal rect
        //let h' = add o h
        //let v = vertical rect
        //let v' = add o v
        //let xo, yo = (x o, y o)
        //let xh, yh = (x h', y h')
        //let xv, yv = (x v', y v') 
        //let z = add o (add h v)
        //let xz, yz = (x z, y z)
        //let f it = it + 200. |> float32 
        //g.DrawLine(Pens.Pink, xo |> f, yo |> f, xh |> f, yh |> f) // o - h
        //g.DrawLine(Pens.Pink, xo |> f, yo |> f, xv |> f, yv |> f) // o - v
        //g.DrawLine(Pens.Pink, xz |> f, yz |> f, xh |> f, yh |> f) // z - h
        //g.DrawLine(Pens.Pink, xz |> f, yz |> f, xv |> f, yv |> f) // z - v
        curves |> List.iter drawCurve

    member this.CreateSegmentPicture (segments : Segment list) = 
      fun rect -> 
        let drawLine (pt1 : Point) (pt2 : Point) =
          let f it = it + 200. |> float32 
          let x1 = xcoord pt1 |> f
          let y1 = ycoord pt1 |> f
          let x2 = xcoord pt2 |> f
          let y2 = ycoord pt2 |> f
          g.DrawLine(Pens.Black, x1, y1, x2, y2)
        let m = mapper rect
        let toVector pt =
          createVector (xcoord pt) (ycoord pt) 
        let toPoint v = 
          createPoint (x v) (y v)
        let drawSegment seg =
          let pt1 = startPoint seg
          let pt2 = endPoint seg
          let pt1' = pt1 |> toVector |> m |> toPoint
          let pt2' = pt2 |> toVector |> m |> toPoint
          drawLine pt1' pt2'
        segments |> List.iter drawSegment
 
    interface System.IDisposable with 
        member this.Dispose() = 
            bitmap.Save(filename)
            bitmap.Dispose()

