Imports System.ComponentModel.DataAnnotations
Public Class Rating
    Private _RatingScore As Integer

    <Key, Schema.Column(order:=1)> _
    Public Property RecipeID As Integer
    <Key, Schema.Column(Order:=2)> _
    Public Property ContributorID As Integer
    Public Property RatingScore() As Integer
        Get
            Return _RatingScore
        End Get
        Set(ByVal value As Integer)
            If value >= 1 And value <= 5 Then
                _RatingScore = value
            Else
                Throw New Exception("Rating must be between 1 and 5.")
            End If
        End Set
    End Property


    Public Overridable Property Recipe As Recipe
    Public Overridable Property Contributor As Contributor
End Class
