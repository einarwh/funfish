module Boxes

open Vectory

type Box = 
  { a : Vector 
    b : Vector
    c : Vector }

let turn { a = a; b = b; c = c } = 
  { a = a + b
    b = c 
    c = (-1. * b) }

let flip { a = a; b = b; c = c } = 
  { a = a + b
    b = -b
    c = c }
 
let toss { a = a; b = b; c = c } = 
  { a = a + (b + c) / 2.
    b = (b + c) / 2.
    c = (c - b) / 2. }

let scaleHorizontally s { a = a; b = b; c = c } =
  { a = a
    b = b * s
    c = c } 

let scaleVertically s { a = a; b = b; c = c } = 
  { a = a
    b = b 
    c = c * s }

let moveHorizontally offset { a = a; b = b; c = c } = 
  { a = a + b * offset
    b = b
    c = c }
  
let moveVertically offset { a = a; b = b; c = c } = 
  { a = a + c * offset
    b = b
    c = c }

let splitHorizontally f box =
  let top = box |> moveVertically (1. - f) |> scaleVertically f  
  let bottom = box |> scaleVertically (1. - f)
  (top, bottom)

let splitVertically f box = 
  let left = box |> scaleHorizontally f
  let right = box |> moveHorizontally f |> scaleHorizontally (1. - f)
  (left, right)

