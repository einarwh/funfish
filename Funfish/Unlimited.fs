module Unlimited

open Shades

let ttile' hueN hueE f = 
   let fishN = f |> toss |> flip
   let fishE = fishN |> turn |> turn |> turn 
   over f (over (fishN |> hueN)
                (fishE |> hueE))

let ttile1 = ttile' rehue (rehue >> rehue)

let ttile2 = ttile' (rehue >> rehue) rehue

let utile' hueN hueW hueS hueE f = 
  let fishN = f |> toss |> flip
  let fishW = fishN |> turn
  let fishS = fishW |> turn
  let fishE = fishS |> turn
  over (over (fishN |> hueN) (fishW |> hueW))
       (over (fishE |> hueE) (fishS |> hueS))

let utile1 = 
  utile' (rehue >> rehue) id (rehue >> rehue) id

let utile2 = 
  utile' id (rehue >> rehue) rehue (rehue >> rehue)

let utile3 = 
  utile' (rehue >> rehue) id rehue id 

let quartet' p q r s = 
  above (beside p q) (beside r s)

let blank : LensPicture = 
  fun box -> []

let side' tt hueSW hueSE n p = 
  let rec aux n p =
    let t = tt p
    let r = if n = 1 then blank else aux (n - 1) p
    quartet' r r (t |> turn |> hueSW) (t |> hueSE)
  aux n p

let side1 =
  side' ttile1 id rehue 

let side2 =
  side' ttile2 (rehue >> rehue) rehue

let corner' ut sideNE sideSW n p = 
  let rec aux n p = 
    let c, ne, sw = 
      if n = 1 then blank, blank, blank 
               else aux (n - 1) p, sideNE (n - 1) p, sideSW (n - 1) p
    let u = ut p
    quartet' c ne (sw |> turn) u
  aux n p 

let corner1 = 
  corner' utile3 side1 side2

let corner2 = 
  corner' utile2 side2 side1

let nonet' p q r s t u v w x = 
  aboveRatio 1 2 (besideRatio 1 2 p (beside q r))
                 (aboveRatio 1 1 (besideRatio 1 2 s (beside t u))
                                 (besideRatio 1 2 v (beside w x)))

let squareLimit' n picture =
  let cornerNW = corner1 n picture
  let cornerSW = corner2 n picture |> turn
  let cornerSE = cornerNW |> turn |> turn
  let cornerNE = cornerSW |> turn |> turn
  let sideN = side1 n picture
  let sideW = side2 n picture |> turn
  let sideS = sideN |> turn |> turn
  let sideE = sideW |> turn |> turn
  let center = utile1 picture
  nonet' cornerNW sideN cornerNE  
         sideW center sideE
         cornerSW sideS cornerSE
