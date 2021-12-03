module Tests

open System
open Microsoft.VisualStudio.TestPlatform.TestHost
open Xunit
open hw5

[<Theory>]
[<InlineData("1","+", "x")>]
[<InlineData("1","-", "x")>]
[<InlineData("1","*", "x")>]
[<InlineData("1","/", "x")>]
let ``WrongArgFormatEveryOperation`` (arg1, arg2, arg3) =
    let args = [|arg1; arg2; arg3|]
    let result = Program.main args
    Assert.Equal(result, 1)

[<Fact>]
let ``WrongArgLen`` () =
    let args = [|"1";"+";"2";"i hate ni"|]
    let result = Program.main args
    Assert.Equal(result, 2)

[<Fact>]
let ``WrongOperationFormat`` () =
    let args = [|"1";"i love paris every moment";"2"|]
    let result = Program.main args
    Assert.Equal(result, 3)
    
[<Fact>]
let ``EverythingAlrightWithAdd`` () =
    let args = [|"1";"+";"2"|]
    let result = Program.main args
    Assert.Equal(result, 0)
    
[<Fact>]
let ``EverythingAlrightWithSubtract`` () =
    let args = [|"3";"-";"1"|]
    let result = Program.main args
    Assert.Equal(result, 0)
    
[<Fact>]
let ``EverythingAlrightWithMultiply`` () =
    let args = [|"3";"*";"1"|]
    let result = Program.main args
    Assert.Equal(result, 0)
        
[<Fact>]
let ``EverythingAlrightWithDivide`` () =
    let args = [|"3";"/";"1"|]
    let result = Program.main args
    Assert.Equal(result, 0)