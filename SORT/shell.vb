 Sub ShellSort(vArray AsVariant)
 Dim TempVal As Variant
 Dim i As Long, GapSize As Long, CurPos As Long
 Dim FirstRow As Long, LastRow As Long, NumRows As Long
 FirstRow = LBound(vArray) 
 LastRow = UBound(vArray) 
 NumRows = LastRow - FirstRow + 1
 Do
   GapSize = GapSize * 3 + 1
 Loop Until GapSize > NumRows
 Do
   GapSize = GapSize \ 3
   For i = (GapSize + FirstRow) To LastRow
     CurPos = i
     TempVal = vArray(i) 
     Do While CompareResult( _                    vArray(CurPos - GapSize),TempVal) 
       vArray(CurPos) = vArray(CurPos - GapSize) 
       CurPos = CurPos - GapSize
       If (CurPos - GapSize) < FirstRow Then Exit Do
     Loop
     vArray(CurPos) = TempVal
   Next
 Loop Until GapSize = 1
 End Sub
 Private Function CompareResult( _
   Value1 As Variant, Value2 As Variant)
   CompareResult = (Value1 > Value2) 
 End Function