Public Class frPilihKelamin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frRpt As New frRpPegawai
        Dim par_jk As String
        par_jk = ComboBox1.Text
        frRpt.CrystalReportViewer1.SelectionFormula = "{TPEGAWAI.jk_pgw} = '" & par_jk & "'"
        frRpt.Show()
    End Sub
End Class