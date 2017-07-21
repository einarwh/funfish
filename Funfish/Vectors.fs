module Vectors

type Vector = 
  { x : float
    y : float }

  static member (+) ({ x = x1; y = y1}, { x = x2; y = y2 }) =
    { x = x1 + x2; y = y1 + y2 }

  static member (-) ({ x = x1; y = y1}, { x = x2; y = y2 }) =
    { x = x1 - x2; y = y1 - y2 }

  static member (~-) ({ x = x; y = y }) =
    { x = -x; y = -y }

  static member (*) (f, { x = x; y = y }) =
    { x = f * x; y = f * y }

  static member (*) ({ x = x; y = y }, f) =
    { x = f * x; y = f * y }

  static member (/) ({ x = x; y = y }, f) =
    { x = x / f; y = y / f }

let shift { x = dx; y = dy } { x = x; y = y } = 
  { x = x + dx; y = y + dy }

let size { x = x; y = y } = 
  sqrt(x * x + y * y)

let between { x = x1; y = y1 } { x = x2; y = y2 } = 
  let dx = (x2 - x1) * 0.5
  let dy = (y2 - y1) * 0.5
  { x = x1 + dx; y = y1 + dy }
