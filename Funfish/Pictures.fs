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
let besideRatio (m : int) (n : int) (p1 : Picture) (p2: Picture) : Picture =
  fun rect ->
    let factor = float m / float (m + n)
    let r1, r2 = splitHorizontally factor rect
    p1 r1
    p2 r2

let beside' (p1 : Picture) (p2: Picture) : Picture =
  besideRatio 1 1 p1 p2

let beside (p1 : Picture) (p2: Picture) : Picture =
  fun rect ->
    let r1, r2 = splitHorizontally 0.5 rect
    p1 r1
    p2 r2

let aboveRatio (m : int) (n : int) (p1 : Picture) (p2: Picture) : Picture =
  fun rect ->
    let factor = float m / float (m + n)
    let r1, r2 = splitVertically factor rect
    p1 r1
    p2 r2

let above' (p1 : Picture) (p2: Picture) : Picture =
  aboveRatio 1 1 p1 p2

let above (p1 : Picture) (p2: Picture) : Picture =
  fun rect ->
    let r1, r2 = splitVertically 0.5 rect
    p1 r1
    p2 r2

let over (p1 : Picture) (p2: Picture) : Picture = 
  fun rect ->
    p1 rect
    p2 rect

let quartet p q r s = above (beside p q) (beside r s)

let cycle p = 
  quartet p (p |> turn) (p |> turn |> turn) (p |> turn |> turn |> turn)

let nonet p q r s t u v w x = 
  aboveRatio 1 2 (besideRatio 1 2 p (beside q r))
                 (aboveRatio 1 1 (besideRatio 1 2 s (beside t u))
                                 (besideRatio 1 2 v (beside w x)))
