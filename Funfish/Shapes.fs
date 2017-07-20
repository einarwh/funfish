﻿module Shapes

open Vectory

type PolygonShape = 
  { points : Vector list }

type CurveShape = 
  { point1 : Vector
    point2 : Vector
    point3 : Vector
    point4 : Vector }

type BezierShape = 
  { controlPoint1 : Vector
    controlPoint2 : Vector
    endPoint : Vector }

type Shape =
  | Polygon of PolygonShape
  | Curve of CurveShape
  | Path of Vector * BezierShape list

