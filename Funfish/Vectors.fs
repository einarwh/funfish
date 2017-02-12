module Vectors

open Points

type Vector = Point

let createVector x y : Vector = createPoint x y

let x (v : Vector) = xcoord v

let y (v : Vector) = ycoord v

let add (v1 : Vector) (v2 : Vector) : Vector =
  createVector (x v1 + x v2) (y v1 + y v2)

let sub (v1 : Vector) (v2 : Vector) : Vector =
  createVector (x v1 - x v2) (y v1 - y v2)

let scale (s : float) (v : Vector) =
  createVector (s * x v) (s * y v)
  