// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake

// Directories
let buildDir  = "./build/"
let testDir  = "./test/"


// Filesets
let references  =
    !! "/**/*.fsproj" -- "/**/*.Tests.fsproj"

let testReferences  =
    !! "/**/*.Tests.fsproj"

// version info
let version = "0.1"  // or retrieve from CI server

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir]
)

Target "Build" (fun _ ->
    MSBuildDebug buildDir "Build" references
    |> Log "AppBuild-Output: "
)

Target "BuildTests" (fun _ ->
    MSBuildDebug testDir "Build" testReferences
    |> Log "TestBuild-Output: "
)

// Build order
"Clean"
  ==> "Build"
  ==> "BuildTests"

// start build
RunTargetOrDefault "Build"
