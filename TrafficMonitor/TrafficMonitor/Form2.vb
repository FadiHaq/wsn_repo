Imports System
Imports System.IO
Imports System.IO.Ports
Public Class Form2
    Dim bytes(13) As Byte
    Dim offset As Integer = 0
    Dim count As Integer = 14
    Dim resulttype As String
    Dim WithEvents xbee As New SerialPort

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        xbee.BaudRate = 9600
        xbee.PortName = "com4"
        xbee.Parity = Parity.Even
        xbee.StopBits = 1
        xbee.DataBits = 8
    End Sub


    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick

        Received.Clear()
        Try
            xbee.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim Data
        xbee.Read(bytes, offset, count)
        'Data = Data & " "

        'Received.AppendText(Data)
        For i As Integer = 0 To 13
            resulttype = invenum(i)
            Data = bytes(i)
            Received.AppendText(resulttype & ": |  " & Data & vbNewLine)
        Next

        Try
            xbee.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
        If timer1.Enabled = False Then
            timer1.Enabled = True
        Else
            timer1.Enabled = False
        End If
    End Sub

    Public Function invenum(ByVal i As Integer)
        Select Case (i)
            Case 0 : Return "Start delimiter"
            Case 1 : Return "Length byte 1"
            Case 2 : Return "length byte 2"
            Case 3 : Return "API identifier byte"
            Case 4 : Return "Source address byte 1"
            Case 5 : Return "Source address byte 2"
            Case 6 : Return "RSSI value byte"
            Case 7 : Return "Option byte"
            Case 8 : Return "Sample quantity byte"
            Case 9 : Return "Channel indicator 1"
            Case 10 : Return "Channel indicator 2"
            Case 11 : Return "Sample data 1"
            Case 12 : Return "Sample data 2"
            Case 13 : Return "Checksum"
        End Select
    End Function
End Class