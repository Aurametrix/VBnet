'----------------------------------------------------
'-
'-The following example creates a linked list of 20 nodes, and then reverses it 
'-using a function named ReverseList. Each node in the list is actually an instance of 
'-a Visual Basic Class created with the New keyword. 
'-
'----------------------------------------------------
'-Start a new project in Visual Basic and choose "Standard EXE." Form1 is created by default.
'-From the Project menu, choose Add Class Module, Class1 is created by default. In the Properties window of the new class module, change the name from Class1 to "Node," then Paste the following code into the General Declarations section of Node:
'-      Public key As Integer          'var to hold some data
'-      Public pnext As node           'pointer to next node in list
'-
'-Add a Command button, Command1, to Form1.
'-Paste the following code into the General Declarations section of Form1:


      Dim head As node               'object pointer to head of list


      Private Sub Form_Load()
        Dim curr As node             'object pointer to current pos in
        Dim i As Integer             'list used in For loop

        'CREATE LIST
        Set head = New node          'object pointer to new node
        head.Key = 0                 'dummy head
        Set curr = head              'keep head pointer here
        For i = 1 To 20              'iterate n times to fill list
          Set curr.pnext = New node  'insert new node after current
          Set curr = curr.pnext      'set current one = new node
          curr.Key = i               'set new node key value
        Next i
        Set curr.pnext = New node    'dummy tail
        Set curr = curr.pnext        'move current to dummy tail
        curr.Key = 0                 'set value of dummy tail
        Set curr.pnext = curr        'points to itself to identify end

        Debug.Print "before: " & DumpList(head) 'print list
      End Sub

      Private Sub Command1_click()
        'RERVERSE LIST
        ReverseList head             'pass in head to ReverseList
        Debug.Print "after: " & DumpList(head)  'print reversed list
      End Sub

      Private Sub ReverseList(ByRef head As node)
        'reverse entire list including dummy head and tail
        'Note: head becomes tail, tail becomes head
        Dim curr As node             'object pointer to current node
        Dim nexx As node             'object pointer to next node
        Set curr = head.pnext        'current to node after head
        Set head.pnext = head        'turn head into tail
        While Not curr.pnext Is curr 'walk entire list
          Set nexx = curr.pnext      'pointer to node after current
          Set curr.pnext = head      'current points back to head
          Set head = curr            'move head to current
          Set curr = nexx            'set current = next node
        Wend
        Set curr.pnext = head        'point new head to first node
        Set head = curr              'return head to first position
      End Sub

      Private Function DumpList(ByRef head As node) As String
        'walk list and dump to debug window
        Dim strOut As String         'temp var to hold string
        Dim curr As node             'object pointer to current node
        Set curr = head.pnext        'skip dummy head
        While Not curr.pnext Is curr 'walk rest of list to end
          strOut = strOut & " " & CStr(curr.Key)
          Set curr = curr.pnext      'current pointer to next node
        Wend
        DumpList = strOut            'return string
      End Function


'-Start the program or press the F5 key. A linked list of 20 nodes will be created.
'-Click the Command1 button to Reverse the list and print the results to the debug window.
