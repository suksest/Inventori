Public Class frUtama
    Private Sub frUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True 'Timer aktif ketika frUtama dipanggil
        ToolStripStatusLabel1.Text = TimeOfDay
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = TimeOfDay
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PegawaiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegawaiToolStripMenuItem.Click
        Dim frPgw As New frPegawai
        frPgw.MdiParent = Me
        frPgw.Show()
    End Sub

    Private Sub PegawaiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PegawaiToolStripMenuItem1.Click
        Dim frRpPgw As New frRpPegawai
        frRpPgw.MdiParent = Me
        frRpPgw.Show()
    End Sub

    Private Sub TransaksiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem1.Click
        Dim frTgl As New frPeriodeLaporan
        frTgl.MdiParent = Me
        frTgl.Show()
    End Sub
End Class