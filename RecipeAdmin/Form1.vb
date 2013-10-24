Imports RecipeLibrary
Public Class Form1
    Private theApp As App = New App
    Private Enum EditState
        Category
        Serving
        Unit
    End Enum
    Private currentState As EditState
    Private newRow As Boolean = False
    Private delRow As Boolean = False

    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        currentState = EditState.Category
        Dim bs As New BindingSource
        bs.DataSource = theApp.Category_Get_All
        gv.DataSource = bs
        gv.Columns(0).Visible = False

    End Sub

    Private Sub gv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles gv.RowsAdded
    End Sub

    Private Sub gv_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles gv.RowStateChanged
        Debug.WriteLine("gv_RowStateChanged")
    End Sub

    Private Sub gv_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles gv.RowValidated
        Debug.WriteLine("RowValidated")
    End Sub

    Private Sub gv_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles gv.RowValidating
        If gv.IsCurrentRowDirty Then
            Dim i As Object = gv.CurrentRow.DataBoundItem
            Select Case currentState
                Case EditState.Category
                    If newRow Then
                        theApp.Category_Insert(i)
                        newRow = False
                    Else
                        theApp.Category_Update(i)
                    End If
                Case EditState.Serving
                    If newRow Then
                        theApp.Serving_Insert(i)
                        newRow = False
                    Else
                        theApp.Serving_Update(i)
                    End If
                Case EditState.Unit
                    If newRow Then
                        theApp.Unit_Insert(i)
                        newRow = False
                    Else
                        theApp.Unit_Update(i)
                    End If
            End Select
            theApp.Save()
        End If
        Debug.WriteLine("Dirty:" + gv.IsCurrentRowDirty.ToString)
        Debug.WriteLine("RowValidating")
    End Sub

    Private Sub btnUnits_Click(sender As Object, e As EventArgs) Handles btnUnits.Click
        currentState = EditState.Unit
        Dim bs As New BindingSource
        bs.DataSource = theApp.Unit_Get_All
        gv.DataSource = bs
        gv.Columns(0).Visible = False

    End Sub

    Private Sub gv_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles gv.UserAddedRow
        newRow = True
    End Sub

    Private Sub gv_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles gv.UserDeletingRow
        Try
            Dim i As Object = e.Row.DataBoundItem
            Select Case currentState
                Case EditState.Category
                    theApp.Category_Delete(i)
                Case EditState.Serving
                    theApp.Serving_Delete(i)
                Case EditState.Unit
                    theApp.Unit_Delete(i)
            End Select
            theApp.Save()
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub btnServings_Click(sender As Object, e As EventArgs) Handles btnServings.Click
        currentState = EditState.Serving
        Dim bs As New BindingSource
        bs.DataSource = theApp.Serving_Get_All
        gv.DataSource = bs
        gv.Columns(0).Visible = False

    End Sub
End Class
