
//  Microsoft (R) .NET Framework IL Disassembler.  Version 1.0.3705.0
//  Copyright (C) Microsoft Corporation 1998-2001. All rights reserved.

.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:3300:0
}
.assembly extern System.Drawing
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 1:0:3300:0
}
.assembly Shapes
{
  .custom instance void [mscorlib]System.Reflection.AssemblyKeyNameAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyKeyFileAttribute::.ctor(string) = ( 01 00 10 2E 2E 5C 2E 2E 5C 53 68 61 70 65 73 2E   // .....\..\Shapes.
                                                                                                73 6E 6B 00 00 )                                  // snk..
  .custom instance void [mscorlib]System.Reflection.AssemblyDelaySignAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 28 53 68 61 70 65 73 20 69 73 20 61 20 74   // ..(Shapes is a t
                                                                                                  72 61 64 65 6D 61 72 6B 20 6F 66 20 4D 79 43 6F   // rademark of MyCo
                                                                                                  6D 70 61 6E 79 2C 20 49 6E 63 2E 00 00 )          // mpany, Inc...
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 1F 43 6F 70 79 72 69 67 68 74 20 32 30 30   // ...Copyright 200
                                                                                                  31 2C 20 4D 79 43 6F 6D 70 61 6E 79 2C 20 49 6E   // 1, MyCompany, In
                                                                                                  63 2E 00 00 )                                     // c...
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 06 53 68 61 70 65 73 00 00 )                // ...Shapes..
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0F 4D 79 43 6F 6D 70 61 6E 79 2C 20 49 6E   // ...MyCompany, In
                                                                                                63 2E 00 00 )                                     // c...
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 12 45 6E 74 65 72 70 72 69 73 65 20 56 65   // ...Enterprise Ve
                                                                                                      72 73 69 6F 6E 00 00 )                            // rsion..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 22 43 6C 61 73 73 65 73 20 66 6F 72 20 4D   // .."Classes for M
                                                                                                    61 6E 69 70 75 6C 61 74 69 6F 6E 20 6F 66 20 53   // anipulation of S
                                                                                                    68 61 70 65 73 00 00 )                            // hapes..
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 1E 4D 79 43 6F 6D 70 61 6E 79 20 53 68 61   // ...MyCompany Sha
                                                                                              70 65 73 20 43 6C 61 73 73 20 4C 69 62 72 61 72   // pes Class Librar
                                                                                              79 00 00 )                                        // y..
  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(bool,
  //                                                                                bool) = ( 01 00 01 01 00 00 ) 
  .publickey = (00 24 00 00 04 80 00 00 94 00 00 00 06 02 00 00   // .$..............
                00 24 00 00 52 53 41 31 00 04 00 00 01 00 01 00   // .$..RSA1........
                5F 16 7B F0 EB 59 1E 21 D9 4A 2D 87 96 68 CA FD   // _.{..Y.!.J-..h..
                BF BA F6 3E 30 69 47 EA 1E C7 F5 67 0E A1 1A EC   // ...>0iG....g....
                45 51 D6 25 77 5D A6 94 85 90 7D A9 F2 A4 74 3A   // EQ.%w]....}...t:
                BB AB 0D 95 AA 2B 16 BD C3 D6 45 EC 79 6C 3C 04   // .....+....E.yl<.
                23 27 76 0A 9F 7E BD D0 23 31 55 AF A6 30 C4 22   // #'v..~..#1U..0."
                90 B9 3B C4 E1 D1 BF FA 6D BF 4B 76 C4 8F 1E 47   // ..;.....m.Kv...G
                40 FA 14 F3 19 8E 0A 6A 8A C0 99 46 47 B0 CD 09   // @......j...FG...
                BF 9F D9 D7 5A 25 D2 3A AD 89 E8 DD D2 68 60 BF ) // ....Z%.:.....h`.
  .hash algorithm 0x00008004
  .ver 1:0:899:30536
}
.module Shapes.dll
// MVID: {A843C759-BE7E-407E-BE71-88340CC07F18}
.imagebase 0x11000000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000009
// Image base: 0x03c00000
//
// ============== CLASS STRUCTURE DECLARATION ==================
//
.namespace Shapes
{
  .class public auto ansi beforefieldinit Circle
         extends [mscorlib]System.Object
  {
  } // end of class Circle

  .class public auto ansi beforefieldinit Triangle
         extends [mscorlib]System.Object
  {
  } // end of class Triangle

} // end of namespace Shapes


// =============================================================


// =============== GLOBAL FIELDS AND METHODS ===================


// =============================================================


// =============== CLASS MEMBERS DECLARATION ===================
//   note that class flags, 'extends' and 'implements' clauses
//          are provided here for information only

.namespace Shapes
{
  .class public auto ansi beforefieldinit Circle
         extends [mscorlib]System.Object
  {
    .field private float64 Radius
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       22 (0x16)
      .maxstack  2
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  ldc.r8     0.0
      IL_0010:  stfld      float64 Shapes.Circle::Radius
      IL_0015:  ret
    } // end of method Circle::.ctor

    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(float64 givenRadius) cil managed
    {
      // Code size       14 (0xe)
      .maxstack  2
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  ldarg.1
      IL_0008:  stfld      float64 Shapes.Circle::Radius
      IL_000d:  ret
    } // end of method Circle::.ctor

    .method public hidebysig instance void 
            Draw() cil managed
    {
      // Code size       12 (0xc)
      .maxstack  2
      .locals init ([0] class [System.Drawing]System.Drawing.Pen p)
      IL_0000:  call       valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Red()
      IL_0005:  newobj     instance void [System.Drawing]System.Drawing.Pen::.ctor(valuetype [System.Drawing]System.Drawing.Color)
      IL_000a:  stloc.0
      IL_000b:  ret
    } // end of method Circle::Draw

    .method public hidebysig instance float64 
            Area() cil managed
    {
      // Code size       28 (0x1c)
      .maxstack  3
      .locals init ([0] float64 CS$00000003$00000000)
      IL_0000:  ldc.r8     3.1415926535897931
      IL_0009:  ldarg.0
      IL_000a:  ldfld      float64 Shapes.Circle::Radius
      IL_000f:  ldarg.0
      IL_0010:  ldfld      float64 Shapes.Circle::Radius
      IL_0015:  mul
      IL_0016:  mul
      IL_0017:  stloc.0
      IL_0018:  br.s       IL_001a

      IL_001a:  ldloc.0
      IL_001b:  ret
    } // end of method Circle::Area

  } // end of class Circle

  .class public auto ansi beforefieldinit Triangle
         extends [mscorlib]System.Object
  {
    .field private float64 Base
    .field private float64 Height
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       37 (0x25)
      .maxstack  2
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  ldc.r8     0.0
      IL_0010:  stfld      float64 Shapes.Triangle::Base
      IL_0015:  ldarg.0
      IL_0016:  ldc.r8     0.0
      IL_001f:  stfld      float64 Shapes.Triangle::Height
      IL_0024:  ret
    } // end of method Triangle::.ctor

    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(float64 givenBase,
                                 float64 givenHeight) cil managed
    {
      // Code size       21 (0x15)
      .maxstack  2
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  ldarg.1
      IL_0008:  stfld      float64 Shapes.Triangle::Base
      IL_000d:  ldarg.0
      IL_000e:  ldarg.2
      IL_000f:  stfld      float64 Shapes.Triangle::Height
      IL_0014:  ret
    } // end of method Triangle::.ctor

    .method public hidebysig instance float64 
            Area() cil managed
    {
      // Code size       28 (0x1c)
      .maxstack  2
      .locals init ([0] float64 CS$00000003$00000000)
      IL_0000:  ldc.r8     0.5
      IL_0009:  ldarg.0
      IL_000a:  ldfld      float64 Shapes.Triangle::Base
      IL_000f:  mul
      IL_0010:  ldarg.0
      IL_0011:  ldfld      float64 Shapes.Triangle::Height
      IL_0016:  mul
      IL_0017:  stloc.0
      IL_0018:  br.s       IL_001a

      IL_001a:  ldloc.0
      IL_001b:  ret
    } // end of method Triangle::Area

  } // end of class Triangle


// =============================================================

} // end of namespace Shapes

//*********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file C:\BegVCSharp\Chapter21\Shapes\bin\Debug\shapes.res
