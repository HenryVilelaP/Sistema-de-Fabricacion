
#Region "IMPORT"

Imports BLLSQM
Imports BELSQM
Imports System.Data

#End Region

Partial Class Ventanas_frmbuscapro

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oFabricacion As New BLLFabricacion
    Private oProducto As New BELProducto
    Private ds As New DataSet

#End Region

#Region "CONTROLES"

    Protected Sub btnbusca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbusca.Click
        oProducto.nombre = txtproducto.Text
        grvproducto.DataSource = oFabricacion.ConsProducto(oProducto)
        grvproducto.DataBind()
    End Sub

    Protected Sub grvproducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvproducto.SelectedIndexChanged
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
        sb.Append("<script Language='JavaScript'>")
        sb.Append("window.opener.document.forms[0].ctl00_ContentPlaceHolder1_txtproducto.value='" & grvproducto.SelectedRow.Cells(2).Text & "';")
        sb.Append("window.opener.document.forms[0].ctl00_ContentPlaceHolder1_txtcodpro.value='" & grvproducto.SelectedRow.Cells(1).Text & "';")
        sb.Append("window.close();")
        sb.Append("</script>")
        If Not ClientScript.IsClientScriptBlockRegistered("msTemp") Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "msTemp", sb.ToString)
        End If
    End Sub

#End Region


End Class
