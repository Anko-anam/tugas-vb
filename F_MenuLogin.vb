Imports System.Data.Odbc
Public Class F_MenuLogin
    'Button Back Click
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    'Function Terbuka for Admin Level
    Sub AdminTerbuka()
        F_MenuUtama.Button1.Text = "Logout"
        F_MenuUtama.MasterToolStripMenuItem.Enabled = True
        F_MenuUtama.TransaksiToolStripMenuItem.Enabled = True
        F_MenuUtama.LaporanToolStripMenuItem.Enabled = True
        F_MenuUtama.UtilityToolStripMenuItem.Enabled = True

        F_MenuUtama.Panel1.Visible = True
        F_MenuUtama.Label1.Visible = True
        F_MenuUtama.Label2.Visible = True
        F_MenuUtama.Label3.Visible = True
    End Sub

    'Function Terbuka for User Level
    Sub UserTerbuka()
        F_MenuUtama.Button1.Text = "Logout"
        F_MenuUtama.MasterToolStripMenuItem.Enabled = True
        F_MenuUtama.PelangganToolStripMenuItem.Enabled = True
        F_MenuUtama.BarangToolStripMenuItem.Enabled = True
        F_MenuUtama.AdminToolStripMenuItem.Enabled = False
        F_MenuUtama.TransaksiToolStripMenuItem.Enabled = True
        F_MenuUtama.PenjualanToolStripMenuItem.Enabled = True
        F_MenuUtama.UtilityToolStripMenuItem.Enabled = True

        F_MenuUtama.Panel1.Visible = True
        F_MenuUtama.Label1.Visible = True
        F_MenuUtama.Label2.Visible = True
        F_MenuUtama.Label3.Visible = True

        F_MenuUtama.Label2.Text = "Admin  : User"
        F_MenuUtama.Label3.Text = "Level  : User"
    End Sub


    'Button Login Click
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Kode Admin & Password Tidak Boleh Kosong")
        Else
            Call Koneksi()
            Cmd = New OdbcCommand("SELECT * FROM tbl_admin WHERE kode_admin='" & TextBox1.Text & "'AND pass_admin='" & TextBox2.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                If Rd("level_admin").ToString = "ADMIN" Then
                    MsgBox("Login Admin Berhasil", vbInformation + vbOKOnly, "Success")
                    Me.Close()
                    Call AdminTerbuka()
                ElseIf Rd("level_admin").ToString = "USER" Then
                    MsgBox("Login User Berhasil", vbInformation + vbOKOnly, "Success")
                    Me.Close()
                    Call UserTerbuka()
                End If
            Else
                MsgBox("Nama Atau Password Salah", vbCritical + vbOKOnly, "Error")
            End If
        End If
    End Sub

    'Enter For Login
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Kode Admin & Password Tidak Boleh Kosong")
            Else
                Call Koneksi()
                Cmd = New OdbcCommand("SELECT * FROM tbl_admin WHERE kode_admin='" & TextBox1.Text & "'AND pass_admin='" & TextBox2.Text & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    If Rd("level_admin").ToString = "ADMIN" Then
                        MsgBox("Login Berhasil", vbInformation + vbOKOnly, "Success")
                        Me.Close()
                        Call AdminTerbuka()
                    ElseIf Rd("level_admin").ToString = "USER" Then
                        MsgBox("Login User Berhasil", vbInformation + vbOKOnly, "Success")
                        Me.Close()
                        Call UserTerbuka()
                    End If
                Else
                    MsgBox("Nama Atau Password Salah", vbCritical + vbOKOnly, "Error")
                End If
            End If
        End If
    End Sub

    'Cancel Button Click
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class