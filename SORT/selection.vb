Private Sub SelectionSortNumbers(varray As Variant)

   Dim cnt1 As Long
   Dim cnt2 As Long
   Dim nMin As Long
   Dim tmp As Long
   Dim counter As Long
   
   Label13.Caption = "Working..."

   For cnt1 = LBound(varray) To UBound(varray) - 1

      nMin = cnt1

      For cnt2 = (cnt1 + 1) To UBound(varray)

         If varray(cnt2) < varray(nMin) Then
            nMin = cnt2
           '----------------------------------------------------
           'comment out for real use
           'update the iterations label
            counter = counter + 1
           '----------------------------------------------------
         End If

          '----------------------------------------------------
          'Required to enable abort of speed Test;
          'comment out for real use
           DoEvents
           If SkipFlag Then Exit For
          '----------------------------------------------------

      Next cnt2

      tmp = varray(nMin)
      varray(nMin) = varray(cnt1)
      varray(cnt1) = tmp

   Next cnt1

   Label13.Caption = "Elements swapped : " & counter

End Sub