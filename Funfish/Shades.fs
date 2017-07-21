module Shades

open Lensy
open Shapes

type LensPicture = Lens -> Shape list

let turn p = 
  Lensy.turn >> p

let flip p = 
  Lensy.flip >> p

let toss p = 
  Lensy.toss >> p

let besideRatio (m : int) (n : int) (p1 : LensPicture) (p2 : LensPicture) =
  fun lens ->
    let factor = float m / float (m + n)
    let b1, b2 = splitVertically factor lens
    p1 b1 @ p2 b2

let beside = besideRatio 1 1

let aboveRatio (m : int) (n : int) (p1 : LensPicture) (p2 : LensPicture) =
  fun box ->
    let factor = float m / float (m + n)
    let b1, b2 = splitHorizontally factor box
    p1 b1 @ p2 b2

let above = aboveRatio 1 1

let over p1 p2 = 
  fun box ->
    p1 box @ p2 box
