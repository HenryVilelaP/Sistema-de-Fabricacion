
#Region "IMPORT"

Imports BLLSQM
Imports BELSQM
'Imports System.Data

#End Region

Partial Class frmDetalle

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oFabricacion As New BLLFabricacion
    Private oBlutil As New BLLUtilitario
    Private oFab As New BELFabric
    Private opro As New BELProducto
    Private oPers As New BEPersona

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Button1.Attributes.Add("onclick", "javascript:pop_seguridad();")
        Try
            If oFabricacion.ConsFabrica.Tables(0).Rows.Count = 0 Then
                Label2.Visible = True
                Label2.Text = "NO HAY PRODUCTOS FABRICADOS"
            Else
                grvfabrica.DataSource = oFabricacion.ConsFabrica
                grvfabrica.DataBind()

                Label3.Visible = False
                Label4.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub grvfabrica_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvfabrica.PageIndexChanging
        grvfabrica.PageIndex = e.NewPageIndex
        grvfabrica.DataSource = oFabricacion.ConsFabrica
        grvfabrica.DataBind()
    End Sub

    Protected Sub grvfabrica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvfabrica.SelectedIndexChanged
        lblmens.Text = ""
        oFab.codfab = CInt(grvfabrica.SelectedRow.Cells(1).Text)
        grvcabbatch.DataSource = oFabricacion.Consbatch(oFab)
        grvcabbatch.DataBind()
        grvcabbatch.Visible = True
        grvbatch.Visible = False
        Label3.Visible = True
        Label4.Visible = False
        oFab.fecha = grvfabrica.SelectedRow.Cells(2).Text
        Session.Item("coigop") = grvfabrica.SelectedRow.Cells(3).Text
        Session.Item("codfab") = grvfabrica.SelectedRow.Cells(1).Text

        Button1.Enabled = False
        Button1.Visible = False
        btnvalida.Visible = False
        txtcodigo.Visible = False


    End Sub

    Protected Sub grvcabbatch_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvcabbatch.PageIndexChanging
        grvcabbatch.PageIndex = e.NewPageIndex
        grvcabbatch.DataSource = oFabricacion.Consbatch(oFab)
        grvcabbatch.DataBind()
    End Sub

    Protected Sub grvcabbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvcabbatch.SelectedIndexChanged
        lblmens.Text = ""
        oFab.codfab = CInt(grvcabbatch.SelectedRow.Cells(1).Text)
        oFab.idbatch = CInt(grvcabbatch.SelectedRow.Cells(2).Text)
        oFab.codigof = grvcabbatch.SelectedRow.Cells(3).Text
        oFab.cantidadp = CInt(grvcabbatch.SelectedRow.Cells(4).Text)
        oFab.base = CDbl(grvcabbatch.SelectedRow.Cells(9).Text)
        grvbatch.DataSource = oFabricacion.ConsDbatch(oFab)
        grvbatch.DataBind()
        grvbatch.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Session.Item("codfab") = grvcabbatch.SelectedRow.Cells(1).Text
        Session.Item("idbatch") = grvcabbatch.SelectedRow.Cells(2).Text
        Session.Item("base") = grvcabbatch.SelectedRow.Cells(9).Text
        Session.Item("oFabricacion") = oFab
        If grvcabbatch.SelectedRow.Cells(8).Text = "FABRICADO" Or grvcabbatch.SelectedRow.Cells(8).Text = "ANULADO" Then
            Button1.Enabled = False
            Button1.Visible = False
            btnvalida.Visible = False
            txtcodigo.Visible = False
        Else
            Button1.Enabled = False
            Button1.Visible = False
            btnvalida.Visible = True
            txtcodigo.Visible = True
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            oFab.fecha = Date.Today
            oFab.codfab = Session.Item("codfab")
            oFab.idbatch = Session.Item("idbatch")
            oFab.codigof = Session.Item("coigop")
            oFab.base = Session.Item("base")
            oFab = Session.Item("oFabricacion")
            oPers = Session.Item("Usuario")
            oFabricacion.ProcesoKardex(oFab)
            grvcabbatch.DataSource = oFabricacion.Consbatch(oFab)
            grvcabbatch.DataBind()
            grvfabrica.DataSource = oFabricacion.ConsFabrica
            grvfabrica.DataBind()
            grvbatch.DataSource = oFabricacion.ConsDbatch(oFab)
            grvbatch.DataBind()
            lblmens.Text = "BATCH FABRICADO"
            lblmens.Visible = True
            Button1.Enabled = False
            Button1.Visible = False
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    Protected Sub btnvalida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnvalida.Click
        Dim oFabricacion As New BLLFabricacion
        Dim oBELusuario As New BEPersona
        oPers = Session.Item("Usuario")
        Label3.Visible = True
        Try
            If oPers Is Nothing Then
                lblmens.Visible = True
                lblmens.Text = "CIERRE SESION Y VUELVA A INICIAR SESION"
            Else
                If txtcodigo.Text <> "" And txtcodigo.Text = oPers.Security Then
                    Button1.Visible = True
                    Button1.Enabled = True
                    Button1.Focus()
                    btnvalida.Visible = False
                    lblmens.Visible = False
                    lblmens.Visible = False
                    btnvalida.Visible = False
                    txtcodigo.Visible = False
                Else
                    lblmens.Visible = True
                    lblmens.Text = "CLAVE INCORRECTA"
                    Button1.Visible = False
                    Button1.Enabled = False
                    btnvalida.Visible = True
                    txtcodigo.Visible = True
                End If
            End If
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

#End Region

End Class
