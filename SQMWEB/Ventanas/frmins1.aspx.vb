
#Region "IMPORT"

Imports BELSQM
Imports BLLSQM

#End Region

Partial Class Ventanas_frmins1

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private opro As New BELProducto
    Private oFabricacion As New BLLFabricacion

#End Region

#Region "CONTROLES"

    Protected Sub lnkbusca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbusca.Click
        opro.nombre = txtnombre.Text
        grvproductos.DataSource = oFabricacion.ConsProductoF(opro)
        grvproductos.DataBind()
    End Sub

    Protected Sub grvproductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvproductos.SelectedIndexChanged
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
        sb.Append("<script Language='JavaScript'>")
        sb.Append("window.opener.document.forms[0].ctl00_ContentPlaceHolder1_TextBox1.value='" & grvproductos.SelectedRow.Cells(1).Text & "';")
        sb.Append("window.opener.document.forms[0].ctl00_ContentPlaceHolder1_TextBox2.value='" & grvproductos.SelectedRow.Cells(2).Text & "';")
        sb.Append("window.close();")
        sb.Append("</script>")
        If Not ClientScript.IsClientScriptBlockRegistered("msTemp") Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "msTemp", sb.ToString)
        End If
    End Sub

#End Region


End Class
