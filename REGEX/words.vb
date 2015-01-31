Imports System.Text.RegularExpressions

Module Module1

    Sub Main()
	' Match ignoring case of letters.
	Dim match As Match = Regex.Match("I like that cat",
					 "C.T",
					 RegexOptions.IgnoreCase)
	If match.Success Then
	    ' Write value.
	    Console.WriteLine(match.Value)
	End If
    End Sub

End Module
