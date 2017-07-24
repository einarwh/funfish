module Limited

open Pictures

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

let blank : Picture = 
  fun box -> []

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

let bandify combineRatio (n : int) (first : Picture) (middle : Picture) (last : Picture) = 
  let pictures = first :: List.replicate (n - 2) middle
  let folder item (p, ratio) = 
    (combineRatio 1 ratio item p, ratio + 1) 
  let (result, _) = List.foldBack folder pictures (last, 1)
  result

let aboveBand = bandify aboveRatio

let besideBand = bandify besideRatio

let egg n m p = 
  let cornerNW = corner n p
  let cornerSW = turn cornerNW
  let cornerSE = turn cornerSW
  let cornerNE = turn cornerSE
  let sideN = side n p
  let sideW = turn sideN
  let sideS = turn sideW
  let sideE = turn sideS
  let center = utile p
  let topband = besideBand m sideN sideN sideN
  let midband = besideBand m center center center
  let botband = besideBand m sideS sideS sideS
  let band = aboveBand 3 topband midband botband
  band

let eggband (n : int) (picture : Picture) =
  let theSide = side n picture
  let q = theSide
  let t = picture |> utile
  let w = theSide |> turn |> turn
  nonet q q q t t t w w w

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