module Styling

type StyleColor = Black | Grey | White

type StrokeStyle = 
  { strokeWidth : float 
    strokeColor : StyleColor }

type FillStyle = 
  { fillColor : StyleColor }

type Style = 
  { stroke : StrokeStyle option 
    fill : FillStyle option }
