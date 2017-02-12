module Curves

open Points

type Curve = 
  { point1 : Point
    point2 : Point
    point3 : Point
    point4 : Point }

let createCurve pt1 pt2 pt3 pt4 = { point1 = pt1; point2 = pt2; point3 = pt3; point4 = pt4 }

let point1 c = c.point1

let point2 c = c.point2

let point3 c = c.point3

let point4 c = c.point4
