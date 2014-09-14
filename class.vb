Class Example
    Private _value As Integer

    Public Sub New()
	_value = 2
    End Sub

    Public Function Value() As Integer
	Return _value * 2
    End Function
End Class

Module Module1
    Sub Main()
	Dim x As Example = New Example()
	Console.WriteLine(x.Value())
    End Sub
End Module
