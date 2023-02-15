
#Region "IMPORT"

Imports BELSQM
Imports BLLSQM

#End Region

Partial Class Ventanas_frmblote1

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oFabricacion As New BLLFabricacion
    Private oPro As New BELProducto
    Private oFab2 As New BELFabric

#End Region

#Region "CONTROLES"

    Protected Sub grvlote_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvlote.SelectedIndexChanged

        Dim cantreservada As Double
        cantreservada = CDbl(Session.Item("reserva2"))

        oFab2.idlote = grvlote.SelectedRow.Cells(1).Text
        oFab2.costo = grvlote.SelectedRow.Cells(5).Text
        Session.Item("codlote2") = oFab2

        If cantreservada <= grvlote.SelectedRow.Cells(4).Text Then
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
            sb.Append("<script Language='JavaScript'>")
            sb.Append("window.opener.document.forms[0].ctl00_ContentPlaceHolder1_txtorg2.value='" & Server.HtmlDecode(grvlote.SelectedRow.Cells(2).Text) & "';")
            sb.Append("window.opener.document.forms[0].ctl00_ContentPlaceHolder1_txtlot2.value='" & Server.HtmlDecode(grvlote.SelectedRow.Cells(3).Text) & "';")
            sb.Append("window.close();")
            sb.Append("</script>")
            If Not ClientScript.IsClientScriptBlockRegistered("msTemp") Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "msTemp", sb.ToString)
            End If
        End If
        Label1.Text = "CANTIDAD INSUFICIENTE.... "
        Label2.Text = "SELECCIONE OTRO LOTE...."

    End Sub

#End Region
    
#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        oPro.codigo = Session.Item("cod2")
        grvlote.DataSource = oFabricacion.ConsdlotePro(oPro)
        grvlote.DataBind()
    End Sub

#End Region

End Class
