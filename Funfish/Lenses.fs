module Lenses

open Boxes

type Hue = Blackish | Greyish | Whiteish

type Lens = Box * Hue

let turn (box, hue) =
  turn box, hue

let flip (box, hue) = 
  flip box, hue
 
let toss (box, hue) =
  toss box, hue

let scaleHorizontally s (box, hue) =
  scaleHorizontally s box, hue  

let scaleVertically s (box, hue) =
  scaleVertically s box, hue

let moveHorizontally offset (box, hue) = 
  moveHorizontally offset box, hue
  
let moveVertically offset (box, hue) =
  moveVertically offset box, hue

let splitHorizontally f (box, hue) =
  let top, bottom = splitHorizontally f box
  (top, hue), (bottom, hue)

let splitVertically f (box, hue) =
  let left, right = splitVertically f box
  (left, hue), (right, hue)

let rehue (box, hue) = 
  let change = function
  | Blackish -> Greyish
  | Greyish -> Whiteish
  | Whiteish -> Blackish
  box, change hue