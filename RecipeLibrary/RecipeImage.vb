Imports System.ComponentModel.DataAnnotations
Public Class RecipeImage
    <Key, Schema.Column(order:=1), Schema.DatabaseGenerated(Schema.DatabaseGeneratedOption.Identity)> _
    Public Property RecipeImageID As Integer
    <MaxLength> _
    Public Property Photo As Byte()
    Public Property PhotoAdded As Date?

    <Key, Schema.Column(order:=2)> _
    Public Overridable Property RecipeID As Integer
    Public Overridable Property Recipe As Recipe
End Class
