
#Region "IMPORT"

Imports BLLSQM
Imports BELSQM

#End Region

Partial Class frmAnula

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private ofabricacion As New BLLFabricacion
    Private ofab As New BELFabric

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodfab.Focus()
        txtcodfab.Attributes.Add("onkeypress", "Funcion_Numeros() ;")
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub btnanula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnanula.Click
        Dim val As String
        ofab.codfab = txtcodfab.Text.Trim
        Label2.Text = ""
        If txtcodfab.Text.Trim <> "" Then
            val = ofabricacion.ValidaAnulacion(ofab)
            If val <> "CODIGO NO EXISTE" Then
                If val <> "FABRICADO" And val <> "ANULADO" Then
                    If val = Nothing Then
                        If CInt(txtcodfab.Text.Trim) > 0 Then
                            ofabricacion.ActuaFBD(ofab)
                            ofabricacion.AnulaReserva(ofab)
                            Label2.Text = "ANULADO CORRECTAMENTE"
                        End If
                    End If
                Else
                    If val = "ANULADO" Then
                        Label2.Text = "NO SE ANULO, EL PRODUCTO ESTA" + " " + val
                    ElseIf val = "FABRICADO" Then
                        Label2.Text = "NO SE ANULO, EL PRODUCTO Y/O UNO DE SUS BATCH ESTA" + " " + val
                    End If
                End If
            Else
                Label2.Text = "CODIGO NO EXISTE"
            End If
        Else
            Label2.Text = "INGRESE EL CODIGO"
        End If
        txtcodfab.Text = ""

    End Sub

#End Region

End Class
