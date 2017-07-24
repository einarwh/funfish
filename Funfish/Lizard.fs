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

let lizardBeziers = [
  createBezier (0.038,  0.070)
               (0.038,  0.120)
               (0.038,  0.188) // 2
  createBezier (0.130,  0.150)
               (0.220,  0.120)
               (0.313,  0.100) // 3
  createBezier (0.313,  0.000)
               (0.313, -0.100)
               (0.313, -0.313) // 4
  createBezier (0.450, -0.200)
               (0.550,  0.000)
               (0.650,  0.075) // 5
  createBezier (0.725,  0.040)
               (0.800,  0.020)
               (0.875,  0.000) // 6
  createBezier (0.700, -0.113)
               (0.563, -0.213)
               (0.563, -0.313) // 7
  createBezier (0.620, -0.300) 
               (0.763, -0.350)
               (0.813, -0.375) // 8
  createBezier (0.800, -0.325) 
               (0.775, -0.300) 
               (0.750, -0.250) // 9
  createBezier (0.800, -0.200)
               (0.900, -0.100)
               (1.000,  0.000) // 10
  createBezier (0.900,  0.100) 
               (0.800,  0.200)
               (0.750,  0.250) // 11
  createBezier (0.950,  0.650)
               (1.100,  0.750)
               (1.250,  0.850) // 12
  createBezier (1.100,  0.925) 
               (1.050,  0.975)
               (1.000,  1.000) // 13
  createBezier (0.950,  0.900)
               (0.900,  0.800)
               (0.850,  0.750) // 14
  createBezier (0.250,  1.250)
               (0.250,  1.250)
               (0.250,  1.250) // 15
  createBezier (0.200,  1.150)
               (0.100,  1.100)
               (0.000,  1.000) // 16
  createBezier (0.250,  0.750)
               (0.250,  0.750)
               (0.250,  0.750) // 17
  createBezier (0.375,  0.813)
               (0.375,  0.813)
               (0.375,  0.813)
  createBezier (0.313,  0.563)
               (0.313,  0.563)
               (0.313,  0.563)
  createBezier (0.000,  0.875)
               (0.000,  0.875)
               (0.000,  0.875)
  createBezier (-0.075,  0.650)
               (-0.075,  0.650)
               (-0.075,  0.650)
  createBezier (0.313,  0.313)
               (0.313,  0.313)
               (0.313,  0.313)
  createBezier (-0.100,  0.313)
               (-0.100,  0.313)
               (-0.100,  0.313)
  createBezier (-0.188,  0.038)
               (-0.188,  0.038)
               (-0.188,  0.038)
]

let lizardPath = Path ({ x = 0.000; y = 0.000}, lizardBeziers) 