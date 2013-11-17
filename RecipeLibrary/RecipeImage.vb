Imports System.ComponentModel.DataAnnotations
Public Class RecipeImage
    <Key, Schema.Column(order:=1), Schema.DatabaseGenerated(Schema.DatabaseGeneratedOption.Identity)> _
    Public Property ImageID As Integer
    Public Property Image As Byte()

    <Key, Schema.Column(order:=2)> _
    Public Overridable Property RecipeID As Integer
    Public Overridable Property Recipe As Recipe
End Class
