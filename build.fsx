#r "./build/tools/FAKE/tools/FakeLib.dll"

let sd = __SOURCE_DIRECTORY__

open Fake
open System

let nugetPackagesDir = sd @@ "packages"

let buildDir = sd @@ "build"

let buildOutDir = sd @@ "build" @@ "output"
let testOutDir = buildOutDir @@ "test"
let testResultsDir = buildDir @@ "test-results"

open System.IO

let buildProject outputDir buildTargets projectName = 
    let setParams p =
        { p with
            Verbosity = Some(Quiet)
            Targets = buildTargets
            Properties =
                [   "OutputPath", outputDir
                    "Optimize", "True"
                    "DebugSymbols", "True"
                    "Configuration", "Release" ]
            }

    build setParams projectName |> DoNothing

Target "Clean" (fun () -> 
    CleanDirs [ buildOutDir; testResultsDir ]
)

Target "NuGetRestore" (fun () -> 
    !! (sd @@ "./**/UnitTesting.xUnit/packages.config")
    |> Seq.iter (RestorePackageId (fun p -> { p with OutputPath = nugetPackagesDir }))
)

Target "BuildTests" (fun () -> 
    !! (sd @@ "**/*.xUnit.fsproj")
    |> Seq.iter (buildProject testOutDir ["Build"])
)

open Fake.Testing.XUnit2

Target "RunTest" (fun () ->
    !! (testOutDir @@ "*.xUnit.dll")
    |> xUnit2 (fun p -> { p with HtmlOutputPath = Some (testResultsDir @@ "xunit.html") })
)

Target "Default" DoNothing

// Build dependencies
"Clean"
    ==> "NugetRestore"
    ==> "BuildTests"
    ==> "RunTest"
    ==> "Default"

// Start build
RunTargetOrDefault "Default"