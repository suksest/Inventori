Public Class frPeriodeLaporan
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frRpt As New frRpPenjualan
        Dim par_tgl_awal, par_tgl_akhir As Date 'variable parameter

        'par_tgl_awal = Format(DateTimePicker1.Value.Date, "dd/MM/yyyy")
        'par_tgl_akhir = Format(DateTimePicker2.Value.Date, "dd/MM/yyyy")

        par_tgl_awal = DateTimePicker1.Value.Date
        par_tgl_akhir = DateTimePicker2.Value.Date

        frRpt.CrystalReportViewer1.SelectionFormula =
        "{TTransaksi.tgl_transaksi} >= DateTime(" &
         Format(par_tgl_awal, "yyyy") &
        "," & Format(par_tgl_awal, "MM") & "," & Format(par_tgl_awal, "dd") &
        ",0,0,0)AND{TTransaksi.tgl_transaksi}<=DateTime(" &
        Format(par_tgl_akhir, "yyyy") &
        "," & Format(par_tgl_akhir, "MM") & "," &
        Format(par_tgl_akhir, "dd") & ",0,0,0)"
        'format tanggal Crystal Report = DateTime(2018, 12, 13, 0, 0, 0) 

        frRpt.Label2.Text = par_tgl_awal
        frRpt.Label4.Text = par_tgl_akhir
        frRpt.Show()

    End Sub
End Class