Public Enum Activities
    Insert
    Update
    Delete
End Enum
Public Class ActivityLog
    Public Property ActivityLogID As Integer
    Public Property Activity As Activities
    Public Property ActivityDate As Nullable(Of DateTime)

    Public Property ContributorID As Integer
    Public Overridable Property Contributor As Contributor

    Public Property RecipeID As Integer
    Public Overridable Property Recipe As Recipe
End Class
