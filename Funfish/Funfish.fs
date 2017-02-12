module Funfish

open Points
open Vectors
open Rectangles

open Segments
open Curves
open Pictures
open Mapping
open Drawing

let fish : Picture =
  fun rect -> ()    

open System.Drawing

[<EntryPoint>]
let main argv =
    printfn "%A" argv
    let segments = [ 
        createSegment (createPoint 0.010 0.040) (createPoint 0.803 0.920)
        createSegment (createPoint 0.239 0.737) (createPoint 0.380 0.860)
        createSegment (createPoint 0.930 0.054) (createPoint 0.012 0.427) ]
    let rect = createRectangle (createVector 0. 0.)
                               (createVector 0. 400.)
                               (createVector 400. 0.)

    let curves = [
      (*
      createCurve (createPoint 0.010 0.040) 
                  (createPoint 0.303 0.490)
                  (createPoint 0.200 0.700)
                  (createPoint 0.803 0.920)*)
      createCurve (createPoint 0.110 0.685) 
                  (createPoint 0.200 0.300)
                  (createPoint 0.400 0.150)
                  (createPoint 0.800 0.080)   
      createCurve (createPoint 0.550 0.020) 
                  (createPoint 0.700 0.050)
                  (createPoint 0.800 0.050)
                  (createPoint 1.000 0.000)   
      createCurve (createPoint 0.200 0.200) 
                  (createPoint 0.350 0.175)
                  (createPoint 0.425 0.100)
                  (createPoint 0.550 0.020)            
      createCurve (createPoint 0.000 0.000) 
                  (createPoint 0.075 0.075)
                  (createPoint 0.125 0.125)
                  (createPoint 0.200 0.200)            
      createCurve (createPoint -0.250 0.300) 
                  (createPoint -0.200 0.225)
                  (createPoint -0.100 0.100)
                  (createPoint 0.000 0.000)            
      createCurve (createPoint -0.250 0.300) 
                  (createPoint -0.205 0.410)
                  (createPoint -0.125 0.525)
                  (createPoint -0.050 0.600)   
      createCurve (createPoint -0.050 0.600) 
                  (createPoint 0.000 0.380)
                  (createPoint 0.100 0.280)
                  (createPoint 0.200 0.200)            
      createCurve (createPoint -0.050 0.600) 
                  (createPoint -0.070 0.700)
                  (createPoint -0.055 0.850)
                  (createPoint 0.000 1.000)
      createCurve (createPoint 0.000 1.000) 
                  (createPoint 0.100 0.950)
                  (createPoint 0.200 0.860)
                  (createPoint 0.275 0.750)
      createCurve (createPoint 0.275 0.750) 
                  (createPoint 0.350 0.650)
                  (createPoint 0.310 0.430)
                  (createPoint 0.375 0.375)    
      createCurve (createPoint 0.375 0.375) 
                  (createPoint 0.400 0.350)
                  (createPoint 0.450 0.300)
                  (createPoint 0.500 0.250)    
      createCurve (createPoint 0.500 0.250) 
                  (createPoint 0.600 0.210)
                  (createPoint 0.700 0.190)
                  (createPoint 0.800 0.200)    
      createCurve (createPoint 0.800 0.200) 
                  (createPoint 0.860 0.120)
                  (createPoint 0.920 0.060)
                  (createPoint 1.000 0.000)    
      createCurve (createPoint 0.275 0.750) 
                  (createPoint 0.350 0.750)
                  (createPoint 0.450 0.725)
                  (createPoint 0.500 0.700)    
      createCurve (createPoint 0.500 0.700) 
                  (createPoint 0.500 0.625)
                  (createPoint 0.500 0.575)
                  (createPoint 0.500 0.500)    
      createCurve (createPoint 0.500 0.500) 
                  (createPoint 0.460 0.450)
                  (createPoint 0.425 0.430)
                  (createPoint 0.375 0.375)    
    ]

    Drawing.createSegmentPicture 400 400 "segments.png" segments rect

    //Drawing.createBezierCurvePicture 400 400 "curves.png" curves rect

    let bezierPicture1 = Drawing.createBezierCurvePicture 800 800 "curves1.png" curves
    let bezierPicture2 = Drawing.createBezierCurvePicture 800 800 "curves2.png" curves
    let bezierPicture3 = Drawing.createBezierCurvePicture 800 800 "curves3.png" curves
    let bezierPicture4 = Drawing.createBezierCurvePicture 800 800 "curves4.png" curves

    rect |> bezierPicture1

    rect |> (bezierPicture2 |> turn)

    rect |> (bezierPicture3 |> turn |> flip) 

    //rect |> (bezierPicture4 |> toss |> turn |> flip) 

    let p = (bezierPicture4 |> toss) 

    p rect

    0 // return an integer exit code
