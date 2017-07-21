module Shades

open Styling
open Lenses
open Shapes

type LensPicture = Lens -> (Shape * Style) list

let turn p = 
  Lenses.turn >> p

let flip p = 
  Lenses.flip >> p

let toss p = 
  Lenses.toss >> p

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

let rehue p = 
  Lenses.rehue >> p
