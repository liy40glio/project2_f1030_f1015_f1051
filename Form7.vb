Public Class Form7

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        On Error Resume Next
        cmd.Connection = con
        cmd.Connection.Open()
        cmd = con.CreateCommand
        cmd.CommandText = "INSERT INTO tbl_item (cName,foodItem, qty)" & "Values (" & "'" & UCase(txtName.Text) & "'," _
        & "'" & UCase(cbFooditem.Text) & "'," _
        & "'" & UCase(txtQty.Text) & "')"

        MessageBox.Show("Data Have Been Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)


        cmd.ExecuteNonQuery()
        UpdateSub()
        con.Close()

        txtName.Text = ""
        cbFooditem.Text = ""
        txtQty.Text = ""
        txtName.Focus()
    End Sub
    Private Sub UpdateSub()
        On Error Resume Next
        ds.Clear()
        cmd = con.CreateCommand
        cmd.CommandText = "select * from tbl_item"
        da.SelectCommand = cmd
        da.Fill(ds, "tbl_item")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtName.Clear()
        cbFooditem.Text = ""
        txtQty.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub
End Class