
#Region "IMPORT"

Imports BELSQM
Imports BLLSQM
Imports System.Web.Mail
Imports System.Data

#End Region

Partial Class Ventanas_frmActVtalo

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oBLL As New BLLFabricacion
    Private oBLLutil As New BLLUtilitario
    Private oFab As New BELFabric
    Private oPers As New BEPersona

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtclave.Focus()
        oFab.idlote = Request.QueryString("Key")
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub btnliberar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnliberar.Click
        Dim dss As New DataSet
        Dim cant As Integer
        oPers = Session.Item("Usuario")
        lblres.Text = ""

        Try
            If txtcantidad.Text.Trim <> " " And IsNumeric(txtcantidad.Text) = True Then
                oFab.cantidad = CDbl(txtcantidad.Text)
                If txtcantidad.Text > 0 Then
                    dss = oBLL.ConsVtaLot(oFab)
                    cant = dss.Tables(0).Rows.Count
                    If cant > 0 Then
                        If oBLL.ActuaVtaLot(oFab) Then
                            btnliberar.Enabled = False
                            oBLLutil.EnviaCorreo(oFab, oPers)
                            lblres.Text = "PROCESO EXITOSO"
                        Else
                            lblres.Text = "ERROR ....."
                        End If
                        CerrarInvocarFormPadre("Pagina_Consulta_lote()")
                    Else
                        lblres.Text = "INGRESE CANTIDAD MENOR"
                    End If
                Else
                    lblres.Text = "INGRESE CANTIDAD"
                End If
            Else
                lblres.Text = "INGRESE CANTIDAD"
            End If
            txtcantidad.Text = ""

        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    Protected Sub btnvalida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnvalida.Click
        oPers = Session.Item("Usuario")
        lblres.Text = ""
        If txtclave.Text <> "" And txtclave.Text = oPers.Security Then
            txtcantidad.Visible = True
            txtclave.TextMode = TextBoxMode.SingleLine
            txtclave.Text = oPers.Usuario
            btnliberar.Visible = True
            Label2.Visible = True
            btnvalida.Visible = False
            Label2.Text = "Ingrese Cantidad a Liberar:"
            txtcantidad.Focus()

        Else
            lblres.Text = "CLAVE INCORRECTA"
            lblres.ForeColor = Drawing.Color.Red
        End If

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub CerrarInvocarFormPadre(ByVal sFuncJSFormPadre As String)
        Dim sJavaScript As String = String.Empty
        sJavaScript = "<script language='javascript' type='text/javascript'>{window.close();window.opener." & sFuncJSFormPadre & ";}</script>"
        ClientScript.RegisterStartupScript(Page.GetType(), "", sJavaScript)
    End Sub

    Public Sub JScriptFocus(ByVal oControl As Control, ByVal oType As Type)
        Dim sFocus As String = "<script language='javascript'>" & _
        "var obj = document.getElementById('" & oControl.ClientID & "')" & vbCrLf & _
        "if (typeof(obj)!='undefined')obj.focus(); </script>"
        ClientScript.RegisterStartupScript(oType, "sFocus", sFocus)
    End Sub

#End Region

End Class
