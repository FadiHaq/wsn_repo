Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.SqlClient
Public Class Form2
    Dim constring As String = "Data Source=.\SQLEXPRESS;Initial Catalog=TrafficDB;Integrated Security=SSPI"
    ' Dim constring As String = "Data Source=.\SQLEXPRESS;Initial Catalog=TrafficDB;User ID=sa;Password=104123"
    Dim cn As SqlConnection = New SqlConnection(constring)
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim dt As DataTable = New DataTable
        'Dim dr As DataRow
        'dt.Columns.Add("classification", GetType(String))
        'dt.Columns.Add("detectiontime", GetType(TimeSpan))

        'Dim adapter As SqlDataAdapter = New SqlDataAdapter
        'Try
        '    cn.Open()
        '    Dim sqlstr As String = "SELECT integer_detectionTime, Calssification FROM TrafficDB.dbo.Viw_TrafficParameters  WHERE (DetectionDate = " + getDetectionDate() + ") AND (CAST(DetectionTime AS TIME) BETWEEN " + getDetectionTime() + ")"
        '    Dim cmd As New SqlCommand(sqlstr, cn)
        '    adapter.SelectCommand = cmd
        '    adapter.Fill(dt)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    cn.Close()
        'End Try







        ' Make some data
        Dim dt As New DataTable
        Dim r As DataRow
        With dt
            .Columns.Add("Label", GetType(String))
            .Columns.Add("TS", GetType(TimeSpan))
            r = .NewRow : r(0) = "A1" : r(1) = TimeSpan.Parse("0.00:45:00") : .Rows.Add(r)
            r = .NewRow : r(0) = "A2" : r(1) = TimeSpan.Parse("1.01:00:00") : .Rows.Add(r)
            r = .NewRow : r(0) = "A3" : r(1) = TimeSpan.Parse("0.06:00:00") : .Rows.Add(r)
        End With

        ' Add a DateTime Column
        dt.Columns.Add("ChartTime", GetType(DateTime))


        ' Now for the real work!

        ' I use "Today" as the base date.  In a perfect world we could do:
        'For Each r In dt.Rows
        '   r("ChartTIME") = New DateTime(CType(r("TS"), TimeSpan).Ticks)
        'Next
        ' but the chart control uses OLE Automation dates and they use a 
        ' different time basis than .Net Dates.

        ' set a temp Today to prevent the unlikely case the the day changes while executing
        Dim myToday As DateTime = Today
        For Each r In dt.Rows
            ' Add the HH:mm:ss to the base date and save it
            r("ChartTIME") = myToday.Add(CType(r("TS"), TimeSpan))
        Next

        ' Setup the chart

        With Chart1
            .Dock = DockStyle.Fill
            .DataSource = dt
            .Legends.Clear()
            .ChartAreas.Clear()
            .ChartAreas.Add(New ChartArea("Fred"))
            With .ChartAreas("Fred")
                .AxisY.Minimum = myToday.ToOADate
                .AxisY.Maximum = Math.Ceiling(CDate(dt.Compute("Max([ChartTime])", "True")).ToOADate)

                .AxisY.LabelStyle.Format = "HH:mm:ss"

                'Play with this to get the effect you want
                .AxisY.LabelStyle.IntervalType = DateTimeIntervalType.Hours
                .AxisY.LabelStyle.Interval = 2 'hours

                .AxisX.LabelStyle.Format = "G"
                .AxisX.LabelStyle.Interval = 0
                .AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Auto
            End With
            .Series.Clear()
            .Series.Add(New Series("Wilma"))

            With .Series("Wilma")
                .ChartArea = "Fred"
                .ChartType = SeriesChartType.Column
                .XValueType = ChartValueType.String
                .XValueMember = "Label"

                .YValueType = ChartValueType.DateTime
                .YValueMembers = "ChartTime"

            End With

        End With
    End Sub
End Class