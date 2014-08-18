''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' The Byte Index
' a pointer to the first node
' a pointer to the last node					

Private Structure ByteIndice
      Dim First As Long
      Dim Last As Long
End Structure

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' The Radix Part
' a pointer to the location of the actual data
' a pointer to the next node, which also has the byte index radix					

Private Structure PtrNextPtr
 Dim Ptr As Long
 Dim NextPtr As Long
End Structure

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Find the longest length string (m) in the list of strings

For i As Integer = 0 To WordList.Count - 1
 List_Pos(i) = i
 If WordList(i).Length > m Then
   m = WordList(i).Length
 End If
Next i
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Start string position m-1 (m-1 since the string position start at 0. Zero) work down to the 0th position.

For r As Integer = m - 1 To 0 Step -1
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'  Reset the Byte Index Array, I use -1
For i As Integer = 0 To 255
  byteindex(i).First = -1 : byteindex(i).Last = -1
Next i

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'  For Each String 

For i As Integer = 0 To WordList.Count - 1

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'  Get the list position
Ptr_Pos = List_Pos(i)

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'  If r is greater than the length of the string, we used the byteindex of zero, 
'  else we use the character code of the letter at position r of the string.
#
If r >= WordList(Ptr_Pos).Length Then
 ' Position is beyond the lenght of the string
 ' So give it a default value
 b = 0
Else
 ' Otherwise get value of character at current radix position
 b = Asc(WordList(Ptr_Pos).Substring(r, 1))
End If

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'  Set the Node Pointers. Next to a invalid value (-1), Ptr to Ptr_Pos
TmpNP(i).NextPtr = -1 ' end of node list
TmpNP(i).Ptr = Ptr_Pos

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'  If byteindex(b).first isn't invalid then there is already a node chain attached to it, attached this one on the end.
'  Otherwise attach the first node of the node chain.

If byteindex(b).First > -1 Then 
 ' Radix value has node chain attached to it
 ' so add a link to it by change Last node's next to point to this one
 TmpNP(byteindex(b).Last).NextPtr = i
Else
 ' Pointer to first node of this radix value
 byteindex(b).First = i
End If
' Pointer to last node of the radix value

'  Set the byteindex(b).last to i

byteindex(b).Last = i