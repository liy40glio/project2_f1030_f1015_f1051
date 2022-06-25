Public Class Form3
    Dim searchKey, sqlCond As String
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCname.Enabled = False
        cbFood.Enabled = False

        btnUpdate.Enabled = True
        btnDelete.Enabled = True

    End Sub
    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Dim myForm As New Form1
        Me.Hide()
        myForm.Show()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        On Error Resume Next
        con.Open()
        cmd.CommandText = "UPDATE tbl_item SET cName = '" & UCase(txtName.Text) & " ', " _
        & "foodItem = '" & UCase(cbFooditem.Text) & " ', " _
        & "qty = '" & UCase(txtQty.Text) & " ', " _
        & "WHERE ID=" & lblID.Text
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
        UpdateSub()

        MessageBox.Show("Information Update", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub UpdateSub()
        On Error Resume Next
        ds.Clear()

        cmd = con.CreateCommand
        cmd.CommandText = "select * from tbl_item"

        da.SelectCommand = cmd

        da.Fill(ds, "tbl_item")
        lblID.DataBindings.Add("Text", ds.Tables("tbl_item"), "ID")
        txtName.DataBindings.Add("Text", ds.Tables("tbl_item"), "cName")
        cbFooditem.DataBindings.Add("Text", ds.Tables("tbl_item"), "foodItem")
        txtQty.DataBindings.Add("Text", ds.Tables("tbl_item"), "qty")
        DataGridView1.DataSource = ds.Tables(0)

    End Sub
    Private Sub SearchSelection()
        If rbName.Checked = True Then
            searchKey = UCase(txtCname.Text)
            sqlCond = "cName"

        Else rbFood.Checked = True
            searchKey = UCase(cbFood.SelectedItem)
            sqlCond = "foodItem"
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If (MessageBox.Show("Are You want to delete this record?", "DeleteRecord",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then
            con.Open()
            Dim Del As OleDb.OleDbCommand = New OleDb.OleDbCommand()
            Del.CommandText = "Delete From tbl_item Where ID = " & lblID.Text

            Del.Connection = con
            Del.ExecuteNonQuery()

            Me.BindingContext(ds.Tables("tbl_item")).RemoveAt _
                (Me.BindingContext(ds.Tables("tbl_item")).Position)
            con.Close()
            MessageBox.Show("Data Have Been Deleted", "Delete", MessageBoxButtons.OK,
                             MessageBoxIcon.Information)
        Else
            Me.Refresh()

        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchSelection()
        On Error Resume Next
        ds.Clear()

        cmd = con.CreateCommand
        cmd.CommandText = "Select * from tbl_item where " & sqlCond & " Like '" & searchKey & "'"

        da.SelectCommand = cmd

        da.Fill(ds, "tbl_item")
        lblID.DataBindings.Add("Text", ds.Tables("tbl_item"), "ID")
        txtName.DataBindings.Add("Text", ds.Tables("tbl_item"), "cName")
        cbFooditem.DataBindings.Add("Text", ds.Tables("tbl_item"), "foodItem")
        txtQty.DataBindings.Add("Text", ds.Tables("tbl_item"), "qty")
        DataGridView1.DataSource = ds.Tables(0)

        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rbName.CheckedChanged
        txtCname.Enabled = True
        cbFood.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myForm As New Form4
        Me.Hide()
        myForm.Show()
    End Sub

    Private Sub rbFood_CheckedChanged(sender As Object, e As EventArgs) Handles rbFood.CheckedChanged
        txtCname.Enabled = False
        cbFood.Enabled = True
    End Sub
End Class