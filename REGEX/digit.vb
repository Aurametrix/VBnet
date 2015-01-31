Imports System.Text.RegularExpressions

Module Module1
    Sub Main()
	Dim regex As Regex = New Regex("\d+")
	Dim match As Match = regex.Match("Dot 77 Perls")
	If match.Success Then
	    Console.WriteLine(match.Value)
	End If
    End Sub
End Module
