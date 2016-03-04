'ƒiƒ“ƒo[‚RAƒtƒBƒ‹ƒ^ƒŠƒ“ƒOƒƒ\ƒbƒh‚Ìƒ‚ƒWƒ…[ƒ‹

Sub ClassSortMethod(x As Long, y As Long)

'Base data“à‚ÅV‚½‚ÉA•À‚Ñ‘Ö‚¦‚ðs‚¢‚½‚¢ê‡‚Ìƒƒ\ƒbƒh
'
'
'
    Dim WB As Workbook
    Dim SH As Worksheet
    
    Set WB = ThisWorkbook
    Set SH = WB.Worksheets("Base data")
    
    SH.Select
    Dim firstcolumn As Integer 'ƒTƒ“ƒvƒ‹‚ªŠi”[‚³‚ê‚Ä‚é—ñ‚ÌÅ‰‚Ì—ñ
    firstcolumn = 2
    SH.Sort.SortFields.Clear
    SH.Sort.SortFields.Add Key:=Range(Cells(1, firstcolumn), Cells(1, firstcolumn + x - 1)), _
        SortOn:=xlSortOnValues, Order:=xlAscending, DataOption:=xlSortNormal
    With SH.Sort
        .SetRange Range(Cells(1, firstcolumn), Cells(y, firstcolumn + x - 1))
        .Header = xlGuess
        .MatchCase = False
        .Orientation = xlLeftToRight
        .SortMethod = xlPinYin
        .Apply
    End With
    
End Sub
