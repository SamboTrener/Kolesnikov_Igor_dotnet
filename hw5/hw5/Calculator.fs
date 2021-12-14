module hw5.Calculator

open hw5.Operation

let Calculate (val1: decimal, operation:Operation,  val2: decimal) =
    match operation with
    | Operation.Add -> val1 + val2
    | Operation.Subtract -> val1 - val2
    | Operation.Divide -> val1/val2
    | _ -> val1*val2