module BoxesTests

open Expecto
open FsCheck

open Boxes

[<Tests>]
let tests =
  testList "boxes tests" [
    testList "turn tests" [
      testCase "turn example" <| fun _ ->
        let box = { a = { x =  20.; y =  20. }
                    b = { x =  50.; y =   0. }
                    c = { x =   0.; y =  50. } }
        let box' = turn box
        let xbox = { a = { x =  70.; y =  20. }
                     b = { x =   0.; y =  50. }
                     c = { x = -50.; y =   0. } }
        Expect.equal box' xbox "turn is broken" 
      
      ptestProperty "turning four times gives the original box" <| fun (box : Box) ->
        let box' = (turn >> turn >> turn >> turn) box
        Expect.equal box box' "turn is broken"
    ]

    testList "flip tests" [
      testCase "flip example" <| fun _ ->
        let box = { a = { x =  20.; y =  20. }
                    b = { x =  50.; y =   0. }
                    c = { x =   0.; y =  50. } }
        let box' = flip box
        let xbox = { a = { x =  70.; y =  20. }
                     b = { x = -50.; y =   0. }
                     c = { x =   0.; y =  50. } }
        Expect.equal box' xbox "flip is broken"  
    ]

    testList "toss tests" [
      testCase "toss example" <| fun _ ->
        let box = { a = { x =  20.; y =  20. }
                    b = { x =  50.; y =   0. }
                    c = { x =   0.; y =  50. } }
        let box' = toss box
        let xbox = { a = { x =  45.; y =  45. }
                     b = { x =  25.; y =  25. }
                     c = { x = -25.; y =  25. } }
        Expect.equal box' xbox "toss is broken"  
    ]

    testList "splitVertically tests" [
      testCase "splitVertically 50/50 example" <| fun _ ->
        let box = { a = { x =  20.; y =  20. }
                    b = { x = 100.; y =   0. }
                    c = { x =   0.; y = 100. } }
        let boxes = splitVertically 0.5 box
        let xleft = { a = { x =  20.; y =  20. }
                      b = { x =  50.; y =   0. }
                      c = { x =   0.; y = 100. } }
        let xright = { a = { x =  70.; y =  20. }
                       b = { x =  50.; y =   0. }
                       c = { x =   0.; y = 100. } }
        Expect.equal boxes (xleft, xright) "splitVertically is broken"  

      testCase "splitVertically 75/25 example" <| fun _ ->
        let box = { a = { x =  20.; y =  20. }
                    b = { x = 100.; y =   0. }
                    c = { x =   0.; y = 100. } }
        let boxes = splitVertically 0.75 box
        let xleft = { a = { x =  20.; y =  20. }
                      b = { x =  75.; y =   0. }
                      c = { x =   0.; y = 100. } }
        let xright = { a = { x =  95.; y =  20. }
                       b = { x =  25.; y =   0. }
                       c = { x =   0.; y = 100. } }
        Expect.equal boxes (xleft, xright) "splitVertically is broken"  
    ]

    testList "splitHorizontally tests" [
      testCase "splitHorizontally 50/50 example" <| fun _ ->
        let box = { a = { x =  20.; y =  20. }
                    b = { x = 100.; y =   0. }
                    c = { x =   0.; y = 100. } }
        let boxes = splitHorizontally 0.5 box
        let xtop = { a = { x =  20.; y =  70. }
                     b = { x = 100.; y =   0. }
                     c = { x =   0.; y =  50. } }
        let xbot = { a = { x =  20.; y =  20. }
                     b = { x = 100.; y =   0. }
                     c = { x =   0.; y =  50. } }
        Expect.equal boxes (xtop, xbot) "splitHorizontally is broken"  

      testCase "splitHorizontally 75/25 example" <| fun _ ->
        let box = { a = { x =  20.; y =  20. }
                    b = { x = 100.; y =   0. }
                    c = { x =   0.; y = 100. } }
        let boxes = splitHorizontally 0.75 box
        let xtop = { a = { x =  20.; y =  45. }
                     b = { x = 100.; y =   0. }
                     c = { x =   0.; y =  75. } }
        let xbot = { a = { x =  20.; y =  20. }
                     b = { x = 100.; y =   0. }
                     c = { x =   0.; y =  25. } }
        Expect.equal boxes (xtop, xbot) "splitHorizontally is broken"  
    ]
  ]