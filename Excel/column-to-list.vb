Sub ChangeRange()
'Updateby20140310
Dim rng As Range
Dim InputRng As Range, OutRng As Range
xTitleId = "KutoolsforExcel"
Set InputRng = Application.Selection
Set InputRng = Application.InputBox("Range :", xTitleId, InputRng.Address, Type:=8)
Set OutRng = Application.InputBox("Out put to (single cell):", xTitleId, Type:=8)
outStr = ""
For Each rng In InputRng
    If outStr = "" Then
        outStr = rng.Value
    Else
        outStr = outStr & "," & rng.Value
    End If
Next
OutRng.Value = outStr
End Sub
