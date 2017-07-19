module VectoryTests

open Expecto

open Vectory

[<Tests>]
let tests =
  testList "vector arithmetic tests" [
    testList "+ tests" [
      testCase "(1, 2) + (3, 3) = (4, 5)" <| fun _ ->
        let v1 = { x = 1.; y = 2. }
        let v2 = { x = 3.; y = 3. }
        Expect.equal (v1 + v2) { x = 4.; y = 5. } "+ is broken"    
    ]

    testList "~- tests" [
      testCase "- (4, 5) = (-4, -5)" <| fun _ ->
        let v = { x = 4.; y = 5. }
        Expect.equal (- v) { x = -4.; y = -5. } "~- is broken"    
    ]

    testList "- tests" [
      testCase "(4, 5) - (3, 3) = (1, 2)" <| fun _ ->
        let v1 = { x = 4.; y = 5. }
        let v2 = { x = 3.; y = 3. }
        Expect.equal (v1 - v2) { x = 1.; y = 2. } "- is broken"    
    ]

    testList "* tests" [
      testCase "(4, 6) * 0.5" <| fun _ ->
        let v = { x = 4.; y = 6. }
        let f = 0.5
        let expected = { x = 2.; y = 3. }
        Expect.equal (v * f) expected "* is broken"    
        Expect.equal (f * v) expected "* is broken"    

      testCase "(4, 6) * 1.5" <| fun _ ->
        let v = { x = 4.; y = 6. }
        let f = 1.5
        let expected = { x = 6.; y = 9. }
        Expect.equal (v * f) expected "* is broken"    
        Expect.equal (f * v) expected "* is broken"
    ]

    testList "/ tests" [
      testCase "(4, 6) / 0.5" <| fun _ ->
        let v = { x = 4.; y = 6. }
        let f = 0.5
        Expect.equal (v / f) { x = 8.; y = 12. } "/ is broken"    

      testCase "(4, 6) / 2" <| fun _ ->
        let v = { x = 4.; y = 6. }
        let f = 2.
        Expect.equal (v / f) { x = 2.; y = 3. } "/ is broken"    
    ]
  ]