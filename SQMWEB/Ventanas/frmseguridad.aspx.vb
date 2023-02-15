
#Region "IMPORT"

Imports BELSQM
Imports BLLSQM

#End Region

Partial Class Ventanas_frmseguridad

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oFabricacion As New BLLFabricacion
    Private oFab As New BELFabric
    Private oPers As New BEPersona
    Private oBlutil As New BLLUtilitario

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If txtnombre.Text = "" Then
            oFab.codfab = Session.Item("codfab")
            oFab = Session.Item("oFabricacion")
            'txtnombre.Text = oFabricacion.ConsUltimoLote(oFab)
            txtnombre.Text = Left(oFabricacion.ConsUltimoLote(oFab), InStr(oFabricacion.ConsUltimoLote(oFab), ";") - 1)
            txtcosto.Text = Right(oFabricacion.ConsUltimoLote(oFab), Len(oFabricacion.ConsUltimoLote(oFab)) - InStr(oFabricacion.ConsUltimoLote(oFab), ";"))
        End If
        btneditar.Visible = False
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub rbnsi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbnsi.CheckedChanged
        txtnombre.Enabled = True
        rbnno.Checked = False
        btneditar.Visible = True
    End Sub

    Protected Sub btneditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btneditar.Click
        If txtnombre.Text.Trim <> "" Then
            oFab.lotefab = txtnombre.Text.Trim
            oFab.costo = txtcosto.Text.Trim

            oFabricacion.ActuavtalotesLoteFab(oFab)
            Label1.Text = "LOTE ACTUALIZADO"
            Label1.Visible = True
            btneditar.Enabled = False
            oFab.codfab = Session.Item("codfab")
            oPers = Session.Item("Usuario")
            oBlutil.EnviaCorreoGenerico(oFab, oPers)
            If oFab.costo = "0.00" Then oBlutil.EnviaCorreoAlerta(oFab, oPers)
            CerrarInvocarFormPadre("Pagina_Consulta()")
        End If
    End Sub

    Protected Sub rbnno_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbnno.CheckedChanged
        Label1.Text = "ESPERE UNOS SEGUNDOS"
        Label1.Visible = True
        rbnsi.Checked = False
        btneditar.Visible = False
        txtnombre.Enabled = False
        oPers = Session.Item("Usuario")
        oFab.codfab = Session.Item("codfab")
        oBlutil.EnviaCorreoGenerico(oFab, oPers)
        If oFab.costo = "0.00" Then oBlutil.EnviaCorreoAlerta(oFab, oPers)
        CerrarInvocarFormPadre("Pagina_Consulta()")
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub CerrarInvocarFormPadre(ByVal sFuncJSFormPadre As String)
        Dim sJavaScript As String = String.Empty
        sJavaScript = "<script language='javascript' type='text/javascript'>{window.close();window.opener." & sFuncJSFormPadre & ";}</script>"
        ClientScript.RegisterStartupScript(Page.GetType(), "", sJavaScript)
    End Sub

#End Region

End Class
