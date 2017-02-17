module SquareLimit

open Data
open Pictures
open Drawing

let fish : Picture = createBezierCurvePicture fishCurves

let maket (f : Picture)  = 
  let fish2 = f |> toss |> flip
  let fish3 = fish2 |> turn |> turn |> turn
  let t = over fish2 fish3 |> over f
  t

let fish2 = fish |> toss |> flip
let fish3 = fish2 |> turn |> turn |> turn
let t = over fish2 fish3 |> over fish

let tify f = 
   let fish2 = flip (toss f)
   let fish3 = turn (turn (turn fish2))
   over f (over fish2 fish3)

let uify (f : Picture) = 
  let fish2 = f |> toss |> flip
  let u1 = over fish2 (fish2 |> turn) 
  let u2 = over (fish2 |> turn |> turn) (fish2 |> turn |> turn |> turn)
  over u1 u2

let u = fish |> uify

let side1 = quartet blank blank (t |> turn) t
let side2 = quartet side1 side1 (t |> turn) t 
let corner1 = quartet blank blank blank u 
let corner2 = quartet corner1 side1 (side1 |> turn) u

let squarelimit2 = //p q r s t u v w x
  let p = corner2
  let q = side2
  let r = corner2 |> turn |> turn |> turn
  let s = side2 |> turn
  let t = fish |> uify
  let u = side2 |> turn |> turn |> turn
  let v = corner2 |> turn
  let w = side2 |> turn |> turn
  let x = corner2 |> turn |> turn
  nonet p q r s t u v w x
