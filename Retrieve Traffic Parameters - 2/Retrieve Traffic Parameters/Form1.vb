Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Form1
    'Dim constring As String = "Data Source=.\SQLEXPRESS;Initial Catalog=TrafficDB;Integrated Security=SSPI"
    Dim constring As String = "Data Source=.\SQLEXPRESS;Initial Catalog=TrafficDB;User ID=sa;Password=104123"
    Dim cn As SqlConnection = New SqlConnection(constring)
    Private Sub button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button13.Click
        Application.Exit()
    End Sub
    Private Function CalculateNumberofVehicles()
        Dim v_num As Integer = 0
        '     Dim sqlstr As String = "SELECT Count(SenderId) AS Counter FROM TrafficDB.dbo.tbl_Traffic WHERE (DetectionDate = " + getDetectionDate() + ") AND (CAST(DetectionTime AS TIME) BETWEEN " + getDetectionTime() + ") AND (" + getCalssificationstr() + ") AND (" + getNodeId() + ")"
        Dim sqlstr As String = "SELECT Count(SenderId) AS Counter FROM TrafficDB.dbo.tbl_Traffic WHERE (DetectionDate = " + getDetectionDate() + ") AND (CAST(DetectionTime AS TIME) BETWEEN " + getDetectionTime() + ") AND ( SenderId='" + cmbNodeId.SelectedItem.ToString + "')"
        Try
            cn.Open()
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim myreader As SqlDataReader = cmd.ExecuteReader()
            While myreader.Read()
                v_num = myreader("Counter").ToString()
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
        Return v_num
    End Function
    Private Function getDetectionDate()
        Dim str As String = Nothing
        Dim dt As Date = pikdate.Value
        str = "CONVERT(DATETIME, '" + getsqldate(dt) + "', 102)"
        Return str
    End Function
    Private Function getDetectionTime()
        Return "'" + pikfromtime.Text.ToString() + "' and '" + piktotime.Text.ToString() + "'"
    End Function
    Private Function getsqldate(ByVal dd As Date)
        Dim day As String = dd.Day
        Dim month As String = dd.Month
        Dim year As String = dd.Year
        Dim d As String = year + "-" + month + "-" + day
        Return d
    End Function
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitializeControls()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Chart1.Series(0).Points.Count = 0 Then
            lblV_passed.Text = CalculateNumberofVehicles()
            Label27.Text = getclassificationcounter("Large")
            Label25.Text = getclassificationcounter("Medium")
            Label23.Text = getclassificationcounter("Small")

            Label17.Text = getspeedcounter("20", "39")
            Label15.Text = getspeedcounter("40", "59")
            Label9.Text = getspeedcounter("60", "79")
            Label19.Text = getspeedcounter("80", "99")
            Label21.Text = getspeedcounter("100", "999")
            drawpiechart()

            DrawspeedChart()
            DrawCalssificationChart()
            GroupBox9.Visible = True
            GroupBox10.Visible = True
        End If
    End Sub
    Private Sub drawpiechart()
        Chart1.Series("SPEED").Points.AddXY(Label16.Text, Label17.Text)
        Chart1.Series("SPEED").Points.AddXY(Label14.Text, Label15.Text)
        Chart1.Series("SPEED").Points.AddXY(Label7.Text, Label9.Text)
        Chart1.Series("SPEED").Points.AddXY(Label18.Text, Label19.Text)

        Chart2.Series("Classification").Points.AddXY(Label26.Text, Label27.Text)
        Chart2.Series("Classification").Points.AddXY(Label24.Text, Label25.Text)
        Chart2.Series("Classification").Points.AddXY(Label22.Text, Label23.Text)

    End Sub
    Private Function getclassificationcounter(ByVal clss As String)
        Dim rvalue As Integer = 0
        Dim sqlstr As String = "SELECT Count(SenderId) AS Counter FROM TrafficDB.dbo.tbl_Traffic WHERE (DetectionDate = " + getDetectionDate() + ") AND (CAST(DetectionTime AS TIME) BETWEEN " + getDetectionTime() + ") AND (Calssification LIKE  N'%" + clss + "%') AND ( SenderId='" + cmbNodeId.SelectedItem.ToString + "')"
        Try
            cn.Open()
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim myreader As SqlDataReader = cmd.ExecuteReader()
            While myreader.Read()
                rvalue = myreader("Counter").ToString()
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
        Return rvalue
    End Function
    Private Function getspeedcounter(ByVal minspeed As String, ByVal maxspeed As String)
        Dim rvalue As Integer = 0
        Dim sqlstr As String = "SELECT Count(SenderId) AS Counter FROM TrafficDB.dbo.tbl_Traffic WHERE (DetectionDate = " + getDetectionDate() + ") AND (CAST(DetectionTime AS TIME) BETWEEN " + getDetectionTime() + ") AND (Speed BETWEEN " + minspeed + " AND " + maxspeed + ") AND ( SenderId='" + cmbNodeId.SelectedItem.ToString + "')"
        Try
            cn.Open()
            Dim cmd As New SqlCommand(sqlstr, cn)
            Dim myreader As SqlDataReader = cmd.ExecuteReader()
            While myreader.Read()
                rvalue = myreader("Counter").ToString()
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
        Return rvalue
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        InitializeControls()
    End Sub

    Private Sub DrawspeedChart()
   
        Dim Cmd As New SqlCommand
        Cmd.Connection = cn

        Dim Fields As String = "SELECT integer_detectionTime, Speed FROM TrafficDB.dbo.Viw_TrafficParameters WHERE (DetectionDate = " + getDetectionDate() + ") AND (CAST(DetectionTime AS TIME) BETWEEN " + getDetectionTime() + ")  AND ( SenderId='" + cmbNodeId.SelectedItem.ToString + "') ORDER BY  integer_detectionTime "

        Dim Data As New SqlDataAdapter(Fields, cn)

        Dim ds As New DataSet

        Dim oCmd As New SqlCommand(Fields, cn)


        cn.Open()
        Data.Fill(ds, "Viw_TrafficParameters")
        cn.Close()

        Chart4.Series(0).XValueMember = "integer_detectionTime"
        Chart4.Series(0).YValueMembers = "Speed"
        Chart4.DataSource = ds.Tables("Viw_TrafficParameters")
        Chart4.Size = New System.Drawing.Size(725, 350)

    End Sub

    Private Sub DrawCalssificationChart()

        Dim Cmd As New SqlCommand
        Cmd.Connection = cn

        Dim Fields As String = "SELECT integer_detectionTime, integerclassification FROM TrafficDB.dbo.Viw_TrafficParameters WHERE (DetectionDate = " + getDetectionDate() + ") AND (CAST(DetectionTime AS TIME) BETWEEN " + getDetectionTime() + ")  AND ( SenderId='" + cmbNodeId.SelectedItem.ToString + "') ORDER BY  integer_detectionTime"

        Dim Data As New SqlDataAdapter(Fields, cn)

        Dim ds As New DataSet

        Dim oCmd As New SqlCommand(Fields, cn)


        cn.Open()
        Data.Fill(ds, "Viw_TrafficParameters")
        cn.Close()

        Chart5.Series(0).XValueMember = "integer_detectionTime"
        Chart5.Series(0).YValueMembers = "integerclassification"
        Chart5.DataSource = ds.Tables("Viw_TrafficParameters")
        Chart5.Size = New System.Drawing.Size(725, 350)

    End Sub
    Private Sub InitializeControls()
        pikdate.Value = Now.Date
        pikfromtime.Text = "00:00:00"
        piktotime.Text = "23:59:59"
        lblV_passed.Text = Nothing
        Chart1.Series(0).Points.Clear()
        Chart2.Series(0).Points.Clear()
        Chart4.Series(0).Points.Clear()
        Chart5.Series(0).Points.Clear()

        Label27.Text = Nothing
        Label25.Text = Nothing
        Label23.Text = Nothing

        Label17.Text = Nothing
        Label15.Text = Nothing
        Label9.Text = Nothing
        Label19.Text = Nothing
        Label21.Text = Nothing
        cmbNodeId.SelectedItem = "01"

    End Sub


End Class
