Private Sub arrInsert(arr, pos, elem)
    i = pos - 1
    Do While i >= 0 And arr(i) > elem
        a(i + 1) = a(i)
        i = i - 1
    Loop
    a(i + 1) = elem
End Sub