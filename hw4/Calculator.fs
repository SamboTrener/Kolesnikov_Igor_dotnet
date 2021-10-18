module hw4.Calculator

open hw4.Operation

let Calculate (operation:Operation) (val1: int) (val2: int) =
    match operation with
    | Operation.Add -> val1 + val2
    | Operation.Subtract -> val1 - val2
    | Operation.Divide -> val1/val2
    | _ -> val1*val2