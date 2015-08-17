Private Sub CheckPalindrome(ByVal strString As String)
        Dim str As String
        str = StrReverse(strString)
        If str.Equals(strString) Then
            MessageBox.show("This string is Palindrome.")
        Else
            MessageBox.show("This string is not Palindrome.")
        End If
    End Sub

Public Function IsPalindrome(s As String) As Boolean
 Dim i As Integer = 0
 Dim j As Integer = s.Length - 1
 While i < j
  If s(i) <> s(j) Then
   Return False
  End If
  i += 1
  j -= 1
 End While
 Return True
End Function
