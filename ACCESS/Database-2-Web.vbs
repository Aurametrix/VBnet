' iMacros Database-2-Web Script
' (c) 2008-2010 iOpus Software 

'Read from a Microsoft ACCESS database
'This example requires the ADODB component (MDAC/ADO) from Microsoft
'If you have ACCESS installed, this component is installed as well.
 
Option Explicit
dim rs, iim1, sql
dim myname, mypath, connstring
dim iret


dim message 
message = "This script demonstrates how to read data from an ACCESS database and submit this information to a website."
message = message + " It reads from the database <IIM-TEST-SUBMIT.MDB> and uses the macro <wsh-submit-2-web>." + vbCrLf + VbCrLf 
message = message + "Tip: This script has the same function as <file-2-web-method2.vbs> but reads the data from a database instead of a text file."

MsgBox (message)

'Note for x64 users: You must start the VBS script in 32bit mode (C:\Windows\SysWOW64\wscript.exe) for the Microsoft ODBC Driver to work
'Please see the note about VBS scripts on http://wiki.imacros.net/x64 for more details 

' find current folder
myname = WScript.ScriptFullName
mypath = Left(myname, InstrRev(myname, "\"))


' open ACCESS database
set rs = CreateObject("ADODB.Connection")

connstring = "DRIVER={Microsoft Access Driver (*.mdb)}; DBQ=" & mypath & "IIM-TEST-SUBMIT.MDB"

'NOTE: Top open an SQL database instead of an ACCESS database please use:
'
'connstring = "driver={SQL Server};server=<SQLServerNameHere>;uid=<SQLUserIDHere>;pwd=<SQLPasswordHere>;database=databaseNameHere>"
'

rs.Open (connstring)

' use SQL to select information
sql = "select * from table1"
set rs = rs.Execute(sql)

set iim1= CreateObject ("imacros")
iret = iim1.iimOpen("")
iret = iim1.iimDisplay("Submitting Data from MS ACCESS")

do until rs.eof
   'Set the variable
   iret = iim1.iimSet("FNAME", rs.fields(0))
   iret = iim1.iimSet("LNAME", rs.fields(1))
   iret = iim1.iimSet("ADDRESS", rs.fields(2))
   iret = iim1.iimSet("CITY", rs.fields(3))
   iret = iim1.iimSet("ZIP", rs.fields(4))
   iret = iim1.iimSet("STATE-ID", rs.fields(5))
   iret = iim1.iimSet("COUNTRY-ID", rs.fields(6))
   iret = iim1.iimSet("EMAIL", rs.fields(7))
   'Run the macro
   'Note: This is the SAME macro, as in the FILE-2-WEB-METHOD2.VBS example script!!!
   iret = iim1.iimPlay(mypath & "Macros\wsh-submit-2-web.iim")
   If iret < 0 Then
        MsgBox "Error code: "+cstr(iret) + VbCrLf + "Error Text: "+iim1.iimGetErrorText()
   End If
  rs.movenext
loop

iret = iim1.iimDisplay("Done!")
iret = iim1.iimClose
WScript.Quit(iret)
