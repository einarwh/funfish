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


let rec side n = 
  let s = if n = 1 then blank else side (n - 1)
  quartet s s (t |> turn) t

let side1 = quartet blank blank (t |> turn) t
let side2 = quartet side1 side1 (t |> turn) t

let rec corner n = 
  let c, s = if n = 1 then blank, blank else corner (n - 1), side (n - 1)
  quartet c s (s |> turn) u

let corner1 = quartet blank blank blank u 
let corner2 = quartet corner1 side1 (side1 |> turn) u

let squarelimit2 = //p q r s t u v w x
  let side2 = side 2
  let p = corner 2
  let q = side2
  let r = corner 2 |> turn |> turn |> turn
  let s = side 2 |> turn
  let t = fish |> uify
  let u = side 2 |> turn |> turn |> turn
  let v = corner 2 |> turn
  let w = side 2 |> turn |> turn
  let x = corner 2 |> turn |> turn
  nonet p q r s t u v w x

let squarelimit n = //p q r s t u v w x
  let theCorner = corner n
  let theSide = side n
  let p = theCorner
  let q = theSide
  let r = theCorner |> turn |> turn |> turn
  let s = theSide |> turn
  let t = fish |> uify
  let u = theSide |> turn |> turn |> turn
  let v = theCorner |> turn
  let w = theSide |> turn |> turn
  let x = theCorner |> turn |> turn
  nonet p q r s t u v w x
