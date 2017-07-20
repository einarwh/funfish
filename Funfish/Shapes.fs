module Shapes

open Vectory

type PolygonShape = 
  { points : Vector list }

type Shape =
  | Polygon of PolygonShape

