Dim dtTest As New DataTable

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    dtTest.Columns.Add("TimePoint", GetType(Integer))
    dtTest.Columns.Add("Speed", GetType(Integer))

    dtTest.Rows.Add(0, 0)
    dtTest.Rows.Add(1000, 50)
    dtTest.Rows.Add(2000, 50)
    dtTest.Rows.Add(3000, 0)

    With Chart1.ChartAreas(0)
      .AxisX.Minimum = 0
      .AxisX.Maximum = 3000
      .AxisY.Minimum = 0
      .AxisY.Maximum = 60
      .AxisY.Interval = 10
      .AxisX.Title = "Elapsed Time (ms)"
      .AxisY.Title = "Speed (km/hr)"
    End With

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    With Chart1.Series(0)
      .Points.DataBind(dtTest.DefaultView, "TimePoint", "Speed", Nothing)
      .ChartType = DataVisualization.Charting.SeriesChartType.Line
      .BorderWidth = 4
    End With
  End Sub