Public Class Form6
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If IsValidData() Then
                Dim name As String = Convert.ToString(txtName.Text)
                Dim Email As String = Convert.ToString(txtEmail.Text)
                Dim Uname As String = Convert.ToString(txtUname.Text)
                Dim pass As String = Convert.ToString(txtPass.Text)
                data()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.GetType.ToString & vbCrLf & vbCrLf & ex.StackTrace, "Exception")
        End Try
    End Sub
    Private Sub data()
        On Error Resume Next
        cmd.Connection = con
        cmd.Connection.Open()
        cmd = con.CreateCommand
        cmd.CommandText = "INSERT INTO details (Uname, Pass)" & "Values (" & "'" & UCase(txtUname.Text) & "'," _
        & "'" & UCase(txtPass.Text) & "')"

        MessageBox.Show("Sucessful register your account", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Information)


        cmd.ExecuteNonQuery()
        con.Close()

        txtName.Text = ""
        txtEmail.Text = ""
        txtUname.Text = ""
        txtPass.Text = ""
        txtName.Focus()
        Dim myForm As New Form2
        Me.Hide()
        myForm.Show()
    End Sub
    Private Function IsValidData() As Boolean
        Return _
        IsPresent(txtName, "Name") AndAlso
        IsPresent(txtEmail, "Email") AndAlso
        IsPresent(txtUname, "Username") AndAlso
        IsPresent(txtPass, "Password")
    End Function
    Private Function IsPresent(ByVal textbox As TextBox, ByVal name As String) As Boolean
        If textbox.Text = "" Then
            MessageBox.Show("please insert " & name & " form ", "Register")
            textbox.Select()
            Return False
        Else
            Return True
        End If
    End Function
End Class