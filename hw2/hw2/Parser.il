.assembly hw2
{
  .ver 1:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit
  hw2.Parser
    extends [System.Runtime]System.Object
{

  .method public  hidebysig static bool
    TryParseOperationOrQuit(
      string arg,
      [out] valuetype hw2.Calculator/Operation& operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] string operation
    )


    ldarg.0      // засунул строку в стек
    stloc.0      // вытащил в operation

    ldloc.0      // обратно в стек
    ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     IL_add
    ldloc.0      
    ldstr        "-"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     IL_sub
    ldloc.0      
    ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     IL_mul
    ldloc.0      
    ldstr        "/"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     IL_div
    br.s         IL_nan

    IL_add: ldarg.0      
    ldc.i4.0
    stind.i4
    br.s         IL_returnFalse

    IL_sub: ldarg.0      
    ldc.i4.3
    stind.i4
    br.s         IL_returnFalse

    IL_mul: ldarg.0      
    ldc.i4.2
    stind.i4
    br.s         IL_returnFalse

    IL_div: ldarg.0      
    ldc.i4.1
    stind.i4
    br.s         IL_returnFalse

    IL_nan: ldstr        "Val is not Operation: "
    ldarg.0      
    call         string [System.Runtime]System.String::Concat(string, string)
    call         void [System.Console]System.Console::WriteLine(string)
    ldarg.0      // нан)
    ldc.i4.4
    stind.i4
    ldc.i4.1 //true
    ret

    IL_returnFalse: ldc.i4.0 //false
    ret

  } 

  .method public hidebysig static bool
    TryParseOrQuit(
      string arg,
      [out] int32& val
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool isVal
    )

    ldarg.0      // arg
    ldarg.1      // val
    call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    stloc.0      // isVal

    ldloc.0      
    brfalse.s    IL_ret

    ldstr        "Val is not int: "
    ldarg.0      // arg
    call         string [System.Runtime]System.String::Concat(string, string)
    call         void [System.Console]System.Console::WriteLine(string)

    IL_ret: ldloc.0
    ret

  } 
} 