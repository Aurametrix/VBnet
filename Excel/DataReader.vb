Private Function ReadExcelFile(ByVal filePath As String, ByVal fileName As String) As DataSet
'' Excel 2003
Dim sConn As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", filePath + fileName)
sConn += ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1;"""

'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyExcel.xls;Extended Properties="Excel 8.0;HDR=Yes;IMEX=1";

Dim sSql As String = "SELECT * FROM [Sheet1$]"
'Select excel range command
' Dim sSql As String = "SELECT * FROM [Sheet1$A1:D3]"

Dim pFile As New FileInfo(fileName)
If (pFile.Extension.ToLower() = ".xlsx") Then
' Excel 2007
sConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", filePath + fileName)
sConn += ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
End If


Dim ds As New DataSet
Dim pConn As New OleDbConnection(sConn)
Try
pConn.Open()
Dim pCmd As New OleDbCommand()
pCmd.Connection = pConn
pCmd.CommandText = sSql

Dim pAdp As New OleDbDataAdapter()
pAdp.SelectCommand = pCmd

pAdp.Fill(ds)
Catch ex As Exception
Return Nothing
Finally
pConn.Close()
End Try

Return ds
End Function
