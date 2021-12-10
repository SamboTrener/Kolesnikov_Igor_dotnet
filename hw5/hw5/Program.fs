module hw5.Program

open System
open hw5.MaybeBuilder
open hw5.Operation
open hw5.ErrorTypes

[<EntryPoint>]
let main argv =
    let result = maybeBuilder {
        let! ParsedAgrv = Parser.ParseEverything argv
        let res = Calculator.Calculate ParsedAgrv
        return res
    }

    match result with
    | Ok value ->
        printf $"{value}"
        0
    | Error error -> int error