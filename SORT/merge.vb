''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' IN-PLACE sort
' original unsorted array replaced by the resulting sorted sequence
' minimizing memory consumption 
' ByVal and ByRef mean reference types 					
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


Public Sub MergeSort(ByVal ar() As Integer)
     DoMergeSort(ar, 0, ar.Length - 1)
End Sub

Private Sub DoMergeSort(ByVal ar() As Integer, _
ByVal low As Integer, ByVal high As Integer)

If low >= high Then Return 
        Dim length As Integer = high - low + 1
        Dim middle As Integer = Math.Floor((low + high) / 2)
        DoMergeSort(ar, low, middle)
        DoMergeSort(ar, middle + 1, high)
        Dim temp(ar.Length - 1) As Integer
        For i As Integer = 0 To length - 1
            temp(i) = ar(low + i)
        Next
        Dim m1 As Integer = 0
        Dim m2 As Integer = middle - low + 1
        For i As Integer = 0 To length - 1
If m2 <= high - low Then
If m1 <= middle - low Then
If temp(m1) > temp(m2) Then
                        ar(i + low) = temp(m2)
                        m2 += 1
                    Else
                        ar(i + low) = temp(m1)
                        m1 += 1
                    End If
                Else
                    ar(i + low) = temp(m2)
                    m2 += 1
                End If
            Else
                ar(i + low) = temp(m1)
                m1 += 1
            End If
        Next
