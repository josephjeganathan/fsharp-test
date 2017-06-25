module ``Calculator Tests``

open Xunit

[<Fact>]
let ``When 2 is added to 2 expect 4``() = 
    Assert.Equal(4, 2 + 2)

[<Fact>]
let ``When 3 is added to -2 expect 1``() = 
    Assert.Equal(1, 3 + -2)