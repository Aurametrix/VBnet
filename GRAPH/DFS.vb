lbOutput.Items.Clear()
       Dim s As String = txtStartnode.Text.ToUpper
       Dim graphtext As String = ""
       Dim a As String = ""
       If rdbBreadth.Checked = True Then
           lbOutput.Items.Add(s & "(0)")
 
           LbTree.Items.Add(txtStartnode.Text.ToUpper & " (" & 0 & ")")
           Dim root As String = ""
              
                 'For each item of search tree in listbox, do the following
           'For i = 0 To LbGraph.Items.Count - 1
           For each item in LbGraph.Items
              graphText = LbGraph.Items(i)

              If InStr(graphText, txtStartnode.Text.ToUpper) <> 0 Then
                  If InStr(graphText, txtStartnode.Text.ToUpper) = 2 Then
                      root = Mid(graphText, 2, 1) & Mid(graphText, 1, 1)
                  Else
                      root = Mid(graphText, 1, 2)
                  End If

                  a = a & root & "(" & Int(Mid(graphtext, 4)) & ")" & " "

              Else
                  'No Item Add
              End If

                
           Next
           lbOutput.Items.Add(a)        
 
       End If
 
   End Sub
