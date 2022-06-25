Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If IsValidData() Then
                Dim name As String = Convert.ToString(txtName.Text)
                Dim Ic As String = Convert.ToString(txtIC.Text)
                Dim payment As String = Convert.ToString(cbPayment.Text)
                ListBox1.Items.Add(String.Format("  " & name & "  " & Ic & "  " & payment & "  " & name & "@vb.net"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.GetType.ToString & vbCrLf & vbCrLf & ex.StackTrace, "Exception")
        End Try
    End Sub
    Private Function IsValidData() As Boolean
        Return _
        IsPresent(txtName, "Name") AndAlso
        IsPresent(txtIC, "IC Number")
    End Function
    Private Function IsPresent(ByVal textbox As TextBox, ByVal name As String) As Boolean
        If textbox.Text = "" Then
            MessageBox.Show("please insert " & name & " form ", "Entry Error")
            textbox.Select()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtName.Text = ""
        txtIC.Text = ""
        cbPayment.Text = ""
        ListBox1.Items.Clear()
        txtName.Focus()
    End Sub

    Private Sub txtIC_TextChanged(sender As Object, e As EventArgs) Handles txtIC.TextChanged
        If txtIC.TextLength > 12 Then
            MessageBox.Show("PLEASE INSRET 12 DIGIT ONLY")
        End If
    End Sub
    Private Sub txtIC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIC.KeyPress

        If e.KeyChar <> ChrW(8) AndAlso Not (e.KeyChar >= "0"c AndAlso e.KeyChar <= "9"c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtICnumber_KeyPress_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIC.KeyPress
        If e.KeyChar <> ChrW(8) AndAlso Not (e.KeyChar >= "0"c AndAlso e.KeyChar <= "9"c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim myForm As New Form7
        Me.Hide()
        myForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim myForm As New Form1
        Me.Hide()
        myForm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim strName As String = txtName.Text
        Dim strIC As String = txtIC.Text
        Dim strPayment As String = cbPayment.Text
        Dim strOutput As String = MessageBox.Show("Hello " + strName + ", Your Order Is Successful,Thank You !! Till We Meet Again", "ORDER SUCCESSFUL")
        Dim myForm As New Form1
        Me.Hide()
        myForm.Show()
    End Sub
End Class