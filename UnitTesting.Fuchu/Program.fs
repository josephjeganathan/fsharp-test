open Fuchu
open System

[<EntryPoint>]
let main args = 
    let exitCode = defaultMainThisAssembly args
    
    Console.WriteLine("Press any key")
    Console.ReadLine() |> ignore

    // return the exit code
    exitCode 