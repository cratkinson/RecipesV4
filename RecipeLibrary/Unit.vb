Imports System.ComponentModel.DataAnnotations
Public Class Unit
    Public Property UnitID As Integer
    <StringLength(40)> _
    Public Property Description As String
    <StringLength(40)> _
    Public Property ExpandedDescription As String

End Class
