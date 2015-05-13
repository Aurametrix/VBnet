Public Class People
    Public Sub Sort(Of T As IComparable)(KeySelector As Func(Of Person, T))
        Array.Sort(_people, Function(x, y) KeySelector(x).CompareTo(KeySelector(y)))
    End Sub
End Class
