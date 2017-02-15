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
    let rect = createRectangle (createVector 0. 0.)
                               (createVector 0. 400.)
                               (createVector 400. 0.)

    let fsegs = 
      let pt1 =  (createPoint 0.30 0.20) 
      let pt2 =  (createPoint 0.40 0.20)
      let pt3 =  (createPoint 0.40 0.45)
      let pt4 =  (createPoint 0.60 0.45)
      let pt5 =  (createPoint 0.60 0.55)
      let pt6 =  (createPoint 0.40 0.55)
      let pt7 =  (createPoint 0.40 0.70)
      let pt8 =  (createPoint 0.70 0.70)
      let pt9 =  (createPoint 0.70 0.80)
      let pt10 = (createPoint 0.30 0.80)
      [ createSegment pt1 pt2
        createSegment pt2 pt3
        createSegment pt3 pt4
        createSegment pt4 pt5
        createSegment pt5 pt6
        createSegment pt6 pt7
        createSegment pt7 pt8
        createSegment pt8 pt9
        createSegment pt9 pt10
        createSegment pt10 pt1 ]

    let psegs = 
      let pt1 =  (createPoint 0.30 0.20) 
      let pt2 =  (createPoint 0.40 0.20)
      let pt3 =  (createPoint 0.40 0.45)
      let pt4 =  (createPoint 0.70 0.45)
      let pt5 =  (createPoint 0.60 0.55)
      let pt6 =  (createPoint 0.40 0.55)
      let pt7 =  (createPoint 0.40 0.70)
      let pt8 =  (createPoint 0.60 0.70)
      let pt9 =  (createPoint 0.70 0.80)
      let pt10 = (createPoint 0.30 0.80)
      [ createSegment pt1 pt2
        createSegment pt2 pt3
        createSegment pt3 pt4
        createSegment pt4 pt9
        createSegment pt5 pt6
        createSegment pt6 pt7
        createSegment pt7 pt8
        createSegment pt8 pt5
        createSegment pt9 pt10
        createSegment pt10 pt1 ]

    let curves = [
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
      createCurve (createPoint 0.340 0.660) 
                  (createPoint 0.400 0.675)
                  (createPoint 0.430 0.675)
                  (createPoint 0.475 0.650)    
      createCurve (createPoint 0.350 0.580) 
                  (createPoint 0.415 0.600)
                  (createPoint 0.430 0.605)
                  (createPoint 0.470 0.580)    
      createCurve (createPoint 0.360 0.480) 
                  (createPoint 0.415 0.520)
                  (createPoint 0.430 0.530)
                  (createPoint 0.478 0.510)    
      createCurve (createPoint 0.465 0.422) 
                  (createPoint 0.470 0.390)
                  (createPoint 0.480 0.385)
                  (createPoint 0.490 0.380)    
      createCurve (createPoint 0.430 0.390) 
                  (createPoint 0.445 0.350)
                  (createPoint 0.450 0.330)
                  (createPoint 0.490 0.315)    
      createCurve (createPoint -0.190 0.270) 
                  (createPoint -0.140 0.396)
                  (createPoint -0.110 0.426)
                  (createPoint -0.025 0.445)    
      createCurve (createPoint -0.140 0.215) 
                  (createPoint -0.100 0.315)
                  (createPoint -0.070 0.350)
                  (createPoint 0.020 0.370)    
      createCurve (createPoint -0.085 0.150) 
                  (createPoint -0.040 0.250)
                  (createPoint -0.010 0.280)
                  (createPoint 0.070 0.290)    
      createCurve (createPoint -0.040 0.080) 
                  (createPoint 0.010 0.180)
                  (createPoint 0.060 0.220)
                  (createPoint 0.125 0.235)    
      createCurve (createPoint 0.012 0.677) 
                  (createPoint 0.040 0.685)
                  (createPoint 0.070 0.700)
                  (createPoint 0.090 0.712)    
      createCurve (createPoint 0.012 0.677) 
                  (createPoint -0.005 0.750)
                  (createPoint -0.005 0.760)
                  (createPoint 0.030 0.812)    
      createCurve (createPoint 0.030 0.812) 
                  (createPoint 0.075 0.770)
                  (createPoint 0.085 0.760)
                  (createPoint 0.090 0.712)    
      createCurve (createPoint 0.125 0.720) 
                  (createPoint 0.150 0.732)
                  (createPoint 0.175 0.742)
                  (createPoint 0.200 0.750)    
      createCurve (createPoint 0.125 0.720) 
                  (createPoint 0.110 0.795)
                  (createPoint 0.110 0.810)
                  (createPoint 0.125 0.835)    
      createCurve (createPoint 0.125 0.835) 
                  (createPoint 0.160 0.815)
                  (createPoint 0.180 0.790)
                  (createPoint 0.200 0.750)    
    ]

    use painter = new BitmapPainter(800, 800, "fish.png")
    let fish = painter.CreateBezierCurvePicture curves
    let maket f = 
      let fish2 = f |> toss |> flip
      let fish3 = fish2 |> turn |> turn |> turn
      let t = over fish2 fish3 |> over f
      t

    let fish2 = fish |> toss |> flip
    let fish3 = fish2 |> turn |> turn |> turn
    let t = over fish2 fish3 |> over fish

    let tify f = 
      let fish2 = flip (toss f)
      let fish3 = turn (turn (turn fish2))
      over f (over fish2 fish3)
      //over fish2 fish3 |> over f

    let uify f = 
      let fish2 = f |> toss |> flip
      let u1 = over fish2 (fish2 |> turn) 
      let u2 = over (fish2 |> turn |> turn) (fish2 |> turn |> turn |> turn)
      over u1 u2

    //let v = t |> turn |> cycle
    //let v = t |> turn |> cycle
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

    use painterLimit = new BitmapPainter(800, 800, "limit.png")
    let limit = painterLimit.CreateBezierCurvePicture curves

    rect |> (limit |> turn)

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
    rect |> (squarelimit2 |> turn)

    //rect |> (fish |> turn)
    //rect |> (aboveRatio 1 2 fish (fish |> turn) |> turn)
    //rect |> (besideRatio 1 2 fish (fish |> turn) |> turn)
    //rect |> (squarelimit2 |> turn)

    use letterfPainter = new BitmapPainter(800, 800, "letterf.png")
    let letterf' = letterfPainter.CreateSegmentPicture fsegs

    rect |> (letterf' |> turn)

    use letterpPainter = new BitmapPainter(800, 800, "letterp.png")
    let letterp' = letterpPainter.CreateSegmentPicture psegs

    rect |> (letterp' |> turn)

    use letterPainter = new BitmapPainter(800, 800, "letter.png")
    let letterf = letterPainter.CreateSegmentPicture fsegs
    let letterp = letterPainter.CreateSegmentPicture psegs

    //rect |> (besideRatio 1 1 letterf letterp |> turn)
    //rect |> (quartet letterf letterp (flip letterf) (flip letterp) |> turn)
    rect |> (above (beside letterf letterf) letterf |> turn)

    0 // return an integer exit code
