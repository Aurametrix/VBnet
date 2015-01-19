Global Const MaxNodes = 12
Global Const MaxLinks = 2
Global Const Infinite = 10000000

Type Node
  Name As String * 5
  Link(MaxLinks) As Integer
  Cost(MaxLinks) As Integer
End Type

Global Network(MaxNodes) As Node

Function Dijkstra (Start, Goal As Integer) As String
  ' This is the Dijkstra-algorithm. I translated it
  ' from Elan to VB. For more info on this algorithm,
  ' look into :
  ' E.W. Dijkstra, A note on two problems in connection
  ' with graphs, Numerische Mathematik Vol I, 1959

  ' This part will search the lowest cost to reach the
  ' goal-node from the start-node.
  Static TotalCost(NrNodes) As Integer
  Static Visited(NrNodes) As Integer
  For x% = 1 To NrNodes
    Visited(x%) = False
    TotalCost(x%) = DirectPathCost(Start, x%)
  Next x%
  TotalCost(Start) = 0
  Visited(Start) = True
  For x% = 1 To NrNodes - 1
    MinCost% = Infinite
    minnode% = 0
    For y% = 1 To NrNodes
      If Visited(y%) = False Then
        If TotalCost(y%) < MinCost% Then
          minnode% = y%
          MinCost% = TotalCost(y%)
        End If
      End If
    Next y%
    Visited(minnode%) = True
    For y% = 1 To NrNodes
      If Visited(y%) = False Then
        If TotalCost(minnode%) = Infinte Then
          NewValue% = Infinite
        Else
          NewValue% = DirectPathCost(minnode%, y%)
          If NewValue% <> Infinite Then
            NewValue% = NewValue% + TotalCost(minnode%)
          End If
        End If
        If NewValue% < TotalCost(y%) Then
          TotalCost(y%) = NewValue%
        End If
      End If
    Next y%
  Next x%
  ' I added this part myself.
  ' This will search the path back, to see by which route
  ' we reached the goal-node.
  If TotalCost(Goal) = Infinite Then
  ' It is not possible to reach the goal-node from
  ' the start-node...
    Dijkstra = "No route found"
    Exit Function
  End If
  Route$ = Trim$(Network(Goal).Name)
  CurrentNode% = Goal
  NextNode% = Infinite
  While CurrentNode% <> Start
    MsgBox (Str$(CurrentNode%))
    MinCost% = Infinite
    For x% = 1 To NrNodes
      For y% = 1 To MaxLinks
        If Network(x%).Link(y%) = CurrentNode% Then
          If TotalCost(x%) < MinCost% Then
            MsgBox (Str$(x%) & Str$(TotalCost(x%)))
            MinCost% = TotalCost(x%)
            NextNode% = x%
          End If
        End If
      Next y%
    Next x%
    Route$ = Trim$(Network(NextNode%).Name) & " - " & Route$
    CurrentNode% = NextNode%
  Wend
  Dijkstra = Route$
End Function

Function DirectPathCost (Start, Goal As Integer) As Integer
  For x% = 1 To MaxLinks
    If Network(Start).Link(x%) = Goal Then
      DirectPathCost = Network(Start).Cost(x%)
      Exit Function
    End If
  Next x%
  DirectPathCost = Infinite
End Function
