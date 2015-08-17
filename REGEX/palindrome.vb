Private Sub CheckPalindrome(ByVal strString As String)
        Dim str As String
        str = StrReverse(strString)
        If str.Equals(strString) Then
            MessageBox.show("This string is Palindrome.")
        Else
            MessageBox.show("This string is not Palindrome.")
        End If
    End Sub
