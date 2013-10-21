Imports System.ComponentModel.DataAnnotations

Public Class Category
    Public Property CategoryID As Integer
    <StringLength(40)> _
    Public Property Description As String
End Class
