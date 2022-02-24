namespace Aardvark.Base.Runtime

open System
open System.IO
open System.Runtime.InteropServices

module AssemblerStream =
    let create (s : Stream) =
        match RuntimeInformation.ProcessArchitecture with
        | Architecture.X64 -> new AMD64.AssemblerStream(s, true) :> IAssemblerStream
        | Architecture.Arm64 -> new ARM64.Arm64Stream(s, true) :> IAssemblerStream
        | a -> raise <| new NotSupportedException(sprintf "Architecture %A not supported" a)