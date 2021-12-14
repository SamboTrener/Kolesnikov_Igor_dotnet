module hw5.Parser

open System
open hw5.MaybeBuilder
open hw5.Operation
open ErrorTypes

let CheckArgLength (args: string[]) =
    match args.Length with
    | 3 -> Ok args
    | _ -> Error ErrorTypes.WrongArgLen


let TryParseOperationOrQuit (args:string[]) =
    maybeBuilder {
        let! operationResult =
            match args.[1] with
            | "+" -> Ok Operation.Add
            | "-" -> Ok Operation.Subtract
            | "/" -> Ok Operation.Divide
            | "*" -> Ok Operation.Multiply
            | _ -> Error ErrorTypes.WrongOperationFormat

        return args.[0], operationResult, args.[2]
    }
    
let ParseArgs (arg1:string, operation:Operation, arg2:string) =
    try
        Ok (arg1 |> decimal, operation, arg2 |> decimal)
    with
        | _ -> Error ErrorTypes.WrongArgFormat

let ParseEverything args =
    maybeBuilder{
        let! FirstStep = CheckArgLength args
        let! SecondStep = TryParseOperationOrQuit FirstStep
        let! FinalStep = ParseArgs SecondStep
        return FinalStep
    }