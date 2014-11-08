  ' iMacros Extract-2-Database Script
' (c) 2008-2010 iOpus Software 

Option Explicit

Dim objFileSystem, objOutputFile
Dim strOutputFile


' find current folder
Dim myname, mypath
myname = WScript.ScriptFullName
mypath = Left(myname, InstrRev(myname, "\"))

'Note for x64 users: You must start the VBS script in 32bit mode (C:\Windows\SysWOW64\wscript.exe) 
'for the Microsoft ODBC Driver to work
'Please see the note about VBS scripts on http://wiki.imacros.net/x64 for more details 

' access database
Dim db
set db = CreateObject("ADODB.Connection")
db.Open("DRIVER={Microsoft Access Driver (*.mdb)}; DBQ=" _
& mypath & "IIM-TEST-EXTRACT.MDB")

Dim message
message = "This script demonstrates how to extract data from a web site and store this information directly in a database (MS ACCESS)."
message = message + " It uses the macro <wsh-extract-jobs.iim>." + vbCrLf + VbCrLf 
message = message + "Tip: This script has the same function as <extract-2-file.vbs> but stores the data in a database instead of a text file."

MsgBox(message)

Dim iim1, iret, iplay
set iim1= CreateObject ("imacros")
iret = iim1.iimOpen("")

if iret < 0 then
      MsgBox ("Error: " + CStr(iret))
      WScript.Quit(iret)
end if
      

Dim num, pos, str, rs, sql
For num = 1 To 3 
   str = cstr(num)  'Convert integer to string
   iret = iim1.iimDisplay("Listing No: " + str)

   pos = num '+ 4'start at 5: Offset for POS= statement
   str = cstr(pos)  'Convert integer to string
   iret = iim1.iimSet("myvar", str) 'Select a new link for each run

   iplay = iim1.iimPlay(mypath & "Macros\wsh-extract-jobs.iim")
   If iplay = 1  Then
	' use SQL to insert new data
	sql = "insert into tableJobListings (Salary, PositionType, RefCode) values ('" _
	& iim1.iimGetExtract(1) & "', '" & iim1.iimGetExtract(2) & "' ,  '" & iim1.iimGetExtract(3) & "')"

	' execute sql statement
	set rs = db.Execute(sql)
   End If

   If  iplay < 0 Then
      MsgBox "Error: " + iim1.iimGetErrorText()
   End If
Next

iret = iim1.iimClose

MsgBox "The data was stored in the <IIM-TEST-EXTRACT.MDB> database. The script is now completed."

WScript.Quit(iret)
Macro code for Wsh-Extract-Jobs:
TAB T=1     
TAB CLOSEALLOTHERS  
URL GOTO=http://demo.imacros.net/Automate/ExtractDemo2
TAG POS={{myvar}} TYPE=A ATTR=HREF:http://demo.imacros.net/Automate/listing*
TAG POS=1 TYPE=H3 ATTR=TXT:* EXTRACT=TXT

TAG POS=1 TYPE=LI ATTR=TXT:* EXTRACT=TXT
TAG POS=2 TYPE=LI ATTR=TXT:* EXTRACT=TXT
TAG POS=3 TYPE=LI ATTR=TXT:* EXTRACT=TXT
