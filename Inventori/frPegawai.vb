Public Class frPegawai
    Private Sub frPegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        OleDbDataAdapter1.Fill(DsPegawai1)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        OleDbConnection1.Open()
        sql = "INSERT INTO Tpegawai VALUES('" & TextBox1.Text & "', '" &
        TextBox2.Text & "', '" & DateValue(DateTimePicker1.Value) & "', '" &
        ComboBox1.SelectedItem & "', " & "'" & TextBox3.Text & "', '" & TextBox4.Text & "')"

        OleDbDataAdapter1.InsertCommand.CommandText = sql
        OleDbDataAdapter1.InsertCommand.ExecuteNonQuery()
        OleDbConnection1.Close()
        MessageBox.Show("Data berhasil dimasukkan", "Konfirmasi berhasil",
        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) _
        Handles Button2.Click
        Dim sql As String

        sql = "SELECT NIP,nama_pgw AS [Nama Pegawai],tgl_lahir_pgw AS " &
            “[Tanggal Lahir], jk_pgw AS [Jenis Kelamin], alamat_pgw AS Alamat, " &
            “telp_pgw AS Telepon FROM Tpegawai”

        OleDbDataAdapter1.SelectCommand.CommandText = sql
        DsPegawai1.Clear()
        OleDbDataAdapter1.Fill(DsPegawai1, "Tpegawai")
        DataGrid1.SetDataBinding(DsPegawai1, "Tpegawai")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) _
        Handles Button3.Click

        Dim sql As String

        sql = "SELECT NIP,nama_pgw AS [Nama Pegawai],tgl_lahir_pgw AS [Tanggal Lahir], " &
        "jk_pgw AS [Jenis Kelamin], alamat_pgw AS Alamat, telp_pgw AS Telepon " &
        "FROM Tpegawai WHERE nama_pgw LIKE '%" & TextBox5.Text & "%'"

        OleDbDataAdapter1.SelectCommand.CommandText = sql
        DsPegawai1.Clear()
        OleDbDataAdapter1.Fill(DsPegawai1, "Tpegawai")
        DataGrid1.SetDataBinding(DsPegawai1, "Tpegawai")


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OleDbDataAdapter1.Update(DsPegawai1)
        MessageBox.Show("Data berhasil diubah", "Konfirmasi berhasil",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sql As String
        Dim selectedCell As DataGridCell
        Dim selectedItem As Object
        Dim result As DialogResult

        selectedCell = DataGrid1.CurrentCell
        selectedItem = DataGrid1.Item(
  selectedCell.RowNumber, selectedCell.ColumnNumber)

        result = MessageBox.Show("Yakin Pegawai Dengan NIP " & selectedItem &
  " Akan Dihapus?", "Konfirmasi", MessageBoxButtons.OKCancel,
  MessageBoxIcon.Warning)

        If result = DialogResult.OK Then
            OleDbConnection1.Open()
            sql = "DELETE FROM Tpegawai WHERE NIP = '" & selectedItem & "'"
            OleDbDataAdapter1.DeleteCommand.CommandText = sql
            OleDbDataAdapter1.DeleteCommand.ExecuteNonQuery()

            Call Button2_Click(sender, e)  'menjalankan tombol refresh
            OleDbConnection1.Close()
        End If

    End Sub
End Class