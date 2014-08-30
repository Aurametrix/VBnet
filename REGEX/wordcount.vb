Imports System.Text.RegularExpressions

Module Module1
    Sub Main()
	' Count words in this string.
	Dim value As String = "To be or not to be, that is the question."
	Dim count1 As Integer = CountWords(value)

	' Count words again.
	value = "Mary had a little lamb."
	Dim count2 As Integer = CountWords(value)

	' Display counts.
	Console.WriteLine(count1)
	Console.WriteLine(count2)
    End Sub

    ''' <summary>
    ''' Use regular expression to count words.
    ''' </summary>
    Public Function CountWords(ByVal value As String) As Integer
	' Count matches.
	Dim collection As MatchCollection = Regex.Matches(value, "\S+")
	Return collection.Count
    End Function
End Module
