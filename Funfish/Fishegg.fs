module Fishegg

open Vectors
open Shapes

let createVector x y = 
  { x = x; y = y }

let createCurve v1 v2 v3 v4 = 
  { point1 = v1; point2 = v2; point3 = v3; point4 = v4 }

let createBezier (x1, y1) (x2, y2) (x3, y3) = 
  { controlPoint1 = { x = x1; y = y1 }
    controlPoint2 = { x = x2; y = y2 } 
    endPoint =      { x = x3; y = y3 } }

let eggfishyBeziers = [
  createBezier (0.110, 0.110) 
               (0.175, 0.175) 
               (0.250, 0.250)
  createBezier (0.372, 0.194) 
               (0.452, 0.132) 
               (0.564, 0.032)
  createBezier (0.730, 0.056) 
               (0.834, 0.042) 
               (1.000, 0.000)
  createBezier (0.896, 0.062) 
               (0.837, 0.107) 
               (0.766, 0.202)     
  createBezier (0.660, 0.208)
               (0.589, 0.217)
               (0.500, 0.250)
  createBezier (0.500, 0.410)
               (0.500, 0.460)
               (0.500, 0.500)
  createBezier (0.500, 0.575)
               (0.500, 0.625)
               (0.500, 0.750)
  createBezier (0.411, 0.783)
               (0.340, 0.792)
               (0.234, 0.798)
  createBezier (0.163, 0.893)
               (0.104, 0.938)
               (0.000, 1.000)
  createBezier (-0.042, 0.834)
               (-0.056, 0.730)
               (-0.032, 0.564)
  createBezier (-0.132, 0.452)
               (-0.194, 0.372)
               (-0.250, 0.250)
  createBezier (-0.150, 0.150)
               (-0.050, 0.050)
               (0.000, 0.000)
]

let eggfishyPath = Path ({ x = 0.000; y = 0.000}, eggfishyBeziers) 

let eggfishyLeftEyeBeziers = [
  createBezier (0.040, 0.772)
               (0.068, 0.696)
               (0.074, 0.685)

  createBezier (0.045, 0.660)
               (0.010, 0.617)
               (-0.008, 0.592)

  createBezier (-0.017, 0.685)
               (-0.012, 0.770)
               (0.004, 0.800)
]

let eggleftEyePath = Path ({ x = 0.004; y = 0.800 }, eggfishyLeftEyeBeziers) 

let eggfishyInnerLeftEyeBeziers = [
  createBezier (0.038, 0.708)
               (0.053, 0.684)
               (0.057, 0.674)

  createBezier (0.035, 0.652)
               (0.010, 0.622)
               (0.008, 0.618)

  createBezier (0.005, 0.685)
               (0.010, 0.700)
               (0.018, 0.720)
]

let egginnerLeftEyePath = Path ({ x = 0.018; y = 0.720}, eggfishyInnerLeftEyeBeziers) 

let eggfishyRightEyeBeziers = [
  createBezier (0.160, 0.840)
               (0.200, 0.790)
               (0.205, 0.782)

  createBezier (0.165, 0.760)
               (0.140, 0.740)
               (0.115, 0.715)

  createBezier (0.095, 0.775)
               (0.090, 0.830)
               (0.095, 0.870)
]

let eggrightEyePath = Path ({ x = 0.095; y = 0.870}, eggfishyRightEyeBeziers) 

let eggfishyInnerRightEyeBeziers = [
  createBezier (0.150, 0.805)
               (0.174, 0.783)
               (0.185, 0.774)

  createBezier (0.154, 0.756)
               (0.139, 0.740)
               (0.132, 0.736)

  createBezier (0.126, 0.760)
               (0.122, 0.795)
               (0.128, 0.810)
]

let egginnerRightEyePath = Path ({ x = 0.128; y = 0.810 }, eggfishyInnerRightEyeBeziers) 

let eggfishySpineCurves = [
  (* main spine *)
  createCurve (createVector 0.840 0.070)
              (createVector 0.350 0.120)
              (createVector 0.140 0.500)
              (createVector 0.025 0.900) 

  (* left fin stem *)
  createCurve (createVector -0.015 0.520)
              (createVector 0.040 0.400)
              (createVector 0.120 0.300)
              (createVector 0.210 0.260)

  (* right fin stem *)         
  createCurve (createVector 0.475 0.270)
              (createVector 0.320 0.350)
              (createVector 0.340 0.600)
              (createVector 0.240 0.770)

  (* right fin bottom delimiter *)
  createCurve (createVector 0.377 0.377)
              (createVector 0.410 0.410)
              (createVector 0.460 0.460)
              (createVector 0.495 0.495)

  (* tail fin stem *)
  createCurve (createVector 0.430 0.165)
              (createVector 0.480 0.175)
              (createVector 0.490 0.220)
              (createVector 0.490 0.230)

  (* tail fin bottom line *)    
  createCurve (createVector 0.452 0.178)
              (createVector 0.510 0.130)
              (createVector 0.540 0.110)
              (createVector 0.600 0.080)

  (* tail fin top line *)
  createCurve (createVector 0.482 0.215)
              (createVector 0.520 0.200)
              (createVector 0.600 0.160)
              (createVector 0.740 0.150)

  (* left fin top line *)
  createCurve (createVector -0.170 0.237) 
              (createVector -0.125 0.355) 
              (createVector -0.065 0.405) 
              (createVector 0.010 0.480)   

  (* left fin middle line *)
  createCurve (createVector -0.110 0.175) 
              (createVector -0.060 0.250)
              (createVector -0.030 0.300)  
              (createVector 0.080 0.365)     
              
  (* left fin bottom line *)
  createCurve (createVector -0.045 0.115)
              (createVector 0.010 0.180) 
              (createVector 0.060 0.230) 
              (createVector 0.170 0.280) 

  (* right fin top line *)
  createCurve (createVector 0.270 0.700) 
              (createVector 0.340 0.720) 
              (createVector 0.426 0.710) 
              (createVector 0.474 0.692)     
              
  (* right fin middle line *)
  createCurve (createVector 0.310 0.570) 
              (createVector 0.400 0.622) 
              (createVector 0.435 0.618) 
              (createVector 0.474 0.615) 
              
  (* right fin bottom line *)
  createCurve (createVector 0.350 0.435) 
              (createVector 0.400 0.505) 
              (createVector 0.422 0.520) 
              (createVector 0.474 0.538)    
]

let eggfishyLines = eggfishySpineCurves |> List.map (fun c -> ("secondary", Curve c))

let eggfishShapes = 
  ("primary", eggfishyPath) :: 
  ("eye-outer", eggleftEyePath) :: 
  ("eye-outer", eggrightEyePath) :: 
  ("eye-inner", egginnerLeftEyePath) :: 
  ("eye-inner", egginnerRightEyePath) :: 
  eggfishyLines
