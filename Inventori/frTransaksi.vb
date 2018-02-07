Public Class frTransaksi
    Dim sum As Single = 0
    Private Sub frTransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String

        sql = "Select NAMA_BARANG as [Nama Barang] from TBARANG"
        OleDbConnection1.Open()

        OleDbDataAdapter1.Fill(DsBarang1)
        Dim table As DataTable = DsBarang1.Tables(0)
        ListBox1.DataSource = table
        ListBox1.DisplayMember = "Nama Barang"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String

        sql = "Select ID_BARANG as [Kode Barang], NAMA_BARANG as [Nama Barang] from TBARANG Where NAMA_BARANG like '%" & TextBox1.Text & "%'"

        OleDbDataAdapter1.SelectCommand.CommandText = sql
        DsBarang1.Clear()
        OleDbDataAdapter1.Fill(DsBarang1, "TBARANG")
        Dim table As DataTable = DsBarang1.Tables(0)
        ListBox1.DataSource = table
        ListBox1.DisplayMember = "Nama Barang"
        ListBox1.ValueMember = "Kode Barang"
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Dim dview As DataRowView
        Dim kode_barang As String = ""
        Dim sql As String
        For Each dview In ListBox1.SelectedItems
            kode_barang = dview.Row.Item(0).ToString
        Next

        If DataGridView1.Rows.Count <> 0 Then
            TextBox2.Text = "Sama"
        End If

        sql = "Select ID_BARANG as [Kode Barang], nama_barang As [Nama Barang], Qty, HRG_JUAL As [Harga], Qty* HRG_JUAL as Total From(Select ID_BARANG, nama_barang, HRG_JUAL, 1 as Qty From TBARANG Where ID_BARANG = '" & kode_barang & "') as Qty"

        OleDbDataAdapter1.SelectCommand.CommandText = sql
        OleDbDataAdapter1.Fill(DsTransaksiBarang1, "tbl_Barang")
        DataGridView1.DataSource = DsTransaksiBarang1.Tables("tbl_Barang").DefaultView

        'TextBox2.Text = DataGridView1.Rows.Count
        'If DataGridView1.Rows.Count <> 0 Then
        '    For index As Integer = 0 To DataGridView1.Rows.Count - 1
        '        sum = sum + DataGridView1.Rows(index).Cells(4).Value
        '    Next
        'Else
        '    TextBox2.Text = "Sama"
        'End If
        For index As Integer = 0 To DataGridView1.Rows.Count - 1
            sum = sum + DataGridView1.Rows(index).Cells(4).Value
        Next

        lbHarga.Text = "Rp " & sum & ",-"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If sum = 0 Then
            MsgBox("Masukkan barang terlebih dahulu")
        Else
            Dim frBayar As New frPembayaran(sum)
            frBayar.Show()
        End If
    End Sub
End Class