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
// p(a + b, c, -b)   
let turn (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  createRectangle (add o h) v (scale -1. h)
    
let flip (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  createRectangle (add o h) (scale -1. h) v
 
let toss (r : Rectangle) : Rectangle = 
  let o = origin r
  let h = horizontal r
  let v = vertical r
  let o' = add o (add h v) // a + (b + c) | o + (h + v)
  let h' = scale 0.5 (add h v) // (b + c) / 2 | (h + v) / 2
  let v' = scale 0.5 (sub v h) // (c - b) / 2 | (v - h) / 2
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