 Protected Sub txtPhone_TextChanged(sender As Object, e As EventArgs) Handles txtPhone.TextChanged
    If Not IsPhoneNumberValid(txtPhone.Text) Then
        Dim isvalid = False
        lblValidatioMessage.Visible = True
        lblValidatioMessage.Text = "*Invalid Phonenumber"
    Else
        lblValidatioMessage.Visible = False
        lblValidatioMessage.Text = ""
    End If
End Sub

Private Shared Function IsPhoneNumberValid(phoneNumber As String) As Boolean
    Dim result As String = ""
    Dim chars As Char() = phoneNumber.ToCharArray()
    For count = 0 To chars.GetLength(0) - 1
        Dim tempChar As Char = chars(count)
        If [Char].IsDigit(tempChar) Or "()+-., ".Contains(tempChar.ToString()) Then

            result += StripNonAlphaNumeric(tempChar)
        Else
            Return False
        End If

    Next

    Return result.Length = 10 'Length of US phone numbers is 10
End Function

Private Shared Function StripNonAlphaNumeric(value As String) As String
    Dim regex = New Regex("[^0-9a-zA-Z]", RegexOptions.None)
    Dim result As String = ""
    If regex.IsMatch(value) Then
        result = regex.Replace(value, "")
    Else
        result = value
    End If

    Return result
End Function
