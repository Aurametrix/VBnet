Option Explicit
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Copyright ©1996-2011 VBnet/Randy Birch, All Rights Reserved.
' Some pages may also contain other copyrights by the author.
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Distribution: You can freely use this code in your own
'               applications, but you may not reproduce 
'               or publish this code on any web site,
'               online service, or distribute as source 
'               on any media without express permission.
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
 Public Sub QuickSortNumericAscending(narray() As Long, inLow As Long, inHi As Long)

   Dim pivot As Long
   Dim tmpSwap As Long
   Dim tmpLow As Long
   Dim tmpHi  As Long
   
   tmpLow = inLow
   tmpHi = inHi
   
   pivot = narray((inLow + inHi) / 2)

   While (tmpLow <= tmpHi)
       
      While (narray(tmpLow) < pivot And tmpLow < inHi)
         tmpLow = tmpLow + 1
      Wend
   
      While (pivot < narray(tmpHi) And tmpHi > inLow)
         tmpHi = tmpHi - 1
      Wend

      If (tmpLow <= tmpHi) Then
         tmpSwap = narray(tmpLow)
         narray(tmpLow) = narray(tmpHi)
         narray(tmpHi) = tmpSwap
         tmpLow = tmpLow + 1
         tmpHi = tmpHi - 1
      End If
      
   Wend
    
   If (inLow < tmpHi) Then QuickSortNumericAscending narray(), inLow, tmpHi
   If (tmpLow < inHi) Then QuickSortNumericAscending narray(), tmpLow, inHi

End Sub


Public Sub QuickSortNumericDescending(narray() As Long, inLow As Long, inHi As Long)

   Dim pivot As Long
   Dim tmpSwap As Long
   Dim tmpLow As Long
   Dim tmpHi  As Long
   
   tmpLow = inLow
   tmpHi = inHi
   
   pivot = narray((inLow + inHi) / 2)
   
   While (tmpLow <= tmpHi)
        
      While (narray(tmpLow) > pivot And tmpLow < inHi)
         tmpLow = tmpLow + 1
      Wend
      
      While (pivot > narray(tmpHi) And tmpHi > inLow)
         tmpHi = tmpHi - 1
      Wend
      
      If (tmpLow <= tmpHi) Then
         tmpSwap = narray(tmpLow)
         narray(tmpLow) = narray(tmpHi)
         narray(tmpHi) = tmpSwap
         tmpLow = tmpLow + 1
         tmpHi = tmpHi - 1
      End If
      
   Wend
    
   If (inLow < tmpHi) Then QuickSortNumericDescending narray(), inLow, tmpHi
   If (tmpLow < inHi) Then QuickSortNumericDescending narray(), tmpLow, inHi

End Sub


Public Sub QuickSortStringsAscending(sarray() As String, inLow As Long, inHi As Long)
  
   Dim pivot As String
   Dim tmpSwap As String
   Dim tmpLow As Long
   Dim tmpHi As Long
   
   tmpLow = inLow
   tmpHi = inHi
   
   pivot = sarray((inLow + inHi) / 2)
  
   While (tmpLow <= tmpHi)
   
      While (sarray(tmpLow) < pivot And tmpLow < inHi)
         tmpLow = tmpLow + 1
      Wend
      
      While (pivot < sarray(tmpHi) And tmpHi > inLow)
         tmpHi = tmpHi - 1
      Wend
      
      If (tmpLow <= tmpHi) Then
         tmpSwap = sarray(tmpLow)
         sarray(tmpLow) = sarray(tmpHi)
         sarray(tmpHi) = tmpSwap
         tmpLow = tmpLow + 1
         tmpHi = tmpHi - 1
      End If
   
   Wend
  
   If (inLow < tmpHi) Then QuickSortStringsAscending sarray(), inLow, tmpHi
   If (tmpLow < inHi) Then QuickSortStringsAscending sarray(), tmpLow, inHi
  
End Sub


Public Sub QuickSortStringsDescending(sarray() As String, inLow As Long, inHi As Long)
  
   Dim pivot As String
   Dim tmpSwap As String
   Dim tmpLow As Long
   Dim tmpHi As Long
   
   tmpLow = inLow
   tmpHi = inHi
   
   pivot = sarray((inLow + inHi) / 2)
   
   While (tmpLow <= tmpHi)
      
      While (sarray(tmpLow) > pivot And tmpLow < inHi)
         tmpLow = tmpLow + 1
      Wend
    
      While (pivot > sarray(tmpHi) And tmpHi > inLow)
         tmpHi = tmpHi - 1
      Wend

      If (tmpLow <= tmpHi) Then
         tmpSwap = sarray(tmpLow)
         sarray(tmpLow) = sarray(tmpHi)
         sarray(tmpHi) = tmpSwap
         tmpLow = tmpLow + 1
         tmpHi = tmpHi - 1
      End If
  
   Wend
  
   If (inLow < tmpHi) Then QuickSortStringsDescending sarray(), inLow, tmpHi
   If (tmpLow < inHi) Then QuickSortStringsDescending sarray(), tmpLow, inHi
  
End Sub