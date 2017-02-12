module Segments

open Points

type Segment = { startPoint : Point; endPoint : Point }

let createSegment p q = { startPoint = p; endPoint = q }

let startPoint s = s.startPoint

let endPoint s = s.endPoint

  