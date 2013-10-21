Imports System.ComponentModel.DataAnnotations
Public Class Contributor
    Public Property ContributorID As Integer
    <StringLength(40)> _
    Public Property Name As String
    <EmailAddress> _
    Public Property EmailAddress As String


End Class
