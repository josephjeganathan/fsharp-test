module Tests

open NUnit.Framework
open Fuchu

let add1 x = if (x % 9 <> 0) then x + 1 else x    

let ``Assert that add1 is x+1`` x _notUsed = 
    Assert.AreEqual(x+1, add1 x)

let simpleTest = 
   testCase "Test with 42" <| ``Assert that add1 is x+1`` 42

let parameterizedTest i = 
   testCase (sprintf "Test with %i" i) <| ``Assert that add1 is x+1`` i

[<Fuchu.Tests>]
let tests = 
   testList "Test group A" [
      simpleTest 
      testList "Parameterized 1..10" ([1..10] |> List.map parameterizedTest) 
      testList "Parameterized 11..20" ([11..20] |> List.map parameterizedTest) 
   ]
