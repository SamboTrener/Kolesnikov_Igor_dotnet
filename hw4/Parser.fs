module hw4.Parser

open System
open hw4.Operation

let TryParseOperationOrQuit (arg:string) (operation:outref<Operation>) =
    operation <- match arg with
    | "+" -> Operation.Add
    | "-" -> Operation.Subtract
    | "*" -> Operation.Multiply
    | "/" -> Operation.Divide
    | _ -> Operation.None
    operation = Operation.None