

Public Class Form1
#Region "--- Global variables --- "
    Dim Operation As String               'variables to store assigned operations
    Dim flag As Boolean = False
    Dim assign_input As Double = 0         'variable for inputs
    Dim operatorflag As Boolean = False
#End Region
#Region "----- Operations of Calculator ----- "
    Private Sub operation_click(sender As Object, e As EventArgs) Handles Button7.Click, Button4.Click, Button17.Click, Button11.Click
        Dim b As Button = sender ' Button input
        Airthmatic(b.Text)
    End Sub
#End Region

#Region "----- Input of operations from keyboard ----- "
    Sub Airthmatic(ch As Char)    ' arithmatic function for keyboard characters
        If (assign_input <> 0) Then
            btnResult.PerformClick()
            flag = True
            Operation = ch
            LblHistory.Text = assign_input & "   " & Operation     'Display input in Result Area
        Else
            Operation = ch
            assign_input = Double.Parse(txtResultarea.Text)
            flag = True
            LblHistory.Text = assign_input & "   " & Operation
        End If
        operatorflag = True
        Label2.Focus()
    End Sub
#End Region


#Region "----- Clearbutton event ----- "
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtResultarea.Text = "0"
        LblHistory.Text = ""
        Label2.Focus()
    End Sub

#End Region

#Region "------ Result of operations ----- "
    Private Sub btnResult_Click(sender As Object, e As EventArgs) Handles btnResult.Click
        LblHistory.Text = ""
        Select Case Operation
            Case "+"
                txtResultarea.Text = (assign_input + Double.Parse(txtResultarea.Text)).ToString()
            Case "-"
                txtResultarea.Text = (assign_input - Double.Parse(txtResultarea.Text)).ToString()
            Case "*"
                txtResultarea.Text = (assign_input * Double.Parse(txtResultarea.Text)).ToString()
            Case "/"
                If assign_input = 0 And Double.Parse(txtResultarea.Text) = 0 Then
                    txtResultarea.Text = "Result Is undefined"
                    Label2.Focus()
                    Return
                ElseIf Double.Parse(txtResultarea.Text) = 0 Then
                    txtResultarea.Text = "Cannot divide by zero"
                    Label2.Focus()
                    Return

                Else
                    txtResultarea.Text = (assign_input / Double.Parse(txtResultarea.Text)).ToString()
                End If


        End Select

        assign_input = Double.Parse(txtResultarea.Text)
        Operation = ""
        Label2.Focus()
    End Sub

#End Region

#Region " ---- Delete key From Keyboard ----"

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Delete Then
            btnClear_Click(sender, e)
        End If
    End Sub
#End Region

#Region "---- Backspace Button ----"
    Private Sub backspace_click(sender As Object, e As EventArgs) Handles btnBackspace.Click
        If operatorflag = False Then
            If txtResultarea.Text.Length > 0 Then
                txtResultarea.Text = txtResultarea.Text.Remove(txtResultarea.Text.Length - 1, 1)  ' Remove the last entered number

            End If
            If txtResultarea.Text = "" Then
                txtResultarea.Text = "0"
            End If
        End If
        Label2.Focus()
    End Sub

#End Region

#Region "---- Numbers click event ---- "
    Private Sub Numbers_click(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button3.Click, Button2.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button10.Click, Button1.Click
        Dim button As Button = sender
        number(button.Text)
    End Sub

    Sub number(ch As Char)
        operatorflag = False


        If flag = True Then
            txtResultarea.Text = ch

        End If
        If txtResultarea.Text.Length <> 9 Then                                                                                  ' to check the length of resultarea is greater than 9
            If (txtResultarea.Text = "0") Or (flag) Then
                txtResultarea.Clear()
                txtResultarea.Text = ch
                flag = False
            ElseIf (ch = ".") Then
                If (Not txtResultarea.Text.Contains(".")) Then
                    txtResultarea.Text = txtResultarea.Text + ch
                End If

            Else
                txtResultarea.Text = txtResultarea.Text + ch
            End If

        End If
        Label2.Focus()
    End Sub
#End Region

#Region "---- Keyboard inputs ----"
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If txtResultarea.Text.Length <> 9 Then                                                                                  ' to check the length of resultarea is greater than 9
            If (e.KeyChar = ".") Then
                If (Not txtResultarea.Text.Contains(".")) Then
                    txtResultarea.Text = txtResultarea.Text + e.KeyChar
                End If
            ElseIf (e.KeyChar = ChrW(Keys.Back)) Then
                backspace_click(sender, e)
            ElseIf (e.KeyChar = ChrW(Keys.Enter)) Then
                btnResult_Click(sender, e)
            ElseIf (e.KeyChar = "/" Or e.KeyChar = "*" Or e.KeyChar = "-" Or e.KeyChar = "+") Then
                Airthmatic(e.KeyChar)
            ElseIf (e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9") Then
                number(e.KeyChar)

            End If
        End If
    End Sub
#End Region

End Class

