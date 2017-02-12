module Points

// rename to Coordinates or something? Include both Point and Vector type? (Vector being alias for Point?)

type Point = { x : float; y : float }

let createPoint x y = { x = x; y = y }

let xcoord p = p.x

let ycoord p = p.y

  