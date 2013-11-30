Imports System.ComponentModel.DataAnnotations
Public Class Note
    <Key, Schema.Column(order:=1)> _
    Public Property ContributorID As Integer
    <Key, Schema.Column(order:=2)> _
    Public Property RecipeID As Integer
    Public Property Notes As String
    Public Property LastUpdate As Date?

    Public Property Contributor As Contributor
    Public Property Recipe As Recipe

    Public Sub New()
        Me.LastUpdate = DateTime.Now
    End Sub
End Class
