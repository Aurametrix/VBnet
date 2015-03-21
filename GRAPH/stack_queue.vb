Module Module1

    Sub Main()
        myQuequeue()
        myStack()
        Console.ReadLine()
    End Sub

 Private Sub myQuequeue()
        Dim theQ As New Queue
        Dim dStr, frmstrArr() As String
        Dim i As Integer

        frmstrArr = FillArr()

        For i = 0 To 25
            theQ.Enqueue(frmstrArr(i) + " queue")
        Next
        For i = 0 To 25
            dStr = theQ.Dequeue()
            Console.WriteLine(dStr)
        Next

    End Sub

    Private Sub myStack()
        Dim theStack As New Stack
        Dim dStr, fStr() As String
        Dim i As Integer

        fStr = FillArr()

        For i = 0 To 25
            theStack.Push(fStr(i) + " stack")
        Next
        For i = 0 To 25
            dStr = theStack.Pop()
            Console.WriteLine(dStr)
        Next
    End Sub
 
 Private Function FillArr()
        Dim strArr(25) As String

        strArr = New String() {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}

        Return strArr
    End Function
end module
