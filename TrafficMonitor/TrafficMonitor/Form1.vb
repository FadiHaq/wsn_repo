Imports System.IO.Ports
Imports System.Text
Imports System.Data.SqlClient
Public Class frmTrafficMonitor
    Dim receivedData As String = ""
    Private Function FindSerialPorts() As List(Of String)
        Dim lstport As New List(Of String)
        For Each port As String In SerialPort.GetPortNames
            lstport.Add(port)
        Next
        Return lstport
    End Function
    Public Function OpenPort(ByVal sprt As SerialPort, ByVal Prtname As String, ByVal baudrate As Integer) As String
        Dim statusmsg As String = Nothing
        Try
            'first check if the port is already open
            'if its open then close it
            If sprt.IsOpen = True Then
                sprt.Close()
            End If
            'set the properties of our SerialPort Object
            sprt.PortName = Prtname
            sprt.BaudRate = baudrate
            'BaudRate
            sprt.DataBits = 8
            'DataBits
            sprt.Parity = Parity.None
            ' Parity
            sprt.StopBits = StopBits.One
            'StopBits
            sprt.Handshake = Handshake.None
            'Handshake
            sprt.Encoding = System.Text.Encoding.Default
            'Encoding
            sprt.ReadTimeout = 10000
            'Timeout
            'now open the port
            sprt.Open()
            'display message
            statusmsg = "Port opened at " + DateTime.Now + "" + Environment.NewLine + ""
        Catch ex As Exception
            statusmsg = ex.Message.ToString
        End Try
        Return statusmsg
    End Function
    Public Function ClosePort(ByVal sprt As SerialPort)
        Dim statusmsg As String = Nothing
        If sprt.IsOpen Then
            statusmsg = "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""
            sprt.Close()
        End If
        Return statusmsg
    End Function
    Private Function extractdata(ByVal frm As String, ByVal dttype As String)
        Dim rtnvalue As String = Nothing
        Dim tem() As String = frm.Split(" "c)
        Dim frame As New List(Of String)
        For Each s As String In tem
            If s <> "" Then
                frame.Add(s)
            End If
        Next
        Try
            Select Case dttype
                Case "Start delimiter"
                    rtnvalue = frame.Item(0).ToString
                Case "Length"
                    rtnvalue = frame.Item(1).ToString
                Case "Frame type"
                    rtnvalue = frame.Item(2).ToString
                Case "sensorid"
                    rtnvalue = frame.Item(3).ToString
                Case "RSSI"
                    rtnvalue = frame.Item(4)
                Case "Options"
                    rtnvalue = frame.Item(5)
                Case "RF Data"
                    For i = 6 To frame.Count - 2
                        rtnvalue = rtnvalue + " " + frame.Item(i)
                    Next
                Case "v_class"
                    rtnvalue = Convert.ToInt64(frame.Item(6), 16).ToString

                Case "deteciondate"
                    rtnvalue = ZeroPadding(Convert.ToInt64(frame.Item(7), 16).ToString) + "/" + ZeroPadding(Convert.ToInt64(frame.Item(8), 16).ToString) + "/" + ZeroPadding(Convert.ToInt64(frame.Item(9) + frame.Item(10), 16).ToString)

                Case "detectiontime"
                    rtnvalue = ZeroPadding(Convert.ToInt64(frame.Item(11), 16).ToString) + ":" + ZeroPadding(Convert.ToInt64(frame.Item(12), 16).ToString) + ":" + ZeroPadding(Convert.ToInt64(frame.Item(13), 16).ToString)
                Case "v_speed"
                    rtnvalue = Convert.ToInt64(frame.Item(14), 16).ToString
                Case "Checksum"
                    rtnvalue = frame.Item(frame.Count - 1)
            End Select
        Catch ex As Exception
        End Try
        Return rtnvalue
    End Function
    Private Function ZeroPadding(ByVal strValue As String) As String
        If Integer.Parse(strValue) <= 9 Then
            Return "0" + strValue
        Else
            Return strValue
        End If
    End Function
    Private Sub InsertData(ByVal recdata As String)
        Try
            Dim counter As Integer = 1
            Dim sensorid As String = extractdata(recdata, "sensorid")
            Dim v_class As String = getVehicleClassification(extractdata(recdata, "v_class"))
            Dim deteciondate As String = extractdata(recdata, "deteciondate")
            Dim detectiontime As String = extractdata(recdata, "detectiontime")
            Dim v_speed As String = extractdata(recdata, "v_speed")

            If DataGridView1.RowCount > 0 Then
                Dim rowcount As Integer = DataGridView1.RowCount - 1
                counter = DataGridView1.Rows(rowcount).Cells(0).Value
                counter = counter + 1
            End If
            DataGridView1.Rows.Add(New String() {Trim(counter.ToString), Trim(sensorid.ToString), Trim(v_class.ToString), Trim(deteciondate.ToString), Trim(detectiontime.ToString), Trim(v_speed.ToString)})
            Dim DetectionDatestr As Date = Date.Parse(deteciondate.ToString)
            Dim sqlDetectionDate As String = DetectionDatestr.ToString("yyyy-MM-dd")
            Dim DetectionTimestr As Date = DateTime.Parse(detectiontime.ToString)
            Dim sqlDetectionTime As String = DetectionTimestr.ToString("h:mm:ss tt")
            '  Dim constring As String = "Data Source=.\SQLEXPRESS;Initial Catalog=TrafficDB;Integrated Security=SSPI"
            Dim constring As String = "Data Source=.\SQLEXPRESS;Initial Catalog=TrafficDB;User ID=sa;Password=104123"
            Dim cn As SqlConnection = New SqlConnection(constring)
            cn.Open()
            Dim strsql As String = "INSERT INTO TrafficDB.dbo.tbl_Traffic (SenderId, Calssification, DetectionDate, DetectionTime, Speed ) VALUES   (N'" + sensorid + "', N'" + v_class + "', CONVERT(DATETIME, '" + sqlDetectionDate + "', 101), CONVERT(DATETIME, '" + sqlDetectionTime + "', 108), " + v_speed + ")"
            Dim cmd As SqlCommand = New SqlCommand(strsql, cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function ReceiveSerialData() As String
        Dim bytes As Integer = TrafficSerialPort.BytesToRead
        'create a byte array to hold the awaiting data
        Dim comBuffer As Byte() = New Byte(bytes - 1) {}
        'read the data and store it
        TrafficSerialPort.Read(comBuffer, 0, bytes)
        'return the data to 
        Dim Incoming As String = Disassembleframe(comBuffer)
        Try
            If Incoming Is Nothing Then
                Return "nothing"
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "Error: Serial Port read timed out."
        End Try

    End Function
    Private Function Disassembleframe(ByVal comByte As Byte()) As String
        'create a new StringBuilder object
        Dim builder As New StringBuilder(comByte.Length * 3)
        Dim dbyate() As String = Nothing
        Dim i As Integer = 0
        'loop through each byte in the array
        For Each data As Byte In comByte
            builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
            'convert the byte to a string and add to the stringbuilder
        Next
        'return the converted value
        Return builder.ToString().ToUpper()
    End Function

    Private Function getVehicleClassification(ByVal vsize As String)
        Dim resultclass As String = Nothing
        Select Case vsize
            Case "80"
                resultclass = "Small"
            Case "100"
                resultclass = "Medium"
            Case "200"
                resultclass = "Large"
        End Select
        Return resultclass
    End Function
    Private Sub frmTrafficMonitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RcvdTimer.Enabled = False
        '    Chart1.Series("SPEED").IsValueShownAsLabel = False
        ' Chart1.Series("Classification").IsValueShownAsLabel = False
        ' Chart1.ChartAreas("ChartArea1").AxisX.Enabled = DataVisualization.Charting.AxisEnabled.False
    End Sub
    Private Sub btnFindPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPort.Click
        Dim ports As List(Of String) = FindSerialPorts()
        btnFindPort.Cursor = Cursors.WaitCursor
        Cmbports.Items.Clear()
        For Each prt As String In ports
            Cmbports.Items.Add(prt)
        Next
        If Cmbports.Items.Count > 0 Then
            Cmbports.SelectedIndex = 0
            CmbBrate.SelectedItem = "9600"
            btnFindPort.Cursor = Cursors.Hand
        Else
            MsgBox("COM Port not detected")
        End If
    End Sub

    Private Sub btnconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconnect.Click
        Dim message As String = Nothing
        If CmbBrate.Items.Count > 0 AndAlso Cmbports.Items.Count > 0 Then
            Try
                btnconnect.Visible = False
                btndisconnect.Visible = True
                ClosePort(TrafficSerialPort)
                message = OpenPort(TrafficSerialPort, Cmbports.SelectedItem, Val(CmbBrate.SelectedItem))
                lstRecievedFrame.Items.Add(message)
                CmbBrate.Enabled = False
                Cmbports.Enabled = False
                RcvdTimer.Enabled = True
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btndisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndisconnect.Click
        Try
            Dim message As String = ClosePort(TrafficSerialPort)
            lstRecievedFrame.Items.Add(message)
            btnconnect.Visible = True
            btndisconnect.Visible = False
            CmbBrate.Enabled = True
            Cmbports.Enabled = True
            Cmbports.SelectedItem = Nothing
            Cmbports.Items.Clear()
            RcvdTimer.Enabled = False
        Catch ex As Exception
        End Try
    End Sub


    Private Sub RcvdTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RcvdTimer.Tick
        receivedData = ReceiveSerialData()
        If Trim(receivedData.StartsWith("7E")) AndAlso Trim(receivedData).Length = 47 Then
            lstRecievedFrame.Items.Add(receivedData)
            InsertData(receivedData)

            Dim speed = extractdata(receivedData, "v_speed")
            Dim classification = extractdata(receivedData, "v_class")
            Dim dttime = extractdata(receivedData, "detectiontime")
            Chart1.Series("SPEED").Points.AddXY(dttime, speed)
            Chart1.Series("Classification").Points.AddXY(dttime, classification)

            If Chart1.Series(0).Points.Count = 9 Then
                Chart1.Series(0).Points.RemoveAt(0)
            End If
            If Chart1.Series(1).Points.Count = 9 Then
                Chart1.Series(1).Points.RemoveAt(0)
            End If
            Chart1.ChartAreas(0).AxisY.Maximum = 250
        End If
    End Sub

    Private Sub lstRecievedFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRecievedFrame.SelectedIndexChanged

        Try
            Dim str As String = Trim(lstRecievedFrame.SelectedItem.ToString)
            If str.StartsWith("7E") Then
                txtstartdl.Text = extractdata(str, "Start delimiter")
                txtlength.Text = extractdata(str, "Length")
                txtfrmtype.Text = extractdata(str, "Frame type")
                txtsourceadd.Text = extractdata(str, "sensorid")
                txtrssi.Text = extractdata(str, "RSSI")
                txtoption.Text = extractdata(str, "Options")
                txtRFdata.Text = extractdata(str, "RF Data")
                txtChecksum.Text = extractdata(str, "Checksum")
                txtvehicleclass.Text = getVehicleClassification(extractdata(str, "v_class"))
                txtdetcdate.Text = extractdata(str, "deteciondate")
                txttime.Text = extractdata(str, "detectiontime")
                txtspeed.Text = extractdata(str, "v_speed")
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
