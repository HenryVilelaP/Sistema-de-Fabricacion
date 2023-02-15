
#Region "IMPORT"

Imports BELSQM
Imports BLLSQM

#End Region

Partial Class Logueo

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Public vFecSer As Date

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim oCFechaServidor As New BLLUtilitario
        'Dim oFecha As New BELServidor
        'vFecSer = Convert.ToDateTime(oCFechaServidor.ListarFecha(oFecha).Tables(0).Rows(0).Item(0))
        lblfecha.Text = "Lima " + CStr(Now)
        'lblfecha.Text = "Lima " + CStr(vFecSer.ToShortDateString()) + " " + CStr(vFecSer.ToLongTimeString())
        txtUsuario.Focus()
        lblNoValido.Visible = False
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub BtnIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIng.Click
        Dim oFabricacion As New BLLFabricacion
        Dim oBELusuario As New BEPersona
        Dim ds1 As Data.DataSet
        With oBELusuario
            .Usuario = UCase(Trim(txtUsuario.Text))
            .Claveweb = UCase(Trim(txtContrasena.Text))
        End With
        ds1 = oFabricacion.ValidaUsuario(oBELusuario)
        If ds1.Tables(0).Rows.Count > 0 Then
            FormsAuthentication.Initialize()
            Dim fat As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, oBELusuario.Usuario,
            DateTime.Now, DateTime.Now.AddMinutes(30), False, oBELusuario.Usuario, FormsAuthentication.FormsCookiePath)
            Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName,
            FormsAuthentication.Encrypt(fat)))
            oBELusuario.Security = ds1.Tables(0).Rows(0).Item(1)
            oBELusuario.Correo = ds1.Tables(0).Rows(0).Item(2)
            oBELusuario.Contrasena = ds1.Tables(0).Rows(0).Item(3)
            Session.Item("Usuario") = oBELusuario
            ds1.Clear()
            Response.Redirect("Bienvenido.aspx")
        Else
            lblNoValido.Visible = True
        End If

    End Sub

#End Region

End Class
