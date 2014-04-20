Sub BubbleSortNumbers(iArray As Variant)
  Dim lLoop1 As Long
  Dim lLoop2 As Long
  Dim lTemp As Long
  
  startTime = Time()
  For lLoop1 = UBound(iArray) To LBound(iArray) Step -1
    For lLoop2 = LBound(iArray) + 1 To lLoop1
      If iArray(lLoop2 - 1) > iArray(lLoop2) Then
        lTemp = iArray(lLoop2 - 1)
        iArray(lLoop2 - 1) = iArray(lLoop2)
        iArray(lLoop2) = lTemp
      End If
    Next lLoop2
  Next lLoop1
  endTime = Time()
  timeToSort = endTime - startTime
  timeTaken = "Bubble Sort: " & timeToSort
End Sub
