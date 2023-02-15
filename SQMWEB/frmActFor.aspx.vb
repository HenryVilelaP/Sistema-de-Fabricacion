
#Region "IMPORT"

Imports BLLSQM
Imports BELSQM
Imports System.Data

#End Region

Partial Class frmActFor

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oFabricacion As New BLLFabricacion
    Private oBELpro As New BELProducto
    Private oBELfab As New BELFabric
    'Private oPro As New BELProducto
    Private oFab As New BELFabric

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodpro.Focus()
        txtcodpro.Attributes.Add("READONLY", "readonly")
        TextBox1.Attributes.Add("READONLY", "readonly")
        TextBox2.Attributes.Add("READONLY", "readonly")
        TextBox4.Attributes.Add("READONLY", "readonly")
        TextBox5.Attributes.Add("READONLY", "readonly")
        TextBox7.Attributes.Add("READONLY", "readonly")
        TextBox8.Attributes.Add("READONLY", "readonly")
        TextBox10.Attributes.Add("READONLY", "readonly")
        TextBox11.Attributes.Add("READONLY", "readonly")

        txt21.Attributes.Add("OnBlur", "sumar1()")
        txt22.Attributes.Add("OnBlur", "sumar2()")
        txt23.Attributes.Add("OnBlur", "sumar3()")
        txt24.Attributes.Add("OnBlur", "sumar4()")
    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Try
            oBELpro.codigo = txtcodpro.Text
            Dim ds As New DataSet
            ds = oFabricacion.ConsProductoxcod(oBELpro)

            '-------------------------------------------------
            '-------------------------------------------------
            'BUSCA DEPENDIENDO EL NRO DE INSUMOS
            'HACE EL LLENADO DE DATOS
            '-------------------------------------------------
            '-------------------------------------------------
            Select Case ds.Tables(0).Rows.Count
                Case 4
                    'LLENA EL CODIGO DE LOS INSUMOS
                    TextBox1.Text = Trim(ds.Tables(0).Rows(0).Item(3).ToString())
                    TextBox4.Text = Trim(ds.Tables(0).Rows(1).Item(3).ToString())
                    TextBox7.Text = Trim(ds.Tables(0).Rows(2).Item(3).ToString())
                    TextBox10.Text = Trim(ds.Tables(0).Rows(3).Item(3).ToString())
                    'LLENA EL NOMBRE DE LOS INSUMOS
                    TextBox2.Text = ds.Tables(0).Rows(0).Item(4).ToString()
                    TextBox5.Text = ds.Tables(0).Rows(1).Item(4).ToString()
                    TextBox8.Text = ds.Tables(0).Rows(2).Item(4).ToString()
                    TextBox11.Text = ds.Tables(0).Rows(3).Item(4).ToString()
                    'LLENA LA CANTIDAD NECESARIA PARA LA FORMULA
                    txt21.Text = ds.Tables(0).Rows(0).Item(2).ToString()
                    txt22.Text = ds.Tables(0).Rows(1).Item(2).ToString()
                    txt23.Text = ds.Tables(0).Rows(2).Item(2).ToString()
                    txt24.Text = ds.Tables(0).Rows(3).Item(2).ToString()


                Case 3
                    'LLENA EL CODIGO DE LOS INSUMOS
                    TextBox1.Text = Trim(ds.Tables(0).Rows(0).Item(3).ToString())
                    TextBox4.Text = Trim(ds.Tables(0).Rows(1).Item(3).ToString())
                    TextBox7.Text = Trim(ds.Tables(0).Rows(2).Item(3).ToString())
                    TextBox10.Text = ""
                    'LLENA EL NOMBRE DE LOS INSUMOS
                    TextBox2.Text = ds.Tables(0).Rows(0).Item(4).ToString()
                    TextBox5.Text = ds.Tables(0).Rows(1).Item(4).ToString()
                    TextBox8.Text = ds.Tables(0).Rows(2).Item(4).ToString()
                    TextBox11.Text = ""
                    'LLENA LA CANTIDAD NECESARIA PARA LA FORMULA
                    txt21.Text = ds.Tables(0).Rows(0).Item(2).ToString()
                    txt22.Text = ds.Tables(0).Rows(1).Item(2).ToString()
                    txt23.Text = ds.Tables(0).Rows(2).Item(2).ToString()
                    txt24.Text = "0.000"

                Case 2
                    'LLENA EL CODIGO DE LOS INSUMOS
                    TextBox1.Text = Trim(ds.Tables(0).Rows(0).Item(3).ToString())
                    TextBox4.Text = Trim(ds.Tables(0).Rows(1).Item(3).ToString())
                    TextBox7.Text = ""
                    TextBox10.Text = ""
                    'LLENA EL NOMBRE DE LOS INSUMOS
                    TextBox2.Text = ds.Tables(0).Rows(0).Item(4).ToString()
                    TextBox5.Text = ds.Tables(0).Rows(1).Item(4).ToString()
                    TextBox8.Text = ""
                    TextBox11.Text = ""
                    'LLENA LA CANTIDAD NECESARIA PARA LA FORMULA
                    txt21.Text = ds.Tables(0).Rows(0).Item(2).ToString()
                    txt22.Text = ds.Tables(0).Rows(1).Item(2).ToString()
                    txt23.Text = "0.000"
                    txt24.Text = "0.000"

            End Select

            'PARA CASO DE BATCH = 1
            'txtcodpro.Text = ds.Tables(0).Rows(0).Item(0).ToString()
            'txtproducto.Text = ds.Tables(0).Rows(0).Item(1).ToString()
            Session.Item("cant1") = txt21.Text
            Session.Item("cant2") = txt22.Text
            Session.Item("cant3") = txt23.Text
            Session.Item("cant4") = txt24.Text

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnactualiza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnactualiza.Click
        Try
            Dim i, j As Integer
            Dim v1(4, 2) As String
            j = 1
            If Len(txtcodpro.Text) <> 0 Then
                If (valida1() = True) Then

                    If (validaDatos() = True) Then

                        v1(1, 1) = TextBox1.Text
                        v1(1, 2) = txt21.Text
                        v1(2, 1) = TextBox4.Text
                        v1(2, 2) = txt22.Text
                        v1(3, 1) = TextBox7.Text
                        v1(3, 2) = txt23.Text
                        v1(4, 1) = TextBox10.Text
                        v1(4, 2) = txt24.Text

                        oFab.codigof = txtcodpro.Text

                        'CASO PARA 2 INSUMOS
                        If TextBox10.Text = "" And TextBox7.Text = "" And TextBox4.Text <> "" And TextBox1.Text <> "" Then
                            If CStr(Decimal.Round(CDbl(IIf(txt21.Text = "", 0, txt21.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(txt22.Text = "", 0, txt22.Text)), 3, MidpointRounding.ToEven)) = 0 Then
                                lblmensaje.Text = "INGRESE PROPORCION"
                                lblmensaje.Visible = True
                            Else
                                If CStr(Decimal.Round((CDbl(CDbl(IIf(txt21.Text = "", 0, txt21.Text)) + CDbl(IIf(txt22.Text = "", 0, txt22.Text)))), 3, MidpointRounding.ToEven)) = 1 Then
                                    oFabricacion.EliminaFormula(oFab)
                                    For i = 1 To 2
                                        oFab.codins = v1(i, j)
                                        'oFab.cantidad = v1(i, j + 1)
                                        oFab.porcentaje = v1(i, j + 1)
                                        oFabricacion.formulas(oFab)
                                    Next
                                    lblmensaje.Text = "FORMULA ACTUALIZADA..."
                                    lblmensaje.Visible = True
                                    btnactualiza.Enabled = False
                                    LinkButton2.Enabled = False
                                Else
                                    lblmensaje.Text = "LA SUMA DE PROPORCION DEBE SER IGUAL A 1 ..."
                                    lblmensaje.Visible = True
                                End If
                            End If

                            'CASO PARA 3 INSUMOS
                        ElseIf TextBox10.Text = "" And TextBox7.Text <> "" And TextBox4.Text <> "" And TextBox1.Text <> "" Then
                            If CStr(Decimal.Round(CDbl(IIf(txt21.Text = "", 0, txt21.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(txt22.Text = "", 0, txt22.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(txt23.Text = "", 0, txt23.Text)), 3, MidpointRounding.ToEven)) = 0 Then
                                lblmensaje.Text = "INGRESE PROPORCION"
                                lblmensaje.Visible = True
                            Else
                                If CStr(Decimal.Round((CDbl(CDbl(IIf(txt21.Text = "", 0, txt21.Text)) + CDbl(IIf(txt22.Text = "", 0, txt22.Text)) + CDbl(IIf(txt23.Text = "", 0, txt23.Text)))), 3, MidpointRounding.ToEven)) = 1 Then
                                    oFabricacion.EliminaFormula(oFab)
                                    j = 1
                                    For i = 1 To 3
                                        oFab.codins = v1(i, j)
                                        'oFab.cantidad = v1(i, j + 1)
                                        oFab.porcentaje = v1(i, j + 1)
                                        oFabricacion.formulas(oFab)
                                    Next
                                    lblmensaje.Text = "FORMULA ACTUALIZADA..."
                                    lblmensaje.Visible = True
                                    btnactualiza.Enabled = False
                                    LinkButton2.Enabled = False
                                Else
                                    lblmensaje.Text = "LA SUMA DE PROPORCION DEBE SER IGUAL A 1 ..."
                                    lblmensaje.Visible = True
                                End If
                            End If

                            'CASO PARA 4 INSUMOS
                        ElseIf TextBox10.Text <> "" And TextBox7.Text <> "" And TextBox4.Text <> "" And TextBox1.Text <> "" Then
                            If CStr(Decimal.Round(CDbl(IIf(txt21.Text = "", 0, txt21.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(txt22.Text = "", 0, txt22.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(txt23.Text = "", 0, txt23.Text)), 3, MidpointRounding.ToEven)) = 0 Or CStr(Decimal.Round(CDbl(IIf(txt24.Text = "", 0, txt24.Text)), 3, MidpointRounding.ToEven)) = 0 Then
                                lblmensaje.Text = "INGRESE PROPORCION"
                                lblmensaje.Visible = True
                            Else
                                If CStr(Decimal.Round((CDbl(CDbl(IIf(txt21.Text = "", 0, txt21.Text)) + CDbl(IIf(txt22.Text = "", 0, txt22.Text)) + CDbl(IIf(txt23.Text = "", 0, txt23.Text)) + CDbl(IIf(txt24.Text = "", 0, txt24.Text)))), 3, MidpointRounding.ToEven)) = 1 Then
                                    oFabricacion.EliminaFormula(oFab)
                                    j = 1
                                    For i = 1 To 4
                                        oFab.codins = v1(i, j)
                                        'oFab.cantidad = v1(i, j + 1)
                                        oFab.porcentaje = v1(i, j + 1)
                                        oFabricacion.formulas(oFab)
                                    Next
                                    lblmensaje.Text = "FORMULA ACTUALIZADA..."
                                    lblmensaje.Visible = True
                                    btnactualiza.Enabled = False
                                    LinkButton2.Enabled = False
                                Else
                                    lblmensaje.Text = "LA SUMA DE PROPORCION DEBE SER IGUAL A 1 ..."
                                    lblmensaje.Visible = True
                                End If
                            End If

                        End If

                    Else
                        lblmensaje.Text = "INGRESE INGREDIENTES EN ORDEN"
                        lblmensaje.Visible = True
                    End If

                Else
                    lblmensaje.Text = "INGRESE INGREDIENTES..."
                    lblmensaje.Visible = True
                End If
            Else
                lblmensaje.Text = "INGRESE PRODUCTO..."
                lblmensaje.Visible = True
            End If
        Catch ex As Exception
            lblmensaje.Text = "ERROR COMUNIQUESE CON SISTEMAS..."
            lblmensaje.Visible = True
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
