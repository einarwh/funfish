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
  createCurve (createPoint 0.116 0.702) // C1
              (createPoint 0.260 0.295) //
              (createPoint 0.330 0.258) //
              (createPoint 0.815 0.078) //  
  createCurve (createPoint 0.564 0.032) // C2
              (createPoint 0.730 0.056) //
              (createPoint 0.834 0.042) //
              (createPoint 1.000 0.000) //
  createCurve (createPoint 0.250 0.250) // C3
              (createPoint 0.372 0.194) //
              (createPoint 0.452 0.132) //
              (createPoint 0.564 0.032) //         
  createCurve (createPoint 0.000 0.000) // C4
              (createPoint 0.110 0.110) //
              (createPoint 0.175 0.175) //
              (createPoint 0.250 0.250) //         
  createCurve (createPoint -0.250 0.250) // C5
              (createPoint -0.150 0.150) //
              (createPoint -0.090 0.090) //
              (createPoint 0.000 0.000) //           
  createCurve (createPoint -0.250 0.250) // C6
              (createPoint -0.194 0.372) //
              (createPoint -0.132 0.452) //
              (createPoint -0.032 0.564) //  
  createCurve (createPoint -0.032 0.564) // C7
              (createPoint 0.055 0.355) //
              (createPoint 0.080 0.330) //
              (createPoint 0.250 0.250) //         
  createCurve (createPoint -0.032 0.564) // C8
              (createPoint -0.056 0.730) //
              (createPoint -0.042 0.834) //
              (createPoint 0.000 1.000) //
  createCurve (createPoint 0.000 1.000) // C9
              (createPoint 0.104 0.938) //
              (createPoint 0.163 0.893) //
              (createPoint 0.234 0.798) //
  createCurve (createPoint 0.234 0.798) // C10
              (createPoint 0.368 0.650)
              (createPoint 0.232 0.540)
              (createPoint 0.377 0.377)    
  createCurve (createPoint 0.377 0.377) // C11
              (createPoint 0.400 0.350)
              (createPoint 0.450 0.300)
              (createPoint 0.500 0.250)    
  createCurve (createPoint 0.500 0.250) // C12 
              (createPoint 0.589 0.217)
              (createPoint 0.660 0.208)
              (createPoint 0.766 0.202)    
  createCurve (createPoint 0.766 0.202) // C13
              (createPoint 0.837 0.107) //
              (createPoint 0.896 0.062) //
              (createPoint 1.000 0.000) //    
  createCurve (createPoint 0.234 0.798) // C14
              (createPoint 0.340 0.792) //
              (createPoint 0.411 0.783) //
              (createPoint 0.500 0.750) //  
  createCurve (createPoint 0.500 0.750) // C15 
              (createPoint 0.500 0.625) //
              (createPoint 0.500 0.575) //
              (createPoint 0.500 0.500) // 
  createCurve (createPoint 0.500 0.500) // C16 -
              (createPoint 0.460 0.460) //
              (createPoint 0.410 0.410) //
              (createPoint 0.377 0.377) //   
  createCurve (createPoint 0.315 0.710) // C17 -
              (createPoint 0.378 0.732) //
              (createPoint 0.426 0.726) //
              (createPoint 0.487 0.692) //    
  createCurve (createPoint 0.340 0.605) // C18 -
              (createPoint 0.400 0.642) //
              (createPoint 0.435 0.647) //
              (createPoint 0.489 0.626) //    
  createCurve (createPoint 0.348 0.502) // C19 -
              (createPoint 0.400 0.564) //
              (createPoint 0.422 0.568) //
              (createPoint 0.489 0.563) //   
  createCurve (createPoint 0.451 0.418) // C20 -
              (createPoint 0.465 0.400) //
              (createPoint 0.480 0.385) //
              (createPoint 0.490 0.381) //    
  createCurve (createPoint 0.421 0.388) // C21 - 
              (createPoint 0.440 0.350) //
              (createPoint 0.455 0.335) //
              (createPoint 0.492 0.325) //    
  createCurve (createPoint -0.170 0.237) // C22 -
              (createPoint -0.125 0.355) //
              (createPoint -0.065 0.405) //
              (createPoint 0.002 0.436) //   
  createCurve (createPoint -0.121 0.188) // C23 -
              (createPoint -0.060 0.300) //
              (createPoint -0.030 0.330) // 
              (createPoint 0.040 0.375) //    
  createCurve (createPoint -0.058 0.125) // C24 -
              (createPoint -0.010 0.240) //
              (createPoint 0.030 0.280) //
              (createPoint 0.100 0.321) // 
  createCurve (createPoint -0.022 0.063) // C25 - 
              (createPoint 0.060 0.200) //
              (createPoint 0.100 0.240) // 
              (createPoint 0.160 0.282) //    
  createCurve (createPoint 0.053 0.658) // C26 -
              (createPoint 0.075 0.677) //
              (createPoint 0.085 0.687) //
              (createPoint 0.098 0.700) // 
  createCurve (createPoint 0.053 0.658) // C27 
              (createPoint 0.042 0.710) //
              (createPoint 0.042 0.760) //
              (createPoint 0.053 0.819) //   
  createCurve (createPoint 0.053 0.819) // C28 -
              (createPoint 0.085 0.812) //
              (createPoint 0.092 0.752) //
              (createPoint 0.098 0.700) //   
  createCurve (createPoint 0.130 0.718) // C29 -
              (createPoint 0.150 0.730) //
              (createPoint 0.175 0.745) //
              (createPoint 0.187 0.752) // 
  createCurve (createPoint 0.130 0.718) // C30 -
              (createPoint 0.110 0.795) //
              (createPoint 0.110 0.810) //
              (createPoint 0.112 0.845) // 
  createCurve (createPoint 0.112 0.845) // C31 -
              (createPoint 0.150 0.805) //
              (createPoint 0.172 0.780) // 
              (createPoint 0.187 0.752) //   
]
