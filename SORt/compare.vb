Public Class myComparer : Implements IComparer
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer
    Implements System.Collections.IComparer.Compare
      If x < y Then Return -1
      If x > y Then Return 1
      Return 0
    End Function
End Class