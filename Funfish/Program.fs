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
                               (createVector 0. 600.)
                               (createVector 600. 0.)

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
      createCurve (createPoint 0.125 0.692) // C1
                  (createPoint 0.250 0.330) //
                  (createPoint 0.370 0.240) //
                  (createPoint 0.812 0.080) //  
      createCurve (createPoint 0.565 0.032) // C2
                  (createPoint 0.730 0.054) //
                  (createPoint 0.800 0.050) //
                  (createPoint 1.000 0.000) //
      createCurve (createPoint 0.255 0.245) // C3
                  (createPoint 0.372 0.200) //
                  (createPoint 0.452 0.140) //
                  (createPoint 0.565 0.032) //         
      createCurve (createPoint 0.000 0.000) // C4
                  (createPoint 0.110 0.100) //
                  (createPoint 0.170 0.160) //
                  (createPoint 0.255 0.245) //         
      createCurve (createPoint -0.245 0.250) // C5
                  (createPoint -0.150 0.160) //
                  (createPoint -0.090 0.100) //
                  (createPoint 0.000 0.000) //           
      createCurve (createPoint -0.245 0.250) // C6
                  (createPoint -0.180 0.390) //
                  (createPoint -0.120 0.470) //
                  (createPoint -0.025 0.560) //  
      createCurve (createPoint -0.025 0.560) // C7
                  (createPoint 0.055 0.355) //
                  (createPoint 0.080 0.330) //
                  (createPoint 0.255 0.245) //         
      createCurve (createPoint -0.025 0.560) // C8
                  (createPoint -0.040 0.670) //
                  (createPoint -0.040 0.780) //
                  (createPoint 0.000 1.000) //
      createCurve (createPoint 0.000 1.000) // C9
                  (createPoint 0.160 0.910) //
                  (createPoint 0.200 0.860) //
                  (createPoint 0.245 0.785) //
      createCurve (createPoint 0.245 0.785) // C10
                  (createPoint 0.350 0.650)
                  (createPoint 0.310 0.430)
                  (createPoint 0.382 0.372)    
      createCurve (createPoint 0.382 0.372) // C11
                  (createPoint 0.400 0.350)
                  (createPoint 0.450 0.300)
                  (createPoint 0.515 0.245)    
      createCurve (createPoint 0.515 0.245) // C12 
                  (createPoint 0.600 0.210)
                  (createPoint 0.700 0.190)
                  (createPoint 0.765 0.205)    
      createCurve (createPoint 0.765 0.205) // C13
                  (createPoint 0.860 0.120) 
                  (createPoint 0.920 0.060)
                  (createPoint 1.000 0.000)    
      createCurve (createPoint 0.245 0.785) // C14
                  (createPoint 0.360 0.790) //
                  (createPoint 0.420 0.780) //
                  (createPoint 0.500 0.750) //  
      createCurve (createPoint 0.500 0.750) // C15 
                  (createPoint 0.500 0.625)
                  (createPoint 0.500 0.575)
                  (createPoint 0.500 0.500)    
      createCurve (createPoint 0.500 0.500) // C16 -
                  (createPoint 0.460 0.450)
                  (createPoint 0.425 0.430)
                  (createPoint 0.375 0.375)    
      createCurve (createPoint 0.340 0.660) // C17 -
                  (createPoint 0.400 0.675)
                  (createPoint 0.430 0.675)
                  (createPoint 0.475 0.650)    
      createCurve (createPoint 0.350 0.580) // C18 -
                  (createPoint 0.415 0.600)
                  (createPoint 0.430 0.605)
                  (createPoint 0.470 0.580)    
      createCurve (createPoint 0.360 0.480) // C19 -
                  (createPoint 0.415 0.520)
                  (createPoint 0.430 0.530)
                  (createPoint 0.478 0.510)    
      createCurve (createPoint 0.465 0.422) // C20 -
                  (createPoint 0.470 0.390)
                  (createPoint 0.480 0.385)
                  (createPoint 0.490 0.380)    
      createCurve (createPoint 0.430 0.390) // C21 - 
                  (createPoint 0.445 0.350)
                  (createPoint 0.450 0.330)
                  (createPoint 0.490 0.315)    
      createCurve (createPoint -0.190 0.270) // C22 -
                  (createPoint -0.140 0.396)
                  (createPoint -0.110 0.426)
                  (createPoint -0.025 0.445)    
      createCurve (createPoint -0.140 0.215) // C23 -
                  (createPoint -0.100 0.315)
                  (createPoint -0.070 0.350)
                  (createPoint 0.020 0.370)    
      createCurve (createPoint -0.085 0.150) // C24 -
                  (createPoint -0.040 0.250)
                  (createPoint -0.010 0.280)
                  (createPoint 0.070 0.290)    
      createCurve (createPoint -0.040 0.080) // C25 - 
                  (createPoint 0.010 0.180)
                  (createPoint 0.060 0.220)
                  (createPoint 0.125 0.235)    
      createCurve (createPoint 0.058 0.655) // C26 -
                  (createPoint 0.080 0.670) //
                  (createPoint 0.090 0.680) //
                  (createPoint 0.104 0.700) // 
      createCurve (createPoint 0.058 0.655) // C27 
                  (createPoint 0.042 0.710) //
                  (createPoint 0.042 0.760) //
                  (createPoint 0.060 0.815) //   
      createCurve (createPoint 0.060 0.815) // C28 -
                  (createPoint 0.092 0.812) //
                  (createPoint 0.100 0.730) //
                  (createPoint 0.104 0.700) //   
      createCurve (createPoint 0.135 0.711) // C29 -
                  (createPoint 0.150 0.722) //
                  (createPoint 0.175 0.737) //
                  (createPoint 0.197 0.748) // 
      createCurve (createPoint 0.135 0.711) // C30 -
                  (createPoint 0.110 0.795) //
                  (createPoint 0.110 0.810) //
                  (createPoint 0.115 0.838) // 
      createCurve (createPoint 0.115 0.838) // C31 -
                  (createPoint 0.150 0.805) //
                  (createPoint 0.177 0.780) //
                  (createPoint 0.197 0.748) //   
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
