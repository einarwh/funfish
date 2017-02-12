module Mapping

open Vectors
open Rectangles

let mapper (rect : Rectangle) = 
  fun v ->
    add (add (scale (x v) (horizontal rect))
             (scale (y v) (vertical rect)))
        (origin rect)
