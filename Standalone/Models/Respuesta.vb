Public Class Respuesta
    Public Property Successfull As Integer
    Public Property Message As String
    Public Property Data As Object

End Class
Public Class RespuestaEmpr
    Public Property Successfull As Integer
    Public Property Message As String
    Public Property Data As Employer

End Class
Public Class RespuestaEmpe
    Public Property Successfull As Integer
    Public Property Message As String
    Public Property Data As Employee

End Class
Public Class RespuestaCnte
    Public Property Successfull As Integer
    Public Property Message As String
    Public Property Data As List(Of CNTE)

End Class
Public Class RespuestaRates
    Public Property Successfull As Integer
    Public Property Message As String
    Public Property Data As List(Of Rate)

End Class
