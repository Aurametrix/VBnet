Module Module1
    Sub Main()
	' Add integers to Queue.
	Dim q As Queue(Of Integer) = New Queue(Of Integer)()
	q.Enqueue(5)
	q.Enqueue(10)
	q.Enqueue(15)
	q.Enqueue(20)

	' Loop over the Queue.
	For Each element As Integer In q
	    Console.WriteLine(element)
	Next
    End Sub
End Module
