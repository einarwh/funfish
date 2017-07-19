module Monochromes

open Boxes

type Picture = Box -> unit

let turn (p : Picture) : Picture = 
  Boxes.turn >> p

let flip (p : Picture) : Picture = 
  Boxes.flip >> p

let toss (p : Picture) : Picture = 
  Boxes.toss >> p

let besideRatio (m : int) (n : int) (p1 : Picture) (p2: Picture) : Picture =
  fun box ->
    let factor = float m / float (m + n)
    let b1, b2 = splitVertically factor box
    p1 b1; p2 b2

let beside = besideRatio 1 1

let aboveRatio (m : int) (n : int) (p1 : Picture) (p2 : Picture) : Picture =
  fun box ->
    let factor = float m / float (m + n)
    let b1, b2 = splitHorizontally factor box
    p1 b1; p2 b2

let above = aboveRatio 1 1

let over (p1 : Picture) (p2: Picture) : Picture = 
  fun box ->
    p1 box; p2 box
