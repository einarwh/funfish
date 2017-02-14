module Rectangles

open Vectors

type Rectangle = { origin : Vector; horizontal : Vector; vertical : Vector }

// TODO: Eliminate constructors and selectors, just expose abstract operations on rectangles?
// Or perhaps just eliminate selectors? Need some way of creating initial rectangle.

let createRectangle origin horizontal vertical : Rectangle = 
  { origin = origin
    horizontal = horizontal 
    vertical = vertical }

let origin r = r.origin

let horizontal r = r.horizontal

let vertical r = r.vertical

// 3A - 54:25 (Aka rotate90 | rot)
// p(a + b, c, -b) => a -> a + b, b -> c, c -> -b   
// p(o + h, v, -h)
let turn (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  createRectangle (add o h) v (scale -1. h)

// p(a + b, -b, c) 
// a <- a + b
// b <- -b 
// c <- c
let flip (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  createRectangle (add o h) (scale -1. h) v
 
// p(a + (b + c) / 2, (b + c) / 2, (c − b) / 2)
// a <- a + (b + c) / 2
// b <- (b + c) / 2
// c <- (c − b) / 2
let toss (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  let half vect = scale 0.5 vect
  let o' = add o (add h v |> half) // a + (b + c) | o + (h + v)
  let h' = add h v |> half // (b + c) / 2 | (h + v) / 2
  let v' = sub v h |> half // (c - b) / 2 | (v - h) / 2
  createRectangle o' h' v'

let scaleHorizontally (s : float) (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  createRectangle o (scale s h) v

let scaleVertically (s : float) (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  createRectangle o h (scale s v)

let moveHorizontally (offset : float) (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  createRectangle (add o (scale offset h)) h v

let moveVertically (offset : float) (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  createRectangle (add o (scale offset v)) h v

let splitHorizontally (fraction : float) (r : Rectangle) : (Rectangle * Rectangle) = 
  let left = r |> scaleHorizontally fraction
  let right = r |> moveHorizontally fraction |> scaleHorizontally (1. - fraction)
  (left, right)

let splitVertically (fraction : float) (r : Rectangle) : (Rectangle * Rectangle) =
  let bottom = r |> scaleVertically fraction
  let top = r |> moveVertically fraction |> scaleVertically (1. - fraction) 
  (bottom, top)
 
