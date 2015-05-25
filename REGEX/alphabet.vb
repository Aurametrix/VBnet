Function CheckForAlphaCharacters(ByVal StringToCheck As String)


    For i = 0 To StringToCheck.Length - 1
        If Char.IsLetter(StringToCheck.Chars(i)) Then
            Return True
        End If
    Next

    Return False

End Function
