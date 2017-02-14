open Expecto

open Vectors
open Rectangles

[<Tests>]
let tests =
  testList "all the tests" [
    testList "vectors" [
      testCase "createVector 1" <| fun() ->
        let v = createVector 1. 5.
        Expect.equal (x v) 1. "x is wrong"
        Expect.equal (y v) 5. "y is wrong"
      testCase "createVector 2" <| fun() ->
        let v = createVector 3. 2.
        Expect.equal (x v) 3. "x is wrong"
        Expect.equal (y v) 2. "y is wrong"
      testCase "add vectors 1" <| fun () ->
        let v1 = createVector 1. 5.
        let v2 = createVector 8. 2.
        let result = add v1 v2
        let expected = createVector 9. 7.
        Expect.equal result expected "add vectors 1"
      testCase "add vectors 2" <| fun () ->
        let v1 = createVector 2. 5.
        let v2 = createVector 3. 0.
        let result = add v1 v2
        let expected = createVector 5. 5.
        Expect.equal result expected "add vectors 2"
      testCase "add vectors 3" <| fun () ->
        let v1 = createVector 2. 5.
        let v2 = createVector 0. 3.
        let result = add v1 v2
        let expected = createVector 2. 8.
        Expect.equal result expected "add vectors 3"
      testCase "sub vectors 1" <| fun () ->
        let v1 = createVector 1. 5.
        let v2 = createVector 8. 2.
        let result = sub v1 v2
        let expected = createVector -7. 3.
        Expect.equal result expected "sub vectors 1"
      testCase "sub vectors 2" <| fun () ->
        let v = createVector 2. 5.
        let result = sub v v
        let expected = createVector 0. 0.
        Expect.equal result expected "sub vectors 2"
      testCase "scale vectors 1" <| fun () ->
        let v = createVector 2. 6.
        let result = scale 0.5 v
        let expected = createVector 1. 3.
        Expect.equal result expected "scale vectors 1"
      testCase "scale vectors 2" <| fun () ->
        let v = createVector 2. 5.5
        let result = scale 2. v
        let expected = createVector 4. 11.
        Expect.equal result expected "scale vectors 2"
    ]
    testList "rectangles" [
      testCase "create rectangle 1" <| fun () ->
        let o = createVector 1. 2.
        let h = createVector -1. 2.5
        let v = createVector 4. 1.5
        let rect = createRectangle o h v
        Expect.equal (origin rect) o "origin is wrong"
        Expect.equal (horizontal rect) h "horizontal is wrong"
        Expect.equal (vertical rect) v "vertical is wrong"
      testCase "turn rectangle 1" <| fun () ->
        let o = createVector 1. 2.
        let h = createVector 4. 1.5
        let v = createVector -1. 2.5
        let rect = createRectangle o h v
        let result = turn rect
        let expected = createRectangle (createVector 5. 3.5) (createVector -1. 2.5) (createVector -4. -1.5)
        Expect.equal result expected "turn rectangle 1"
      testCase "turn rectangle 2" <| fun () ->
        let o = createVector 1. 1.
        let h = createVector 2. 0.
        let v = createVector 0. 3.
        let rect = createRectangle o h v
        let result = turn rect
        let expected = createRectangle (createVector 3. 1.) (createVector 0. 3.) (createVector -2. 0.)
        Expect.equal result expected "turn rectangle 2"
      testCase "flip rectangle 1" <| fun () ->
        let o = createVector 4.0 2.5
        let h = createVector 2.5 1.0
        let v = createVector -1.5 3.5
        let rect = createRectangle o h v
        let result = flip rect
        let expected = createRectangle (createVector 6.5 3.5) (createVector -2.5 -1.0) (createVector -1.5 3.5)
        Expect.equal result expected "flip rectangle 1"
      testCase "toss rectangle 1" <| fun () ->
        let o = createVector 0.0 0.0
        let h = createVector 4.0 0.0
        let v = createVector 0.0 4.0
        let rect = createRectangle o h v
        let result = toss rect
        let expected = createRectangle (createVector 2.0 2.0) (createVector 2.0 2.0) (createVector -2.0 2.0)
        Expect.equal result expected "toss rectangle 1"
      testCase "scale rectangle horizontally 1" <| fun () ->
        let o = createVector 1.0 3.0
        let h = createVector 4.0 2.0
        let v = createVector 3.0 3.0
        let rect = createRectangle o h v
        let result = scaleHorizontally 0.5 rect
        let expected = createRectangle (createVector 1.0 3.0) (createVector 2.0 1.0) (createVector 3.0 3.0)
        Expect.equal result expected "scale rectangle horizontally 1"
      testCase "scale rectangle vertically 1" <| fun () ->
        let o = createVector 1.0 3.0
        let h = createVector 4.0 2.0
        let v = createVector 3.0 3.0
        let rect = createRectangle o h v
        let result = scaleVertically 0.5 rect
        let expected = createRectangle (createVector 1.0 3.0) (createVector 4.0 2.0) (createVector 1.5 1.5)
        Expect.equal result expected "scale rectangle vertically 1"

    ]
  ]


[<EntryPoint>]
let main args =
  runTestsInAssembly defaultConfig args