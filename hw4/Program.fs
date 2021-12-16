module hw4.Program

open System
open hw4.Operation

let CheckArgLen argsLen =
    argsLen<>3
let WrongArgFormat = 1
let WrongArgLen = 2
let WrongOperationFormat = 3

[<EntryPoint>]
let main argv =
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operation = Operation.None
    
    if CheckArgLen argv.Length then WrongArgLen
    elif Int32.TryParse(argv.[0], &val1) = false || Int32.TryParse(argv.[2], &val2) = false then WrongArgFormat
    elif  Parser.TryParseOperationOrQuit argv.[1] &operation = true then WrongOperationFormat
    else
        printf $"Result is: {Calculator.Calculate operation val1 val2}"
        0