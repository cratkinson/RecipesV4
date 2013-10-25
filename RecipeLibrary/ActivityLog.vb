Public Enum Activities
    Insert
    Update
    Delete
End Enum
Public Class ActivityLog
    Public Property ActivityLogID As Integer
    Public Property Activity As Activities
    Public Property ActivityDate As Nullable(Of DateTime)
    Public Property ContributorName As String
    Public Property RecipeName As String
End Class
