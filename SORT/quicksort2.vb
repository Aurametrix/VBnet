Option Explicit

Dim fontArray() As String
Dim numArray() As Long

Private Sub Form_Load()

   Command1.Enabled = False
   Command2.Enabled = False
   Command3.Enabled = False
   Command4.Enabled = False
   
End Sub


Private Sub Command1_Click()

   Dim x As Long
   
   QuickSortStringsAscending fontArray, LBound(fontArray), UBound(fontArray)
   
   List3.Visible = False
   List3.Clear
   
   For x = LBound(fontArray) To UBound(fontArray)
      List3.AddItem fontArray(x)
   Next
   
   List3.Visible = True
   
End Sub


Private Sub Command2_Click()

   Dim x As Long
   
   QuickSortStringsDescending fontArray, LBound(fontArray), UBound(fontArray)
   
   List3.Visible = False
   List3.Clear
   
   For x = LBound(fontArray) To UBound(fontArray)
      List3.AddItem fontArray(x)
   Next
   
   List3.Visible = True
   
End Sub


Private Sub Command3_Click()

   Dim c As Long
   
   QuickSortNumericAscending numArray, LBound(numArray), UBound(numArray)

   List4.Visible = False
   List4.Clear
   
   For c = LBound(numArray) To UBound(numArray)
      List4.AddItem numArray(c)
   Next
   
   List4.Visible = True
   
End Sub


Private Sub Command4_Click()

   Dim c As Long
   
   QuickSortNumericDescending numArray, LBound(numArray), UBound(numArray)
   
   List4.Visible = False
   List4.Clear
   
   For c = LBound(numArray) To UBound(numArray)
      List4.AddItem numArray(c)
   Next
   
   List4.Visible = True
   
End Sub


Private Sub Command5_Click()

  'create a few arrays
   Dim x As Long
   Dim y As Long
   Dim elements As Long
   
   Erase fontArray
   Erase numArray
   
   List1.Visible = False
   List2.Visible = False
   List1.Clear
   List2.Clear
   
  '----------------------------------------
  'create a string array from the system fonts
   ReDim fontArray(0 To 5000) As String 'should be enough!
   
  'add the screen fonts to the array
   For x = 0 To Screen.FontCount - 1
      fontArray(x) = Screen.Fonts(x)
   Next
   
   y = x - 1
   
  'and to make it larger, add the printer fonts to the array
   For x = 0 To Printer.FontCount - 1
      fontArray(x + y) = Printer.Fonts(x)
   Next
   
  'nuke the unused portion
   ReDim Preserve fontArray(x - 1 + y)


  '----------------------------------------
  'create numeric array of random numbers 
  elements = 5000
   
   ReDim numArray(0 To elements) As Long

   Randomize CSng(Time)

   For x = LBound(numArray) To UBound(numArray)
      numArray(x) = ((elements - 1) * Rnd + 1)
   Next x
   

  '----------------------------------------
  'show unsorted arrays in list1 & list2
   For x = LBound(fontArray) To UBound(fontArray)
      List1.AddItem fontArray(x)
   Next x
   
   For x = LBound(numArray) To UBound(numArray)
      List2.AddItem numArray(x)
   Next x

   Command1.Enabled = True
   Command2.Enabled = True
   Command3.Enabled = True
   Command4.Enabled = True
   Command5.Caption = "Reload Arrays"
   
   List1.Visible = True
   List2.Visible = True
   
End Sub