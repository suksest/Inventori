Public Class frLogin
    Private Sub Button1_Click(sender As Object, e As _
                              EventArgs) Handles Button1.Click

        Dim frAnak As New frUtama

        If (TextBox1.Text = "Raka") And (TextBox2.Text = "Raka for iPhone") Then
            MessageBox.Show("Selamat " & TextBox1.Text & "! Anda berhasil login", "Selamat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frAnak.Show()
        ElseIf (TextBox1.Text = "Raka") And (TextBox2.Text = "Raka for Android") Then
            MessageBox.Show("Selamat " & TextBox1.Text & "! Anda berhasil login", "Selamat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frAnak.Show()
        Else
            MessageBox.Show("Maaf " & TextBox1.Text & "! Anda gagal login", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class
