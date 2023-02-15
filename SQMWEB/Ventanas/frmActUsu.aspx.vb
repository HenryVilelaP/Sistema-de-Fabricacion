
#Region "IMPORT"

Imports BLLSQM
Imports BELSQM

#End Region

Partial Class Ventanas_frmActUsu

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oBlutil As New BLLUtilitario
    Private oBlusu As New BEPersona

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcontrasena.Focus()
        If Not Page.IsPostBack Then
            oBlusu = Session.Item("Usuario")
            If oBlusu Is Nothing Then
                lblres.Visible = True
                lblres.Text = "CIERRE SESION Y VUELVA A INICIAR SESION"
            Else
                txtusuario.Text = oBlusu.Usuario
                txtclave.Text = oBlusu.Claveweb
                txtcorreo.Text = oBlusu.Correo
                txtsecurity.Text = oBlusu.Security
            End If
        End If
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub btnactualiza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnactualiza.Click
        oBlusu.Usuario = txtusuario.Text
        oBlusu.Claveweb = txtclave.Text
        oBlusu.Correo = txtcorreo.Text
        oBlusu.Security = txtsecurity.Text
        oBlusu.Contrasena = txtcontrasena.Text
        oBlutil.ActuaClave(oBlusu)
        lblres.Text = "Proceso Exitoso"
        lblres.Visible = True
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        btnactualiza.Enabled = True
    End Sub

#End Region

End Class
