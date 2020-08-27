<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrafficMonitor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrafficMonitor))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtspeed = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txttime = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtvehicleclass = New System.Windows.Forms.TextBox()
        Me.txtdetcdate = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChecksum = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRFdata = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtoption = New System.Windows.Forms.TextBox()
        Me.txtstartdl = New System.Windows.Forms.TextBox()
        Me.txtsourceadd = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtrssi = New System.Windows.Forms.TextBox()
        Me.txtlength = New System.Windows.Forms.TextBox()
        Me.txtfrmtype = New System.Windows.Forms.TextBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Counter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SensorId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V_Class = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetectionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetectionTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Speed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstRecievedFrame = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnconnect = New System.Windows.Forms.PictureBox()
        Me.btnFindPort = New System.Windows.Forms.PictureBox()
        Me.Cmbports = New System.Windows.Forms.ComboBox()
        Me.CmbBrate = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btndisconnect = New System.Windows.Forms.PictureBox()
        Me.TrafficSerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.RcvdTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.btnconnect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFindPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btndisconnect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1197, 714)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtspeed)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txttime)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.txtvehicleclass)
        Me.GroupBox4.Controls.Add(Me.txtdetcdate)
        Me.GroupBox4.Location = New System.Drawing.Point(750, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(130, 214)
        Me.GroupBox4.TabIndex = 140
        Me.GroupBox4.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 172)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 138
        Me.Label14.Text = "Vehicle Speed"
        '
        'txtspeed
        '
        Me.txtspeed.Location = New System.Drawing.Point(7, 188)
        Me.txtspeed.Name = "txtspeed"
        Me.txtspeed.Size = New System.Drawing.Size(108, 20)
        Me.txtspeed.TabIndex = 139
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 133
        Me.Label11.Text = "DetectionTime"
        '
        'txttime
        '
        Me.txttime.Location = New System.Drawing.Point(7, 137)
        Me.txttime.Name = "txttime"
        Me.txttime.Size = New System.Drawing.Size(108, 20)
        Me.txttime.TabIndex = 137
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 13)
        Me.Label12.TabIndex = 135
        Me.Label12.Text = "Detection Date"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 133
        Me.Label13.Text = "Vehicle Classification"
        '
        'txtvehicleclass
        '
        Me.txtvehicleclass.Location = New System.Drawing.Point(7, 38)
        Me.txtvehicleclass.Name = "txtvehicleclass"
        Me.txtvehicleclass.Size = New System.Drawing.Size(108, 20)
        Me.txtvehicleclass.TabIndex = 134
        '
        'txtdetcdate
        '
        Me.txtdetcdate.Location = New System.Drawing.Point(7, 88)
        Me.txtdetcdate.Name = "txtdetcdate"
        Me.txtdetcdate.Size = New System.Drawing.Size(108, 20)
        Me.txtdetcdate.TabIndex = 134
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtChecksum)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtRFdata)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtoption)
        Me.GroupBox3.Controls.Add(Me.txtstartdl)
        Me.GroupBox3.Controls.Add(Me.txtsourceadd)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtrssi)
        Me.GroupBox3.Controls.Add(Me.txtlength)
        Me.GroupBox3.Controls.Add(Me.txtfrmtype)
        Me.GroupBox3.Location = New System.Drawing.Point(517, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(227, 214)
        Me.GroupBox3.TabIndex = 139
        Me.GroupBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 133
        Me.Label6.Text = "Source address"
        '
        'txtChecksum
        '
        Me.txtChecksum.Location = New System.Drawing.Point(7, 104)
        Me.txtChecksum.Name = "txtChecksum"
        Me.txtChecksum.Size = New System.Drawing.Size(67, 20)
        Me.txtChecksum.TabIndex = 137
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 135
        Me.Label9.Text = "Checksum"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Start delimiter"
        '
        'txtRFdata
        '
        Me.txtRFdata.Location = New System.Drawing.Point(6, 144)
        Me.txtRFdata.Multiline = True
        Me.txtRFdata.Name = "txtRFdata"
        Me.txtRFdata.Size = New System.Drawing.Size(214, 64)
        Me.txtRFdata.TabIndex = 138
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(83, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Length"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(156, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Frame type"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 136
        Me.Label10.Text = "RF Data"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(84, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "RSSI"
        '
        'txtoption
        '
        Me.txtoption.Location = New System.Drawing.Point(153, 65)
        Me.txtoption.Name = "txtoption"
        Me.txtoption.Size = New System.Drawing.Size(67, 20)
        Me.txtoption.TabIndex = 134
        '
        'txtstartdl
        '
        Me.txtstartdl.Location = New System.Drawing.Point(7, 29)
        Me.txtstartdl.Name = "txtstartdl"
        Me.txtstartdl.Size = New System.Drawing.Size(67, 20)
        Me.txtstartdl.TabIndex = 134
        '
        'txtsourceadd
        '
        Me.txtsourceadd.Location = New System.Drawing.Point(7, 65)
        Me.txtsourceadd.Name = "txtsourceadd"
        Me.txtsourceadd.Size = New System.Drawing.Size(67, 20)
        Me.txtsourceadd.TabIndex = 134
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(156, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Options"
        '
        'txtrssi
        '
        Me.txtrssi.Location = New System.Drawing.Point(80, 65)
        Me.txtrssi.Name = "txtrssi"
        Me.txtrssi.Size = New System.Drawing.Size(67, 20)
        Me.txtrssi.TabIndex = 134
        '
        'txtlength
        '
        Me.txtlength.Location = New System.Drawing.Point(80, 29)
        Me.txtlength.Name = "txtlength"
        Me.txtlength.Size = New System.Drawing.Size(67, 20)
        Me.txtlength.TabIndex = 134
        '
        'txtfrmtype
        '
        Me.txtfrmtype.Location = New System.Drawing.Point(153, 29)
        Me.txtfrmtype.Name = "txtfrmtype"
        Me.txtfrmtype.Size = New System.Drawing.Size(67, 20)
        Me.txtfrmtype.TabIndex = 134
        '
        'Chart1
        '
        ChartArea1.AxisY.Interval = 40.0R
        ChartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(517, 235)
        Me.Chart1.Name = "Chart1"
        Series1.BorderWidth = 2
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.Red
        Series1.Legend = "Legend1"
        Series1.Name = "SPEED"
        Series2.BorderWidth = 2
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Classification"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(691, 322)
        Me.Chart1.TabIndex = 132
        Me.Chart1.Text = "Chart1"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.DataGridView1)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 235)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(499, 466)
        Me.GroupBox7.TabIndex = 131
        Me.GroupBox7.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Counter, Me.SensorId, Me.V_Class, Me.DetectionDate, Me.DetectionTime, Me.Speed})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(493, 447)
        Me.DataGridView1.TabIndex = 129
        '
        'Counter
        '
        Me.Counter.HeaderText = "Counter"
        Me.Counter.Name = "Counter"
        Me.Counter.ReadOnly = True
        Me.Counter.Width = 50
        '
        'SensorId
        '
        Me.SensorId.HeaderText = "SensorID"
        Me.SensorId.Name = "SensorId"
        Me.SensorId.ReadOnly = True
        Me.SensorId.Width = 60
        '
        'V_Class
        '
        Me.V_Class.HeaderText = "V_Class"
        Me.V_Class.Name = "V_Class"
        Me.V_Class.ReadOnly = True
        '
        'DetectionDate
        '
        Me.DetectionDate.HeaderText = "DetectionDate"
        Me.DetectionDate.Name = "DetectionDate"
        Me.DetectionDate.ReadOnly = True
        Me.DetectionDate.Width = 85
        '
        'DetectionTime
        '
        Me.DetectionTime.HeaderText = "DetectionTime"
        Me.DetectionTime.Name = "DetectionTime"
        Me.DetectionTime.ReadOnly = True
        Me.DetectionTime.Width = 85
        '
        'Speed
        '
        Me.Speed.HeaderText = "Speed"
        Me.Speed.Name = "Speed"
        Me.Speed.ReadOnly = True
        Me.Speed.Width = 65
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstRecievedFrame)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 152)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'lstRecievedFrame
        '
        Me.lstRecievedFrame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstRecievedFrame.ForeColor = System.Drawing.Color.Blue
        Me.lstRecievedFrame.FormattingEnabled = True
        Me.lstRecievedFrame.Location = New System.Drawing.Point(3, 16)
        Me.lstRecievedFrame.Name = "lstRecievedFrame"
        Me.lstRecievedFrame.Size = New System.Drawing.Size(493, 133)
        Me.lstRecievedFrame.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnconnect)
        Me.GroupBox2.Controls.Add(Me.btnFindPort)
        Me.GroupBox2.Controls.Add(Me.Cmbports)
        Me.GroupBox2.Controls.Add(Me.CmbBrate)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btndisconnect)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(499, 66)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'btnconnect
        '
        Me.btnconnect.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnconnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnconnect.Image = CType(resources.GetObject("btnconnect.Image"), System.Drawing.Image)
        Me.btnconnect.Location = New System.Drawing.Point(70, 18)
        Me.btnconnect.Name = "btnconnect"
        Me.btnconnect.Size = New System.Drawing.Size(60, 40)
        Me.btnconnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnconnect.TabIndex = 1
        Me.btnconnect.TabStop = False
        '
        'btnFindPort
        '
        Me.btnFindPort.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnFindPort.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFindPort.Image = CType(resources.GetObject("btnFindPort.Image"), System.Drawing.Image)
        Me.btnFindPort.Location = New System.Drawing.Point(9, 18)
        Me.btnFindPort.Name = "btnFindPort"
        Me.btnFindPort.Size = New System.Drawing.Size(60, 40)
        Me.btnFindPort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnFindPort.TabIndex = 7
        Me.btnFindPort.TabStop = False
        '
        'Cmbports
        '
        Me.Cmbports.FormattingEnabled = True
        Me.Cmbports.Location = New System.Drawing.Point(136, 29)
        Me.Cmbports.Name = "Cmbports"
        Me.Cmbports.Size = New System.Drawing.Size(121, 21)
        Me.Cmbports.TabIndex = 4
        '
        'CmbBrate
        '
        Me.CmbBrate.FormattingEnabled = True
        Me.CmbBrate.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200"})
        Me.CmbBrate.Location = New System.Drawing.Point(273, 29)
        Me.CmbBrate.Name = "CmbBrate"
        Me.CmbBrate.Size = New System.Drawing.Size(121, 21)
        Me.CmbBrate.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(273, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Baud Rate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(136, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "COM Port"
        '
        'btndisconnect
        '
        Me.btndisconnect.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btndisconnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btndisconnect.Image = CType(resources.GetObject("btndisconnect.Image"), System.Drawing.Image)
        Me.btndisconnect.Location = New System.Drawing.Point(70, 18)
        Me.btndisconnect.Name = "btndisconnect"
        Me.btndisconnect.Size = New System.Drawing.Size(60, 40)
        Me.btndisconnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btndisconnect.TabIndex = 0
        Me.btndisconnect.TabStop = False
        '
        'TrafficSerialPort
        '
        Me.TrafficSerialPort.DiscardNull = True
        Me.TrafficSerialPort.DtrEnable = True
        '
        'RcvdTimer
        '
        Me.RcvdTimer.Interval = 500
        '
        'frmTrafficMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1197, 714)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmTrafficMonitor"
        Me.Text = "TarfficMonitor"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.btnconnect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFindPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btndisconnect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btndisconnect As System.Windows.Forms.PictureBox
    Friend WithEvents btnconnect As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmbports As System.Windows.Forms.ComboBox
    Friend WithEvents CmbBrate As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindPort As System.Windows.Forms.PictureBox
    Friend WithEvents TrafficSerialPort As System.IO.Ports.SerialPort
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents RcvdTimer As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstRecievedFrame As System.Windows.Forms.ListBox
    Friend WithEvents txtChecksum As System.Windows.Forms.TextBox
    Friend WithEvents txtRFdata As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtoption As System.Windows.Forms.TextBox
    Friend WithEvents txtsourceadd As System.Windows.Forms.TextBox
    Friend WithEvents txtrssi As System.Windows.Forms.TextBox
    Friend WithEvents txtfrmtype As System.Windows.Forms.TextBox
    Friend WithEvents txtlength As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtstartdl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtspeed As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txttime As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtvehicleclass As System.Windows.Forms.TextBox
    Friend WithEvents txtdetcdate As System.Windows.Forms.TextBox
    Friend WithEvents Counter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SensorId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V_Class As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetectionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetectionTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Speed As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
