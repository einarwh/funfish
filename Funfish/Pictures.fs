module Pictures

open Rectangles

type Picture = (Rectangle -> Unit)

// 3A - 43:14 coord-map

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
let beside (p1 : Picture) (p2: Picture) (a : float) : Picture =
  fun rect ->
    let r1, r2 = splitHorizontally a rect
    p1 r1
    p2 r2

let above (p1 : Picture) (p2: Picture) (a : float) : Picture =
  fun rect ->
    let r1, r2 = splitVertically a rect
    p1 r1
    p2 r2

let over (p1 : Picture) (p2: Picture) : Picture = 
  fun rect ->
    p1 rect
    p2 rect

