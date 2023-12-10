Public Class F_MenuUtama
    'Function close form
    Private Sub CloseAllForms()
        Me.Close()
    End Sub

    'Function Terkunci
    Private Sub Terkunci()
        MasterToolStripMenuItem.Enabled = False
        TransaksiToolStripMenuItem.Enabled = False
        LaporanToolStripMenuItem.Enabled = False
        UtilityToolStripMenuItem.Enabled = False

        Panel1.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
    End Sub

    'Button Login/Logout on MenuUtama
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Login" Then
            F_MenuLogin.Show()
        ElseIf Button1.Text = "Logout" Then
            Dim Result As DialogResult = MessageBox.Show("Yakin ingin Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.Yes Then
                Call Terkunci()
                Button1.Text = "Login"
            End If
        End If
    End Sub

    'Close form
    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        If Button1.Text = "Logout" Then
            MsgBox("Silahkan Logout Terlebih Dahulu.!", vbCritical + vbOKOnly)
        Else
            CloseAllForms()
        End If
    End Sub

    'Load View
    Private Sub F_MenuUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Terkunci()
    End Sub

    'Master Admin Click
    Private Sub AdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminToolStripMenuItem.Click
        F_MasterAdmin.Show()
    End Sub
End Class
