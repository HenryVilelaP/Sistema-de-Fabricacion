
#Region "IMPORT"

Imports BLLSQM
Imports BELSQM

#End Region

Partial Class frmAgrFor

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oPro As New BELProducto
    Private oFab As New BELFabric
    Private oFabricacion As New BLLFabricacion

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtnombre.Focus()
        txtcod.Visible = True
        txtcod.Attributes.Add("READONLY", "readonly")
        TextBox1.Attributes.Add("READONLY", "readonly")
        TextBox2.Attributes.Add("READONLY", "readonly")
        TextBox4.Attributes.Add("READONLY", "readonly")
        TextBox5.Attributes.Add("READONLY", "readonly")
        TextBox7.Attributes.Add("READONLY", "readonly")
        TextBox8.Attributes.Add("READONLY", "readonly")
        TextBox10.Attributes.Add("READONLY", "readonly")
        TextBox11.Attributes.Add("READONLY", "readonly")

        TextBox3.Attributes.Add("OnBlur", "sumar1()")
        TextBox6.Attributes.Add("OnBlur", "sumar2()")
        TextBox9.Attributes.Add("OnBlur", "sumar3()")
        TextBox12.Attributes.Add("OnBlur", "sumar4()")
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub lnkbusca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbusca.Click
        Dim ds01 As New Data.DataSet
        Try
            Label4.Text = ""
            Label4.Visible = False
            If btngraba.Enabled = True Then
                oPro.nombre = txtnombre.Text
                ds01 = oFabricacion.ConsProductoxcodnoIngresado(oPro)
                If ds01.Tables(0).Rows.Count() = 0 Then
                    Label4.Text = "El Producto no existe o ya se encuentra fabricado"
                    Label4.Visible = True
                End If
                grvproductos.DataSource = ds01
                grvproductos.DataBind()
                txtnombre.Width = 210
                txtcod.Width = 50
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grvproductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvproductos.SelectedIndexChanged
        txtnombre.Text = grvproductos.SelectedRow.Cells(2).Text
        txtcod.Text = grvproductos.SelectedRow.Cells(1).Text
        txtcod.Visible = True
        txtnombre.BorderWidth = 0
        ' txtnombre.Width = 230
        grvproductos.Visible = False
    End Sub

    Protected Sub btngraba_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngraba.Click
        Try
            Dim i, j As Integer
            Dim v1(4, 2) As String
            j = 1

            Label2.Text = ""
            Label2.Visible = False

            If Len(txtcod.Text) <> 0 Then
                If (valida1() = True) Then

                    If (validaDatos() = True) Then

                        oFab.codigof = txtcod.Text

                        v1(1, 1) = TextBox1.Text
                        v1(1, 2) = TextBox3.Text
                        v1(2, 1) = TextBox4.Text
                        v1(2, 2) = TextBox6.Text
                        v1(3, 1) = TextBox7.Text
                        v1(3, 2) = TextBox9.Text
                        v1(4, 1) = TextBox10.Text
                        v1(4, 2) = TextBox12.Text

                        'CASO PARA 2 INSUMOS
                        If TextBox10.Text = "" And TextBox7.Text = "" And TextBox4.Text <> "" And TextBox1.Text <> "" Then
                            If CStr(Decimal.Round(CDbl(IIf(TextBox3.Text = "", 0, TextBox3.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(TextBox6.Text = "", 0, TextBox6.Text)), 3, MidpointRounding.ToEven)) = 0 Then
                                Label2.Text = "INGRESE PROPORCION"
                                Label2.Visible = True
                            Else
                                If CStr(Decimal.Round((CDbl(CDbl(IIf(TextBox3.Text = "", 0, TextBox3.Text)) + CDbl(IIf(TextBox6.Text = "", 0, TextBox6.Text)))), 3, MidpointRounding.ToEven)) = 1 Then
                                    For i = 1 To 2
                                        oFab.codins = v1(i, j)
                                        'oFab.cantidad = v1(i, j + 1)
                                        oFab.porcentaje = v1(i, j + 1)
                                        oFabricacion.formulas(oFab)
                                    Next
                                    Label2.Text = "FORMULA GRABADA..."
                                    Label2.Visible = True
                                    btngraba.Enabled = False
                                Else
                                    Label2.Text = "LA SUMA DE PROPORCION DEBE SER IGUAL A 1 ..."
                                    Label2.Visible = True
                                End If
                            End If

                            'CASO PARA 3 INSUMOS
                        ElseIf TextBox10.Text = "" And TextBox7.Text <> "" And TextBox4.Text <> "" And TextBox1.Text <> "" Then
                            If CStr(Decimal.Round(CDbl(IIf(TextBox3.Text = "", 0, TextBox3.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(TextBox6.Text = "", 0, TextBox6.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(TextBox9.Text = "", 0, TextBox9.Text)), 3, MidpointRounding.ToEven)) = 0 Then
                                Label2.Text = "INGRESE PROPORCION"
                                Label2.Visible = True
                            Else
                                If CStr(Decimal.Round((CDbl(CDbl(IIf(TextBox3.Text = "", 0, TextBox3.Text)) + CDbl(IIf(TextBox6.Text = "", 0, TextBox6.Text)) + CDbl(IIf(TextBox9.Text = "", 0, TextBox9.Text)))), 3, MidpointRounding.ToEven)) = 1 Then
                                    j = 1
                                    For i = 1 To 3
                                        oFab.codins = v1(i, j)
                                        'oFab.cantidad = v1(i, j + 1)
                                        oFab.porcentaje = v1(i, j + 1)
                                        oFabricacion.formulas(oFab)
                                    Next
                                    Label2.Text = "FORMULA GRABADA..."
                                    Label2.Visible = True
                                    btngraba.Enabled = False
                                Else
                                    Label2.Text = "LA SUMA DE PROPORCION DEBE SER IGUAL A 1 ..."
                                    Label2.Visible = True
                                End If
                            End If

                            'CASO PARA 4 INSUMOS
                        ElseIf TextBox10.Text <> "" And TextBox7.Text <> "" And TextBox4.Text <> "" And TextBox1.Text <> "" Then
                            If CStr(Decimal.Round(CDbl(IIf(TextBox3.Text = "", 0, TextBox3.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(TextBox6.Text = "", 0, TextBox6.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(TextBox9.Text = "", 0, TextBox9.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(TextBox12.Text = "", 0, TextBox12.Text)), 3, MidpointRounding.ToEven)) = 0 Then
                                Label2.Text = "INGRESE PROPORCION"
                                Label2.Visible = True
                            Else
                                If CStr(Decimal.Round((CDbl(CDbl(IIf(TextBox3.Text = "", 0, TextBox3.Text)) + CDbl(IIf(TextBox6.Text = "", 0, TextBox6.Text)) + CDbl(IIf(TextBox9.Text = "", 0, TextBox9.Text)) + CDbl(IIf(TextBox12.Text = "", 0, TextBox12.Text)))), 3, MidpointRounding.ToEven)) = 1 Then
                                    j = 1
                                    For i = 1 To 4
                                        oFab.codins = v1(i, j)
                                        'oFab.cantidad = v1(i, j + 1)
                                        oFab.porcentaje = v1(i, j + 1)
                                        oFabricacion.formulas(oFab)
                                    Next
                                    Label2.Text = "FORMULA GRABADA..."
                                    Label2.Visible = True
                                    btngraba.Enabled = False
                                Else
                                    Label2.Text = "LA SUMA DE PROPORCION DEBE SER IGUAL A 1 ..."
                                    Label2.Visible = True
                                End If
                            End If

                        End If

                    Else
                        Label2.Text = "INGRESE INGREDIENTES EN ORDEN"
                        Label2.Visible = True
                    End If

                Else
                    Label2.Text = "INGRESE INGREDIENTES..."
                    Label2.Visible = True
                End If
            Else
                Label2.Text = "INGRESE PRODUCTO..."
                Label2.Visible = True
            End If
        Catch ex As Exception
            'Label2.Text = "INGRESE LA FORMULA..."
            Label2.Text = "ERROR COMUNIQUESE CON SISTEMAS..."
            Label2.Visible = True
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function valida1() As Boolean
        If TextBox1.Text <> "" And TextBox4.Text = "" And TextBox7.Text = "" And TextBox10.Text = "" Then
            valida1 = False
        ElseIf TextBox1.Text = "" And TextBox4.Text = "" And TextBox7.Text = "" And TextBox10.Text = "" Then
            valida1 = False
        Else
            valida1 = True
        End If
    End Function

    Private Function validaDatos() As Boolean

        If TextBox1.Text = "" And TextBox4.Text <> "" And TextBox7.Text = "" And TextBox10.Text = "" Then
            validaDatos = False
        ElseIf TextBox1.Text = "" And TextBox4.Text = "" And TextBox7.Text <> "" And TextBox10.Text = "" Then
            validaDatos = False
        ElseIf TextBox1.Text = "" And TextBox4.Text = "" And TextBox7.Text = "" And TextBox10.Text <> "" Then
            validaDatos = False

        ElseIf TextBox1.Text <> "" And TextBox4.Text = "" And TextBox7.Text <> "" And TextBox10.Text = "" Then
            validaDatos = False
        ElseIf TextBox1.Text <> "" And TextBox4.Text = "" And TextBox7.Text = "" And TextBox10.Text <> "" Then
            validaDatos = False

        ElseIf TextBox1.Text = "" And TextBox4.Text <> "" And TextBox7.Text <> "" And TextBox10.Text = "" Then
            validaDatos = False
        ElseIf TextBox1.Text = "" And TextBox4.Text <> "" And TextBox7.Text = "" And TextBox10.Text <> "" Then
            validaDatos = False

        ElseIf TextBox1.Text = "" And TextBox4.Text = "" And TextBox7.Text <> "" And TextBox10.Text <> "" Then
            validaDatos = False

        ElseIf TextBox1.Text <> "" And TextBox4.Text <> "" And TextBox7.Text = "" And TextBox10.Text <> "" Then
            validaDatos = False
        ElseIf TextBox1.Text = "" And TextBox4.Text <> "" And TextBox7.Text <> "" And TextBox10.Text <> "" Then
            validaDatos = False


        Else
            validaDatos = True
        End If
    End Function

#End Region

End Class
