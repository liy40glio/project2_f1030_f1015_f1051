Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Username As String = txtUsername.Text.ToString
        Dim Password As String = txtPassword.Text.ToString

        con.Open()
        cmd.CommandText = "SELECT * FROM details where Uname ='" & Username & "' and " & "Pass = '" & Password & "'"

        cmd.Connection = con
        sdr = cmd.ExecuteReader()

        If (sdr.Read() = True) Then
            MsgBox("susscessful login")
            Dim myForm As New Form7
            Me.Hide()
            myForm.Show()
        Else
            MsgBox("failed login")
        End If

        con.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim myForm As New Form6
        Me.Hide()
        myForm.Show()
    End Sub

    Private Sub ABOUTUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABOUTUSToolStripMenuItem.Click
        Dim myForm As New Form5
        Me.Hide()
        myForm.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class