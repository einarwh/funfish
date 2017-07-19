module Limit

open Monochromes

let ttile f = 
   let fish2 = flip (toss f)
   let fish3 = turn (turn (turn fish2))
   over f (over fish2 fish3)

let utile f = 
  let fish2 = f |> toss |> flip
  let u1 = over fish2 (fish2 |> turn) 
  let u2 = over (fish2 |> turn |> turn) (fish2 |> turn |> turn |> turn)
  over u1 u2

let quartet p q r s = 
  above (beside p q) (beside r s)

let blank = 
  fun box -> ()

let rec side n p = 
  let s = if n = 1 then blank else side (n - 1) p
  let t = ttile p
  quartet s s (t |> turn) t

let rec corner n p = 
  let c, s = if n = 1 then blank, blank else corner (n - 1) p, side (n - 1) p
  let u = utile p
  quartet c s (s |> turn) u

let nonet p q r s t u v w x = 
  aboveRatio 1 2 (besideRatio 1 2 p (beside q r))
                 (aboveRatio 1 1 (besideRatio 1 2 s (beside t u))
                                 (besideRatio 1 2 v (beside w x)))

let squarelimit n fish =
  let theCorner = corner n fish
  let theSide = side n fish
  let p = theCorner
  let q = theSide
  let r = theCorner |> turn |> turn |> turn
  let s = theSide |> turn
  let t = fish |> utile
  let u = theSide |> turn |> turn |> turn
  let v = theCorner |> turn
  let w = theSide |> turn |> turn
  let x = theCorner |> turn |> turn
  nonet p q r s t u v w x
