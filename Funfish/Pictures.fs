module Pictures

open Rectangles

type Picture = (Rectangle -> Unit)

// 3A - 43:14 coord-map

// 3A - ?
let rotate (degrees : int) (p : Picture) : Picture =
  p

// 3A - 54:25 (Aka rotate90 | rot)
// p(a + b, c, -b)   
let turn (p : Picture) : Picture = 
  Rectangles.turn >> p

// p(a + b, -b, c)    
let flip (p : Picture) : Picture = 
  Rectangles.flip >> p

// Aka "rot45"
// p(a + (b + c)/2,(b + c)/2,(c − b)/2)
// TBD
// a = o, b = h, c = v
let toss (p : Picture) : Picture = 
  Rectangles.toss >> p

// 3A - 53:05
let beside' (p1 : Picture) (p2: Picture) (a : float) : Picture =
  fun rect ->
    let o = origin rect
    let h = horizontal rect
    let v = vertical rect
    let r1 = createRectangle o (Vectors.scale a h) v
    let r2 = createRectangle (Vectors.add o (Vectors.scale a h)) (Vectors.scale (1. - a) h) v
    p1 r1
    p2 r2

let beside (p1 : Picture) (p2: Picture) (a : float) : Picture =
  fun rect ->
    let r1 = rect |> scaleHorizontally a
    let r2 = rect |> scaleHorizontally (1. - a) |> moveHorizontally a 
    p1 r1
    p2 r2

let above' (p1 : Picture) (p2: Picture) (a : float) : Picture =
  fun rect ->
    let o = origin rect
    let h = horizontal rect
    let v = vertical rect
    let r1 = createRectangle o h (Vectors.scale a v) 
    let r2 = createRectangle (Vectors.add o (Vectors.scale a v)) h (Vectors.scale (1. - a) v)
    p1 r1
    p2 r2

let above (p1 : Picture) (p2: Picture) (a : float) : Picture =
  fun rect ->
    let r1 = rect |> scaleVertically a 
    let r2 = rect |> scaleVertically (1. - a) |> moveVertically a
    p1 r1
    p2 r2

