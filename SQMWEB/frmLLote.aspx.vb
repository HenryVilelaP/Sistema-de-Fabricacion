
#Region "IMPORT"

Imports BLLSQM
Imports BELSQM

#End Region

Partial Class frmLLote

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oBll As New BLLFabricacion
    Private oFab As New BELFabric

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        grvlotes.DataSource = oBll.ConsdloteLibera
        grvlotes.DataBind()
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub grvlotes_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvlotes.PageIndexChanging
        grvlotes.PageIndex = e.NewPageIndex
        grvlotes.DataSource = oBll.ConsdloteLibera
        grvlotes.DataBind()
    End Sub

    Protected Sub grvlotes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvlotes.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim YourLink As LinkButton
            YourLink = e.Row.Cells(1).FindControl("Linkbutton1")
            YourLink.OnClientClick = "javascript : popup_window=window.open('Ventanas/frmActVtalo.aspx?Key=" & CType(e.Row.Cells(2).Text.ToString, Integer) & "','popup_window','width=400,height=220,top=200,left=400,scrollbars=1');popup_window.focus()"
        End If
    End Sub

#End Region


End Class
