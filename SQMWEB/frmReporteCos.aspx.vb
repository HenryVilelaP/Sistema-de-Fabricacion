
#Region "IMPORT"

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions
Imports BLLSQM
Imports BELSQM

#End Region

Partial Class frmReporteCos

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private ofabricacion As New BLLFabricacion

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodfabp.Focus()
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub btnbusca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbusca.Click
        Dim val2 As String
        CrystalReportViewer2.Visible = True
        Label2.Text = ""
        Try

            Dim oFab As New BELFabric
            oFab.codfab = txtcodfabp.Text.Trim

            If txtcodfabp.Text.Trim <> "" Then

                val2 = ofabricacion.ValidaAnulacion(oFab)
                If val2 <> "CODIGO NO EXISTE" Then

                    Dim ConnInfo As New [Shared].ConnectionInfo
                    With ConnInfo
                        .ServerName = "localhost"
                        .DatabaseName = "sqmdata"
                        .UserID = "sqmweb"
                        .Password = "sqmw3b"
                    End With

                    CrystalReportViewer2.ReportSource = Server.MapPath("Reportes\rptReporteCost.rpt")
                    Dim ParamFields As [Shared].ParameterFields = CrystalReportViewer2.ParameterFieldInfo
                    Dim p_CodFab As New [Shared].ParameterField
                    p_CodFab.Name = "codfabpx"
                    Dim p_CodFab_Value As New [Shared].ParameterDiscreteValue
                    p_CodFab_Value.Value = txtcodfabp.Text
                    p_CodFab.CurrentValues.Add(p_CodFab_Value)
                    ParamFields.Add(p_CodFab)
                    For Each cnInfo As [Shared].TableLogOnInfo In Me.CrystalReportViewer2.LogOnInfo
                        cnInfo.ConnectionInfo = ConnInfo
                    Next
                    CrystalReportViewer2.RefreshReport()

                Else
                    CrystalReportViewer2.Visible = False
                    Label2.Text = "CODIGO NO EXISTE"
                End If

            Else
                CrystalReportViewer2.Visible = False
                Label2.Text = "INGRESE EL CODIGO"
            End If
            txtcodfabp.Text = ""
            oFab.codfab = ""

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class
