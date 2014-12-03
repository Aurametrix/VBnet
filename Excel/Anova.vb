Option Compare Text
Option Explicit On 
Option Strict On

Public Class Anova
    Private vbApp As CreateSPSSProblems
    Public dvNumber As Integer = -1
    Public dvName As String
    Public dvLabel As String = ""
    Public dvLevel As String = ""
    Public dvNoun As String = ""
    Public ivname As String = ""
    Public ivNumber As Integer = -1
    Public ivLabel As String = ""
    Public ivLevel As String = ""
    Public ivNoun As String = ""
    Public cvname As String = ""
    Public cvNumber As Integer = -1
    Public cvLabel As String = ""
    Public cvLevel As String = ""
    Public cvNoun As String = ""
    Public levelOfSignificance As Double

    ' Public nRows As Integer
    'Public nColumns As Integer
    'Public ivGroups As ArrayList = New ArrayList
    'Public dvGroups As ArrayList = New ArrayList

    'Public cellCounts As String(,)
    'Public cellColumnPercents As String(,)
    'Public cellRowPercents As String(,)
    'Public cellTotalPercents As String(,)
    'Public cellX2s As String(,)
    'Public cellExpectedCounts As String(,)
    'Public cellResiduals As String(,)
    'Public cellStandardizedResiduals As String(,)
    'Public cellAdjStandardizedResiduals As String(,)

    Public skewness As String
    Public kurtosis As String
    Public nInGroups As String()
    Public groupCodes As String()
    Public groupMeans As String()
    Public f As String
    Public fSig As String
    Public levene As String
    Public leveneSig As String
    Public postHocDifferences As ArrayList = New ArrayList
    Public nonSignificantDifferences As ArrayList = New ArrayList
    'Public minimumExpectedCount As String

    Public Sub New(ByVal app As CreateSPSSProblems)
        vbApp = app
    End Sub

    Public Sub Oneway()
        Dim strCommand As String, rowHeaders As String(), colHeaders As String()
        Dim si As SPSSInterface = New SPSSInterface

        ' compute skew and kurtosis for analysis
        strCommand = "EXAMINE VARIABLES = " + vbApp.dvName _
            + "  /STATISTICS=DESCRIPTIVES" _
            + "  /CINTERVAL " + CStr(100 - 100 * levelOfSignificance) _
            + "  /MISSING LISTWISE" _
            + "  /NOTOTAL."
        si.ExecuteSPSSCommand(strCommand)
        si.CopyPivotTableToArray("Descriptives", "", nrowheadercols:=3, ncolheaderrows:=1)
        colHeaders = New String() {"Statistic"}
        rowHeaders = New String() {vbApp.dvName.ToUpper + "  " + vbApp.dvLabel, "Skewness", ""}
        skewness = si.ExtractFromPivotTableArrays(rowHeaders, colHeaders)
        rowHeaders = New String() {vbApp.dvName.ToUpper + "  " + vbApp.dvLabel, "Kurtosis", ""}
        kurtosis = si.ExtractFromPivotTableArrays(rowHeaders, colHeaders)

        si.DeletePreviousOutput()
        strCommand = "ONEWAY " + dvName + " BY " + ivname _
            + "  /STATISTICS DESCRIPTIVES HOMOGENEITY" _
            + "  /MISSING ANALYSIS" _
            + "  /POSTHOC = TUKEY ALPHA(" + CStr(levelOfSignificance) + ")."
        si.ExecuteSPSSCommand(strCommand)

        ' number in each group to check for central limit theorem
        si.CopyPivotTableToArray("Descriptives", "", nrowheadercols:=1, ncolheaderrows:=2)
        Dim nRowLabels As Integer = si.rowLabels.GetUpperBound(0) - 1 ' - 1 for total row
        Dim grpLabels(nRowLabels) As String, bl1 As Integer
        ReDim rowHeaders(0), nInGroups(nRowLabels), groupMeans(nRowLabels), groupCodes(nRowLabels)
        For i As Integer = 0 To nRowLabels
            grpLabels(i) = si.rowLabels(i, 0)
            ' add extra blank between code number and label
            bl1 = grpLabels(i).IndexOf(" ")
            grpLabels(i) = grpLabels(i).substring(0, bl1) + " " + grpLabels(i).Substring(bl1)
            groupCodes(i) = grpLabels(i).substring(0, bl1)
            rowHeaders(0) = si.rowLabels(i, 0)
            colHeaders = New String() {"N", ""}
            nInGroups(i) = si.ExtractFromPivotTableArrays(rowHeaders, colHeaders)
            colHeaders = New String() {"Mean", ""}
            groupMeans(i) = si.ExtractFromPivotTableArrays(rowHeaders, colHeaders)
        Next

        si.CopyPivotTableToArray("Test of Homogeneity of Variances", "", _
            nrowheadercols:=0, ncolheaderrows:=1)
        rowHeaders = New String() {""}
        colHeaders = New String() {"Levene Statistic"}
        levene = si.ExtractFromPivotTableArrays(rowHeaders, colHeaders)
        colHeaders = New String() {"Sig."}
        leveneSig = si.ExtractFromPivotTableArrays(rowHeaders, colHeaders)

        si.CopyPivotTableToArray("ANOVA", "", nrowheadercols:=1, ncolheaderrows:=1)
        rowHeaders = New String() {"Between Groups"}
        colHeaders = New String() {"F"}
        f = si.ExtractFromPivotTableArrays(rowHeaders, colHeaders)
        colHeaders = New String() {"Sig."}
        fSig = si.ExtractFromPivotTableArrays(rowHeaders, colHeaders)
        If CDbl(fSig) > levelOfSignificance Then Exit Sub

        si.CopyPivotTableToArray("Multiple Comparisons", "", nrowheadercols:=2, ncolheaderrows:=2)
        colHeaders = New String() {"95% Confidence Interval", "Lower Bound"}
        Dim lb, ub As Double
        Dim ciLevel As Integer = 100 - CInt(100 * levelOfSignificance)
        Dim ciString As String = CStr(ciLevel) + "% Confidence Interval"
        For i As Integer = 0 To nRowLabels
            For j As Integer = i + 1 To nRowLabels
                rowHeaders = New String() {grpLabels(i), grpLabels(j)}
                colHeaders = New String() {ciString, "Lower Bound"}
                lb = CDbl(si.ExtractFromPivotTableArrays(rowHeaders, colHeaders))
                colHeaders = New String() {ciString, "Upper Bound"}
                ub = CDbl(si.ExtractFromPivotTableArrays(rowHeaders, colHeaders))
                Dim a As ArrayList = New ArrayList
                a.Add(grpLabels(i).Substring(0, grpLabels(i).IndexOf(" ")).trim)
                a.Add(grpLabels(j).Substring(0, grpLabels(j).IndexOf(" ")).Trim)
                colHeaders = New String() {"MEAN DIFFERENCE (I-J)", ""}
                a.Add(si.ExtractFromPivotTableArrays(rowHeaders, colHeaders))
                ' if ci straddles zero, difference is not sig
                If (lb < 0 And ub <= 0) Or (lb >= 0 And ub > 0) Then
                    postHocDifferences.Add(a)
                Else
                    nonSignificantDifferences.Add(a)
                End If
            Next
        Next
    End Sub

End Class
