#If Comment Then
Private Sub arrInsert(arr, pos, elem)
    i = pos - 1
    Do While i >= 0 And arr(i) > elem
        a(i + 1) = a(i)
        i = i - 1
    Loop
    a(i + 1) = elem
End Sub
#End If 

Module Module1

    Sub Main()

        Dim arr() As Integer = New Integer() {100, 12, 320, 34, 45, 90}
        'sort the array using insertion sort
        insertionSort(arr, arr.Length)
        Dim i As Integer
        For i = 0 To arr.Length - 1
            Console.WriteLine(arr(i))
        Next
        Console.ReadLine() 'wait for keypress
    End Sub

    Sub insertionSort(ByVal dataset() As Integer, ByVal n As Integer)
        Dim i, j As Integer
        For i = 1 To n - 1 Step 1
            Dim pick_item As Integer = dataset(i)
            Dim inserted As Integer = 0
            j = i - 1
            While (j >= 0 And inserted <> 1)

                If (pick_item < dataset(j)) Then
                    dataset(j + 1) = dataset(j)
                    j -= 1
                    dataset(j + 1) = pick_item

                Else : inserted = 1
                End If
 
            End While
        Next


    End Sub

 

End Module
