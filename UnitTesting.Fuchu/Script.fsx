//#r "../packages/NUnit.2.6.4/lib/nunit.framework.dll"
//#r "../packages/Fuchu.1.0.3.0/lib/Fuchu.dll"
//
//open Fuchu
//open NUnit.Framework

//let add1 x = x + 2
//
//// a simple test using any assertion framework:
//// Fuchu's own, Nunit, FsUnit, etc
//let ``Assert that add1 is x+1`` x _ = 
//   Assert.AreEqual(x+1, add1 x)
//
//// a single test case with one value
//let simpleTest = 
//   testCase "Test with 42" <| 
//     ``Assert that add1 is x+1`` 42
//
//// a parameterized test case with one param
//let parameterizedTest i = 
//   testCase (sprintf "Test with %i" i) <| 
//     ``Assert that add1 is x+1`` i
//
//[<Fuchu.Tests>]
//let tests = 
//   testList "Test group A" [
//      simpleTest 
//      testList "Parameterized 1..10" ([1..10] |> List.map parameterizedTest) 
//      testList "Parameterized 11..20" ([11..20] |> List.map parameterizedTest) 
//   ]