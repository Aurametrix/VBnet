.method private hidebysig static int32 TestMattOpCodeMethod(int32 x, int32 y) 
        cil managed noinlining
{
    .maxstack 2
    ldarg.0
    ldarg.1
    matt  // author'sy name as an IL op-code
    ret
}
