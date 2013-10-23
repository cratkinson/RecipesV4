Imports System.ComponentModel.DataAnnotations

Public Class IngredientLine
    Public Property IngredientLineID As Integer
    Public Property Amount As Double
    <StringLength(40)> _
    Public Property Unit As String
    Public Property Ingredient As String
    Public Property Instruction As String

    Public Overridable Property RecipeID As Integer
    Public Overridable Property Recipe As Recipe

    Public Overrides Function ToString() As String
        Dim s As String = String.Empty
        If Me.Amount > 0 Then
            Dim a As Integer = Int(Math.Floor(Me.Amount))
            Dim frac As String = String.Empty
            If Me.Amount - a > 0 Then
                frac = rationalv2(Me.Amount - a)
            End If
            If a > 0 Then
                s = a.ToString + IIf(frac <> String.Empty, " " + frac, String.Empty)
            Else
                s = frac
            End If
        End If

        If Me.Unit <> String.Empty Then
            If s <> String.Empty Then
                s += " " + Me.Unit
            Else
                s = Me.Unit
            End If
        End If

        If Me.Ingredient <> String.Empty Then
            If s <> String.Empty Then
                s += " " + Me.Ingredient
            Else
                s = Me.Ingredient
            End If
        End If

        If Me.Instruction <> String.Empty Then
            s += ", " + Me.Instruction
        End If

        Return s
    End Function
    Private Function rationalv2(num As Decimal) As String
        Dim theErr As Decimal = 0.000001
        Dim numerator, denominator As Integer

        Dim lower_n As Integer = 0
        Dim lower_d As Integer = 1
        Dim upper_n As Integer = 1
        Dim upper_d As Integer = 1
        Dim middle_n, middle_d As Integer

        Dim done As Boolean = False
        While Not done
            middle_n = lower_n + upper_n
            middle_d = lower_d + upper_d
            If middle_d * (num + theErr) < middle_n Then
                upper_n = middle_n
                upper_d = middle_d
            ElseIf middle_n < (num - theErr) * middle_d Then
                lower_n = middle_n
                lower_d = middle_d
            Else
                numerator = middle_n
                denominator = middle_d
                done = True
            End If
        End While
        Return numerator.ToString + "/" + denominator.ToString
    End Function

End Class
