Public Class Record
    Dim _detectionTime As Integer
    Dim _classification As String
    Public Sub New(ByVal DetectionTime As Integer, ByVal Classification As String)
        Me._detectionTime = DetectionTime
        Me._classification = Classification
    End Sub

    Public Property DetectionTime() As Integer
        Get
            Return _detectionTime
        End Get
        Set(ByVal Value As Integer)
            _detectionTime = Value
        End Set
    End Property

    Public Property Classification() As String
        Get
            Return _classification
        End Get
        Set(ByVal Value As String)
            _classification = Value
        End Set
    End Property

End Class