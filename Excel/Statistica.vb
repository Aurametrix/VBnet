Sub ExcelTest()
' Run the STATISTICA application; create the STATISTICA
' Application object and assign it to variable (object) StatApp.
     Dim StatApp As New STATISTICA.Application
' Create a STATISTICA Basic Statistics object (i.e., run the
' Basic Statistics module; start it with data file exp
' (note: the actual location of that data file may be
' different on your installation).
     Dim s As Spreadsheet
     Set s = StatApp.Spreadsheets.Open _
     (StatApp.Path & "\Examples\DataSets\Exp.sta")
     Dim BasStat As STATISTICA.Analysis
     Set BasStat = StatApp.Analysis(scBasicStatistics, s)
' the following 7 lines of code will produce a summary results
' Spreadsheet from the STATISTICA Basic Statistics module.
     BasStat.Dialog.Statistics = scBasDescriptives
     BasStat.Run
     BasStat.Dialog.Variables = "5-8"
     Dim out
     Set out = BasStat.Dialog.Summary
' Select all rows and columns in the STATISTICA results Spreadsheet.
     out.Item(1).SelectAll
' Copy the highlight selection (all rows and columns in the
' Summary results Spreadsheet.
     out.Item(1).Copy
' Set the cursor to cell A1 in the currently active Excel Spreadsheet.
     Range("A1").Select
' Paste in the summary statistics.
     ActiveSheet.PasteSpecial Format:="Biff4"
     s.Close
End Sub
