Imports System.ComponentModel.DataAnnotations
Imports System.Drawing
Imports System.IO
Public Class RecipeImage
    <Key, Schema.Column(order:=1), Schema.DatabaseGenerated(Schema.DatabaseGeneratedOption.Identity)> _
    Public Property RecipeImageID As Integer
    <MaxLength> _
    Public Property Photo As Byte()
    Public Property PhotoAdded As Date?

    <Key, Schema.Column(order:=2)> _
    Public Overridable Property RecipeID As Integer
    Public Overridable Property Recipe As Recipe
    Public Sub New()
        Me.PhotoAdded = Date.Now
        Me.Photo = New Byte(0) {}
    End Sub
    <Schema.NotMapped> _
    Public Property PhotoAsImage() As Image
        Get
            If Me.Photo Is Nothing Then
                Return Nothing
            End If

            If Me.Photo.Length > 0 Then
                Dim ms As New MemoryStream(Me.Photo)
                Return Image.FromStream(ms)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Image)
            Dim ms As New MemoryStream
            value.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Me.Photo = ms.ToArray
        End Set
    End Property

End Class
