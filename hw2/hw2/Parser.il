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
      [0] string V_0,
      [1] string V_1,
      [2] bool V_2
    )


    ldarg.0      // arg
    stloc.1      // V_1

    ldloc.1      // V_1
    stloc.0      // V_0

    ldloc.0      // V_0
    ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     IL_003b
    IL_0012: ldloc.0      // V_0
    IL_0013: ldstr        "-"
    IL_0018: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_001d: brtrue.s     IL_0040
    IL_001f: ldloc.0      // V_0
    IL_0020: ldstr        "*"
    IL_0025: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_002a: brtrue.s     IL_0045
    IL_002c: ldloc.0      // V_0
    IL_002d: ldstr        "/"
    IL_0032: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0037: brtrue.s     IL_004a
    IL_0039: br.s         IL_004f

    IL_003b: ldarg.1      // operation
    IL_003c: ldc.i4.0
    IL_003d: stind.i4

    IL_003e: br.s         IL_0067

    IL_0040: ldarg.1      // operation
    IL_0041: ldc.i4.3
    IL_0042: stind.i4

    IL_0043: br.s         IL_0067

    IL_0045: ldarg.1      // operation
    IL_0046: ldc.i4.2
    IL_0047: stind.i4

    IL_0048: br.s         IL_0067

    IL_004a: ldarg.1      // operation
    IL_004b: ldc.i4.1
    IL_004c: stind.i4

    IL_004d: br.s         IL_0067

    IL_004f: ldstr        "Val is not Operation: "
    IL_0054: ldarg.0      // arg
    IL_0055: call         string [System.Runtime]System.String::Concat(string, string)
    IL_005a: call         void [System.Console]System.Console::WriteLine(string)

    IL_0060: ldarg.1      // operation
    IL_0061: ldc.i4.4
    IL_0062: stind.i4

    IL_0063: ldc.i4.1
    IL_0064: stloc.2      // V_2
    IL_0065: br.s         IL_006b

    IL_0067: ldc.i4.0
    IL_0068: stloc.2      // V_2

    IL_006b: ldloc.2      // V_2
    IL_006c: ret

  } 

  .method public hidebysig static bool
    TryParseOrQuit(
      string arg,
      [out] int32& val
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool isVal,
      [1] bool V_1,
      [2] bool V_2
    )

    IL_0001: ldarg.0      // arg
    IL_0002: ldarg.1      // val
    IL_0003: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_0008: stloc.0      // isVal

    IL_0009: ldloc.0      // isVal
    IL_000a: stloc.1      // V_1

    IL_000b: ldloc.1      // V_1
    IL_000c: brfalse.s    IL_0021

    IL_000f: ldstr        "Val is not int: "
    IL_0014: ldarg.0      // arg
    IL_0015: call         string [System.Runtime]System.String::Concat(string, string)
    IL_001a: call         void [System.Console]System.Console::WriteLine(string)

    IL_0021: ldloc.0      // isVal
    IL_0022: stloc.2      // V_2

    IL_0025: ldloc.2      // V_2
    IL_0026: ret

  } 

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0007: ret
  } 
} 