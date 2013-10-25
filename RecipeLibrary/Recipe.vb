Imports System.ComponentModel.DataAnnotations
Imports System.Collections.Generic
Public Class Recipe
    Public Property RecipeID As Integer
    <StringLength(50)> _
    Public Property Title As String
    Public Property Instructions As String
    Public Property PrepareTime As Integer
    Public Property CookTime As Integer
    Public Property SourceURL As String

    Public Property FirstAdded As Nullable(Of DateTime)
    Public Property LastUpdated As Nullable(Of DateTime)

    Public Property CategoryID As Integer
    Public Overridable Property Category As Category

    Public Property ServingID As Integer
    Public Overridable Property Serving As Serving

    Public Property ContributorID As Integer
    Public Overridable Property Contributor As Contributor

    Public Overridable Property Ingredients As ICollection(Of IngredientLine)
    <Schema.NotMapped> _
    Public ReadOnly Property IngredientsBlock As String
        Get
            If Me.Ingredients.Count > 0 Then
                Dim theString As String = String.Empty
                For Each i In Me.Ingredients
                    theString += i.ToString + vbCrLf
                Next
                Return theString.Substring(0, theString.Length - 2)
            Else
                Return String.Empty
            End If
        End Get
    End Property
    Public Sub New()
        Me.LastUpdated = Now
        Me.Ingredients = New HashSet(Of IngredientLine)
    End Sub
    Public Sub AddIngredientsV2(aBlock As String)
        Dim p As IngredientParser = New IngredientParser
        Dim theList As List(Of IngredientLine) = p.ParseBlock(aBlock)
        If Me.Ingredients.Count > 0 Then
        End If
    End Sub
    Public Sub AddIngredients(aBlock As String)
        Dim p As IngredientParser = New IngredientParser
        Dim theList As List(Of IngredientLine) = p.ParseBlock(aBlock)
        If Me.Ingredients.Count > 0 Then
            If theList.Count > Me.Ingredients.Count Then
                Dim theCurrentCount As Integer = Me.Ingredients.Count
                Dim iCnt As Integer = 0
                For Each i In theList
                    If iCnt < theCurrentCount Then
                        With Me.Ingredients(iCnt)
                            .Amount = i.Amount
                            .Ingredient = i.Ingredient
                            .Instruction = i.Instruction
                            .Unit = i.Unit
                        End With
                    Else
                        Me.Ingredients.Add(New IngredientLine With _
                                           {.Amount = i.Amount, _
                                            .Ingredient = i.Ingredient, _
                                            .Instruction = i.Instruction, _
                                            .Unit = i.Unit})
                    End If
                    iCnt += 1
                Next
            ElseIf theList.Count < Me.Ingredients.Count Then

                If theList.Count = 0 Then
                    For Each i In Me.Ingredients.ToList
                        Me.Ingredients.Remove(i)
                    Next
                Else
                    Dim iCnt As Integer = 0
                    Dim CntToRemove As Integer = Me.Ingredients.Count - theList.Count
                    For Each i In theList
                        With Me.Ingredients(iCnt)
                            .Amount = i.Amount
                            .Ingredient = i.Ingredient
                            .Instruction = i.Instruction
                            .Unit = i.Unit
                        End With
                        iCnt += 1
                    Next
                    For jCnt As Integer = 1 To CntToRemove
                        Dim aIng As IngredientLine = Me.Ingredients(iCnt)
                        Me.Ingredients.Remove(aIng)
                    Next


                End If
            Else
                Dim iCnt As Integer = 0
                For Each i In theList
                    With Me.Ingredients(iCnt)
                        .Amount = i.Amount
                        .Ingredient = i.Ingredient
                        .Instruction = i.Instruction
                        .Unit = i.Unit
                    End With
                    iCnt += 1
                Next
            End If
        Else
            Me.Ingredients = theList
        End If
    End Sub

    Public Function IngredientsAsString() As String
        If Me.Ingredients.Count > 0 Then
            Dim theString As String = String.Empty
            For Each i In Me.Ingredients
                theString += i.ToString + vbCrLf
            Next
            Return theString.Substring(0, theString.Length - 2)
        Else
            Return String.Empty
        End If
    End Function
End Class
