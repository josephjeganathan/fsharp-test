module UnquoteTests

open Xunit
open Swensen.Unquote

[<Fact>]
let ``When 2 is added to 2 expect 4``() = 
    test <@ 2 + 2 = 4 @>

[<Fact>]
let ``demo Unquote xUnit support`` () =
    test <@ ([3; 2; 1; 0] |> List.map ((+) 1)) = [1 + 3..-1..1 + 0] @>