module Lizard

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

let createCircle (x, y) r = 
  { center = { x = x; y = y }
    radius = { x = r; y = 0. } }

let lizardBeziers = [
  createBezier (0.020,  0.050)
               (0.030,  0.120)
               (0.025,  0.185) // 2
  createBezier (0.100,  0.120)
               (0.200,  0.085)
               (0.310,  0.090) // 3
  createBezier (0.310,  0.000)
               (0.310, -0.100)
               (0.310, -0.313) // 4
  createBezier (0.450, -0.170)
               (0.500, -0.100)
               (0.625,  0.070) // 5
  createBezier (0.700,  0.040)
               (0.780,  0.010)
               (0.850,  0.000) // 6
  createBezier (0.700, -0.070)
               (0.563, -0.180)
               (0.563, -0.313) // 7
  createBezier (0.680, -0.310) 
               (0.780, -0.410)
               (0.813, -0.375) // 8
  createBezier (0.792, -0.333) 
               (0.771, -0.292) 
               (0.750, -0.250) // 9
  createBezier (0.800, -0.200)
               (0.900, -0.100)
               (1.000,  0.000) // 10
  createBezier (0.900,  0.100) 
               (0.800,  0.200)
               (0.750,  0.250) // 11
  createBezier (0.900,  0.650)
               (1.050,  0.750)
               (1.250,  0.850) // 12
  createBezier (1.200,  0.940) 
               (1.100,  0.980)
               (1.000,  1.000) // 13
  createBezier (0.980,  0.900)
               (0.940,  0.800)
               (0.850,  0.750) // 14
  createBezier (0.750,  0.950)
               (0.650,  1.100)
               (0.250,  1.250) // 15
  createBezier (0.200,  1.200)
               (0.100,  1.100)
               (0.000,  1.000) // 16
  createBezier (0.050,  0.950)
               (0.150,  0.850)
               (0.250,  0.750) // 17
  createBezier (0.375,  0.813)
               (0.375,  0.813)
               (0.375,  0.813) // 18
  createBezier (0.410,  0.780)
               (0.310,  0.680)
               (0.313,  0.563) // 19
  createBezier (0.180,  0.563)
               (0.070,  0.700)
               (0.000,  0.850) // 20
  createBezier (-0.010,  0.780) 
               (-0.040,  0.700)
               (-0.070,  0.625) // 21
  createBezier (0.100,  0.500) 
               (0.170,  0.450)
               (0.313,  0.310) // 22
  createBezier (0.100,  0.310) 
               (0.000,  0.310)
               (-0.090,  0.310) // 23
  createBezier (-0.085,  0.200)
               (-0.120,  0.100)
               (-0.185,  0.025) // 24
  createBezier (-0.120,  0.030)
               (-0.050,  0.020)
               (0.000,  0.000) // 0
]

let lizardPath = Path ({ x = 0.000; y = 0.000}, lizardBeziers) 

let lizardEyeOuterCircles = [
  createCircle (0.260, 1.100) 0.070
  createCircle (0.260, 0.900) 0.070
]

let lizardEyeInnerCircles = [
  createCircle (0.260, 1.100) 0.050
  createCircle (0.260, 0.900) 0.050
]

let mainSpineCurves = [
  (* main spine *)
  createCurve (createVector 0.350 -0.200)
              (createVector 0.700 0.900)
              (createVector 0.650 1.000)
              (createVector 0.075 1.000) 
]

let namedCurves name curves = 
  curves |> List.map (fun c -> (name, Curve c))

let namedCircles name circles = 
  circles |> List.map (fun c -> (name, Circle c))

let mainSpine = namedCurves "secondary" mainSpineCurves
let lizardEyesOuter = namedCircles "secondary" lizardEyeOuterCircles
let lizardEyesInner = namedCircles "primary" lizardEyeInnerCircles

let lizardShapes = 
  ("primary", lizardPath) :: 
  mainSpine @
  lizardEyesOuter @
  lizardEyesInner

