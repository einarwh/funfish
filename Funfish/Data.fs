module Data

open Points
open Segments
open Curves

let fSegments = 
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

let pSegments = 
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

let fishCurves = [
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
  createCurve (createPoint 0.320 0.702) // C17 -
              (createPoint 0.390 0.728) //
              (createPoint 0.440 0.728) //
              (createPoint 0.487 0.683) //    
  createCurve (createPoint 0.344 0.600) // C18 -
              (createPoint 0.415 0.650) //
              (createPoint 0.435 0.650) //
              (createPoint 0.489 0.622) //    
  createCurve (createPoint 0.353 0.496) // C19 -
              (createPoint 0.390 0.564) //
              (createPoint 0.410 0.568) //
              (createPoint 0.489 0.553) //   
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
