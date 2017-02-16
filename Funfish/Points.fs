module Points

type Point = { x : float; y : float }

let createPoint x y = { x = x; y = y }

let xcoord p = p.x

let ycoord p = p.y

  