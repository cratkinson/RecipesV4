Imports System.ComponentModel.DataAnnotations
Public Class Serving
    Public Property ServingID As Integer
    <StringLength(40)> _
    Public Property Description As String
    Public Property ScaleFactor As Decimal
End Class
