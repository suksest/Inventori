Public Class frPembayaran
    Dim total_transaksi As Single

    Public Sub New(ByVal total As Single)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        total_transaksi = total
        Label1.Text = "Rp " & total_transaksi & ",-"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call cekPembayaran()
    End Sub

    Private Sub CekPembayaran()
        If TextBox1.Text = "" Then
            MsgBox("Isi nominal pembayaran")
        Else
            Dim bayar As Single
            bayar = TextBox1.Text
            TextBox2.Text = CSng(bayar - total_transaksi)
            Button2.Enabled = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        End If
    End Sub
End Class