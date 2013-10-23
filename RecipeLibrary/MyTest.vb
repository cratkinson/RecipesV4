Imports System.ComponentModel.DataAnnotations
Public Class MyTest
    <Key, Schema.Column(Order:=1)> _
    Public Property Col1ID As Integer
    <Key, Schema.Column(Order:=2)> _
    Public Property Col2ID As Integer
End Class
