
#Region "IMPORT"

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions
Imports BLLSQM
Imports BELSQM

#End Region

Partial Class Reportes_frmReporteFab

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private ofabricacion As New BLLFabricacion

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodfab.Focus()
        txtcodfab.Attributes.Add("onkeypress", "Funcion_Numeros() ;")
        Dim oFab As New BELFabric
        oFab.codfab = ""
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub btnbusca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbusca.Click

        Dim val1 As String
        CrystalReportViewer1.Visible = True
        Label2.Text = ""
        Try

            Dim oFab As New BELFabric
            oFab.codfab = txtcodfab.Text.Trim

            If txtcodfab.Text.Trim <> "" Then

                val1 = ofabricacion.ValidaAnulacion(oFab)
                If val1 <> "CODIGO NO EXISTE" Then
                       Dim ConnInfo As New [Shared].ConnectionInfo
                    With ConnInfo
                        .ServerName = "192.168.1.179"
                        .DatabaseName = "sqmdata"
                        .UserID = "sqmweb"
                        .Password = "sqmw3b"
                    End With
                    Dim OBll As New BLLFabricacion

                    'Dim nrofilas As Integer = OBll.ConsFilaDBatch(oFab)
                    'Select nrofilas
                    'Case 1
                    'CrystalReportViewer1.ReportSource = Server.MapPath("Reportes\rptReporteFab1.rpt")
                    'Case Is <= 8
                    'CrystalReportViewer1.ReportSource = Server.MapPath("Reportes\rptReporteFab2.rpt")
                    CrystalReportViewer1.ReportSource = Server.MapPath("Reportes\rptReporteFabX.rpt")
                    'Case Is >= 9
                    'CrystalReportViewer1.ReportSource = Server.MapPath("Reportes\rptReporteFab3.rpt")
                    'CrystalReportViewer1.ReportSource = Server.MapPath("Reportes\rptReporteFabY.rpt")
                    'Case 4
                    'CrystalReportViewer1.ReportSource = Server.MapPath("Reportes\rptReporteFab4.rpt")
                    'End Select


                    Dim ParamFields As [Shared].ParameterFields = CrystalReportViewer1.ParameterFieldInfo
                    Dim p_CodFab As New [Shared].ParameterField
                    p_CodFab.Name = "codfabx"
                    Dim p_CodFab_Value As New [Shared].ParameterDiscreteValue
                    p_CodFab_Value.Value = txtcodfab.Text
                    p_CodFab.CurrentValues.Add(p_CodFab_Value)
                    ParamFields.Add(p_CodFab)
                    For Each cnInfo As [Shared].TableLogOnInfo In Me.CrystalReportViewer1.LogOnInfo
                        cnInfo.ConnectionInfo = ConnInfo
                    Next
                    CrystalReportViewer1.RefreshReport()
                Else
                    CrystalReportViewer1.Visible = False
                    Label2.Text = "CODIGO NO EXISTE"
                End If

            Else
                CrystalReportViewer1.Visible = False
                Label2.Text = "INGRESE EL CODIGO"
            End If
            txtcodfab.Text = ""
            oFab.codfab = ""
        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class
