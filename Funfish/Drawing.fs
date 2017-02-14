module Drawing

open System.Drawing

open Segments
open Curves
open Pictures
open Mapping
open Vectors
open Points

type BitmapPainter(width : int, height : int, filename : string) =
    
    let bitmap = new Bitmap(width, height)
    let g = Graphics.FromImage(bitmap)
    
    member this.CreateBezierCurvePicture (curves : Curve list) = 
      fun rect ->
        let drawCurve (pt1 : Point) (pt2 : Point) (pt3 : Point) (pt4 : Point) =
          printfn "drawCurve"
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
          printfn "draw curve (%f, %f) -> (%f, %f)" (xcoord pt1) (ycoord pt1) (xcoord pt2) (ycoord pt2)
          let pt1' = pt1 |> toVector |> m |> toPoint
          let pt2' = pt2 |> toVector |> m |> toPoint
          let pt3' = pt3 |> toVector |> m |> toPoint
          let pt4' = pt4 |> toVector |> m |> toPoint
          printfn "draw segment' (%f, %f) -> (%f, %f)" (xcoord pt1') (ycoord pt1') (xcoord pt2') (ycoord pt2')
          drawCurve pt1' pt2' pt3' pt4'
        printfn "hm %d" curves.Length
        curves |> List.iter drawCurve
 
    interface System.IDisposable with 
        member this.Dispose() = 
            bitmap.Save(filename)
            bitmap.Dispose()

let createBezierCurvePicture (width : int) (height : int) (filename : string) (curves : Curve list) =
  fun rect ->
      use bitmap = new Bitmap(width, height)
      printfn "got bitmap"
      let g = Graphics.FromImage(bitmap)      
      let drawCurve (pt1 : Point) (pt2 : Point) (pt3 : Point) (pt4 : Point) =
        printfn "drawCurve"
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
        printfn "draw curve (%f, %f) -> (%f, %f)" (xcoord pt1) (ycoord pt1) (xcoord pt2) (ycoord pt2)
        let pt1' = pt1 |> toVector |> m |> toPoint
        let pt2' = pt2 |> toVector |> m |> toPoint
        let pt3' = pt3 |> toVector |> m |> toPoint
        let pt4' = pt4 |> toVector |> m |> toPoint
        printfn "draw segment' (%f, %f) -> (%f, %f)" (xcoord pt1') (ycoord pt1') (xcoord pt2') (ycoord pt2')
        drawCurve pt1' pt2' pt3' pt4'
      printfn "hm %d" curves.Length
      curves |> List.iter drawCurve
      bitmap.Save(filename, Imaging.ImageFormat.Png)

let createSegmentPicture (width : int) (height : int) (filename : string) (segments : Segment list) = 
  printfn "createSegmentPicture"
  fun rect -> 
      printfn "rect"
      use bitmap = new Bitmap(width, height)
      printfn "got bitmap"
      let g = Graphics.FromImage(bitmap)      
      let drawLine (pt1 : Point) (pt2 : Point) =
        printfn "drawLine"
        let x1 = xcoord pt1 |> float32
        let y1 = ycoord pt1 |> float32
        let x2 = xcoord pt2 |> float32
        let y2 = ycoord pt2 |> float32
        g.DrawLine(Pens.Black, x1, y1, x2, y2)
      let m = mapper rect
      let toVector pt =
        createVector (xcoord pt) (ycoord pt) 
      let toPoint v = 
        createPoint (x v) (y v)
      let drawSegment seg =
        let pt1 = startPoint seg
        let pt2 = endPoint seg
        printfn "draw segment (%f, %f) -> (%f, %f)" (xcoord pt1) (ycoord pt1) (xcoord pt2) (ycoord pt2)
        let pt1' = pt1 |> toVector |> m |> toPoint
        let pt2' = pt2 |> toVector |> m |> toPoint
        printfn "draw segment' (%f, %f) -> (%f, %f)" (xcoord pt1') (ycoord pt1') (xcoord pt2') (ycoord pt2')
        drawLine pt1' pt2'
      printfn "hm %d" segments.Length
      segments |> List.iter drawSegment
      bitmap.Save(filename, Imaging.ImageFormat.Png)

(*  
Bitmap flag = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int red = 0;
            int white = 11;
            while (white <= 100) {
                flagGraphics.FillRectangle(Brushes.Red, 0, red, 200,10);
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }
            *)