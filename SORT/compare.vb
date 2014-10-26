Public Class myComparer : Implements IComparer
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer
    Implements System.Collections.IComparer.Compare
      If x < y Then Return -1
      If x > y Then Return 1
      Return 0
    End Function
End Class

' To use this comparer object to sort some string:
  dim al as new ArrayList, comp as new myComparer
  al.add("A")
  al.add("B")
  al.add("a")
  al.sort(al,comp)
