.assembly hw2
{
  .ver 1:0:0:0
}


.class public abstract sealed auto ansi beforefieldinit
  hw2.Calculator
    extends [CORE_ASSEMBLY]System.Object
{

.class public sealed auto ansi
    Operation
      extends System.Enum
  {

    .field public specialname rtspecialname int32 value__

    .field public static literal valuetype hw2.Calculator/Operation Add = int32(0)

    .field public static literal valuetype hw2.Calculator/Operation Subtract = int32(1)

    .field public static literal valuetype hw2.Calculator/Operation Multiply = int32(2)

    .field public static literal valuetype hw2.Calculator/Operation Divide = int32(3)

    .field public static literal valuetype hw2.Calculator/Operation None = int32(4)
  }

  .method public hidebysig static int32
    Calculate(
      valuetype hw2.Calculator/Operation operation,
      int32 val1,
      int32 val2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 result,
      [1] valuetype  hw2.Calculator/Operation operation,
      [2] valuetype  hw2.Calculator/Operation gottenOperation
    )
    
    ldc.i4.0
    stloc.0      // Положил 0 в стек и сразу вытащил в переменную резалт

    ldarg.0      // загрузка переданной операции в стек
    stloc.2      // Кладу её по индкексу 2 в переменную 

    ldloc.2      // Засунул gottenOperation в стек
    stloc.1      // Вытащил и засунул по индексу 1 в переменную

    ldloc.1      // Положил operation в стек
    switch       (IL_add, IL_sub, IL_mul, IL_div)

    IL_add: ldarg.1      
    ldarg.2      
    add
    ret

    IL_sub: ldarg.1      
    ldarg.2      
    sub
    ret

    IL_mul: ldarg.1      
    ldarg.2      
    mul
    ret

    IL_div: ldarg.0      
    ldarg.2      
    div
    ret
  } 
} 