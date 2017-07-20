module Limit

open Monochromes

let ttile f = 
   let fishN = f |> toss |> flip
   let fishE = fishN |> turn |> turn |> turn 
   over f (over fishN fishE)

let utile f = 
  let fishN = f |> toss |> flip
  let fishW = fishN |> turn
  let fishS = fishW |> turn
  let fishE = fishS |> turn
  over (over fishN fishW)
       (over fishE fishS)

let quartet p q r s = 
  above (beside p q) (beside r s)

let blank = 
  fun box -> ()

let rec side n p = 
  let s = if n = 1 then blank else side (n - 1) p
  let t = ttile p
  quartet s s (t |> turn) t

let rec corner n p = 
  let c, s = if n = 1 then blank, blank 
             else corner (n - 1) p, side (n - 1) p
  let u = utile p
  quartet c s (s |> turn) u

let nonet p q r s t u v w x = 
  aboveRatio 1 2 (besideRatio 1 2 p (beside q r))
                 (aboveRatio 1 1 (besideRatio 1 2 s (beside t u))
                                 (besideRatio 1 2 v (beside w x)))

let squareLimit n p =
  let cornerNW = corner n p
  let cornerSW = turn cornerNW
  let cornerSE = turn cornerSW
  let cornerNE = turn cornerSE
  let sideN = side n p
  let sideW = turn sideN
  let sideS = turn sideW
  let sideE = turn sideS
  let center = utile p
  nonet cornerNW sideN cornerNE  
        sideW center sideE
        cornerSW sideS cornerSE