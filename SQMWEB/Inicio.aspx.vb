
#Region "IMPORT"

Imports BLLSQM
Imports BELSQM
Imports System.Data
Imports System.Math

#End Region

Partial Class Inicio

#Region "DECLARACION"

    Inherits System.Web.UI.Page
    Private oFabricacion As New BLLFabricacion
    Private oBELpro As New BELProducto
    Private oBELfab As New BELFabric
    Private ofabaux As New BELFabric

#End Region

#Region "FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ds As New DataSet
            Dim codfab As Double

            txtfecha.Text = Date.Today.ToString
            txtcodpro.Attributes.Add("READONLY", "readonly")
            txtorfa.Attributes.Add("READONLY", "readonly")
            txtnrobacth.Attributes.Add("READONLY", "readonly")
            txtfecha.Attributes.Add("READONLY", "readonly")
            txtcant.Attributes.Add("READONLY", "readonly")
            txtorg1.Attributes.Add("READONLY", "readonly")
            txtorg2.Attributes.Add("READONLY", "readonly")
            txtorg3.Attributes.Add("READONLY", "readonly")
            txtorg4.Attributes.Add("READONLY", "readonly")

            txtlot1.Attributes.Add("READONLY", "readonly")
            txtlot2.Attributes.Add("READONLY", "readonly")
            txtlot3.Attributes.Add("READONLY", "readonly")
            txtlot4.Attributes.Add("READONLY", "readonly")

            txtcodpro.Focus()
            codfab = oFabricacion.ConsMaxCod
            txtorfa.Text = codfab

            If Not IsPostBack Then
                If oFabricacion.ConsBase_mezcla.Tables(0).Rows.Count <> 0 Then
                    ds = oFabricacion.ConsBase_mezcla()
                    grvBase.DataSource = ds
                    grvBase.DataBind()
                End If

                Dim table As DataTable = New DataTable
                Dim row As DataRow = table.NewRow()
                table.Rows.Add(row)
                grvBase1.DataSource = table
                grvBase1.DataBind()
            End If

            If CheckBox1.Checked = True Then
                grvBase1.Visible = True
            ElseIf CheckBox1.Checked = False Then
                grvBase.Visible = True
            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region "CONTROLES"

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Limpiar()
        Try
            If Len(txtcodpro.Text) = 0 Then
            Else
                If txtcant.Text = "" Or txtcant.Text = "0" Then
                Else
                    oBELpro.codigo = txtcodpro.Text
                    Dim ds As New DataSet
                    ds = oFabricacion.ConsProductoxcod(oBELpro)

                    'BUSCA DEPENDIENDO EL NRO DE INSUMOS
                    'HACE EL LLENADO DE DATOS
                    '-------------------------------------------------
                    Select Case ds.Tables(0).Rows.Count
                        Case 4
                            'LLENA EL CODIGO DE LOS INSUMOS
                            Label8.Text = Trim(ds.Tables(0).Rows(0).Item(3).ToString())
                            Label13.Text = Trim(ds.Tables(0).Rows(1).Item(3).ToString())
                            Label17.Text = Trim(ds.Tables(0).Rows(2).Item(3).ToString())
                            Label18.Text = Trim(ds.Tables(0).Rows(3).Item(3).ToString())
                            'LLENA EL NOMBRE DE LOS INSUMOS
                            Label9.Text = ds.Tables(0).Rows(0).Item(4).ToString()
                            Label14.Text = ds.Tables(0).Rows(1).Item(4).ToString()
                            Label19.Text = ds.Tables(0).Rows(2).Item(4).ToString()
                            Label20.Text = ds.Tables(0).Rows(3).Item(4).ToString()
                            'LLENA LA CANTIDAD NECESARIA PARA LA FORMULA
                            txt21.Text = ds.Tables(0).Rows(0).Item(2).ToString()
                            txt22.Text = ds.Tables(0).Rows(1).Item(2).ToString()
                            txt23.Text = ds.Tables(0).Rows(2).Item(2).ToString()
                            txt24.Text = ds.Tables(0).Rows(3).Item(2).ToString()
                            'LLENA LA RESERVA NECESARIA DEL CASO
                            Label27.Text = Round(CDbl(txt21.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)
                            Label28.Text = Round(CDbl(txt22.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)
                            Label29.Text = Round(CDbl(txt23.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)
                            Label30.Text = Round(CDbl(txt24.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)

                        Case 3
                            'LLENA EL CODIGO DE LOS INSUMOS
                            Label8.Text = Trim(ds.Tables(0).Rows(0).Item(3).ToString())
                            Label13.Text = Trim(ds.Tables(0).Rows(1).Item(3).ToString())
                            Label17.Text = Trim(ds.Tables(0).Rows(2).Item(3).ToString())
                            'LLENA EL NOMBRE DE LOS INSUMOS
                            Label9.Text = ds.Tables(0).Rows(0).Item(4).ToString()
                            Label14.Text = ds.Tables(0).Rows(1).Item(4).ToString()
                            Label19.Text = ds.Tables(0).Rows(2).Item(4).ToString()
                            'LLENA LA CANTIDAD NECESARIA PARA LA FORMULA
                            txt21.Text = ds.Tables(0).Rows(0).Item(2).ToString()
                            txt22.Text = ds.Tables(0).Rows(1).Item(2).ToString()
                            txt23.Text = ds.Tables(0).Rows(2).Item(2).ToString()
                            'LLENA LA RESERVA NECESARIA DEL CASO
                            Label27.Text = Round(CDbl(txt21.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)
                            Label28.Text = Round(CDbl(txt22.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)
                            Label29.Text = Round(CDbl(txt23.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)

                        Case 2
                            'LLENA EL CODIGO DE LOS INSUMOS
                            Label8.Text = Trim(ds.Tables(0).Rows(0).Item(3).ToString())
                            Label13.Text = Trim(ds.Tables(0).Rows(1).Item(3).ToString())
                            'LLENA EL NOMBRE DE LOS INSUMOS
                            Label9.Text = ds.Tables(0).Rows(0).Item(4).ToString()
                            Label14.Text = ds.Tables(0).Rows(1).Item(4).ToString()
                            'LLENA LA CANTIDAD NECESARIA PARA LA FORMULA  ---- **** 
                            txt21.Text = ds.Tables(0).Rows(0).Item(2).ToString()
                            txt22.Text = ds.Tables(0).Rows(1).Item(2).ToString()
                            'LLENA LA RESERVA NECESARIA DEL CASO
                            'Label27.Text = CDbl(txt21.Text) * CDbl(txtnrobacth.Text)
                            'Label28.Text = CDbl(txt22.Text) * CDbl(txtnrobacth.Text)
                            Label27.Text = Round(CDbl(txt21.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)
                            Label28.Text = Round(CDbl(txt22.Text) * CDbl(txtcant.Text), 3, MidpointRounding.AwayFromZero)

                    End Select

                    txtcodpro.Text = ds.Tables(0).Rows(0).Item(0).ToString()
                    txtproducto.Text = ds.Tables(0).Rows(0).Item(1).ToString()
                    Session.Item("cod1") = Label8.Text
                    Session.Item("cod2") = Label13.Text
                    Session.Item("cod3") = Label17.Text
                    Session.Item("cod4") = Label18.Text
                    Session.Item("cant1") = txt21.Text
                    Session.Item("cant2") = txt22.Text
                    Session.Item("cant3") = txt23.Text
                    Session.Item("cant4") = txt24.Text
                    Session.Item("nrobatch") = txtnrobacth.Text
                    Session.Item("reserva1") = Label27.Text
                    Session.Item("reserva2") = Label28.Text
                    Session.Item("reserva3") = Label29.Text
                    Session.Item("reserva4") = Label30.Text

                    Dim btn_Calcular As Button = If(CheckBox1.Checked = False, TryCast(grvBase.FooterRow.FindControl("btnCalcular"), Button), TryCast(grvBase1.FooterRow.FindControl("btnCalcular0"), Button))
                    btn_Calcular.Enabled = False

                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btngraba_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngraba.Click
        Dim a1 As Double = 0
        Dim a2 As Double = 0
        Dim a3 As Double = 0
        Dim a4 As Double = 0
        Dim a5 As Double = 0
        Dim a11 As Double = 0
        Dim ab1 As Double = 0
        Dim check As Boolean
        check = CheckBox1.Checked
        For Each row As GridViewRow In If(check = False, grvBase.Rows, grvBase1.Rows)
            'cantidad de base
            Dim txt_f As TextBox = If(check = False, TryCast(row.FindControl("cant1"), TextBox), TryCast(row.FindControl("cant2"), TextBox))
            a11 = CDbl(txt_f.Text).ToString
            If a11 > 0 Then
                If check = False Then
                    Dim txt_base As Label = TryCast(row.FindControl("Label10"), Label)   '   chekear
                    ab1 = ab1 + CDbl(txt_base.Text).ToString  ' suma de base
                ElseIf check = True Then
                    Dim txt_base As TextBox = TryCast(row.FindControl("base2"), TextBox)   '   chekear
                    ab1 = ab1 + CDbl(txt_base.Text).ToString  ' suma de base
                End If
            End If
        Next



        '-----GRABA EN LA TABLA FABRICA
        Try
            lblmensaje.Text = ""
            'VERIFICAMOS QUE LOS CAMPOS ESTEN LLENOS
            If validaDatos() Then

                For Each row As GridViewRow In If(check = False, grvBase.Rows, grvBase1.Rows)

                    'cantidad a fabricar
                    Dim txt_fab As TextBox = If(check = False, TryCast(row.FindControl("cant1"), TextBox), TryCast(row.FindControl("cant2"), TextBox))
                    a1 = CDbl(txt_fab.Text).ToString

                    If a1 > 0 Then
                        If check = False Then
                            'cantidad de base
                            Dim txt_base As Label = TryCast(row.FindControl("Label10"), Label)
                            a4 = CDbl(txt_base.Text).ToString
                        ElseIf check = True Then
                            Dim txt_base As TextBox = TryCast(row.FindControl("base2"), TextBox)
                            a4 = CDbl(txt_base.Text).ToString
                        End If
                        'cantidad de batch
                        Dim txt_batch As Label = If(check = False, TryCast(row.FindControl("Label1"), Label), TryCast(row.FindControl("Label32"), Label))
                        a2 = CDbl(txt_batch.Text).ToString


                        With oBELfab
                            .codfab = txtorfa.Text
                            .codigof = txtcodpro.Text
                            .fecha = CDate(txtfecha.Text)
                            .numbatch = CInt(txtnrobacth.Text)
                            .estado = "EN PROCESO"
                        End With

                        '-----------------------------------

                        oBELpro.codigo = txtcodpro.Text
                        Dim ds As New DataSet
                        Dim cantidadinsumos As Integer
                        Dim i As Integer

                        'ELEJIREMOS EL CASO DEPENDIENDO LA CANTIDAD DE INSUMOS
                        ds = oFabricacion.ConsProductoxcod(oBELpro)
                        cantidadinsumos = ds.Tables(0).Rows.Count
                        Select Case cantidadinsumos

                            Case 4
                                'SI SON 4 INSUMOS
                                ofabaux = Session.Item("codlote1")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                oBELfab.base = a4
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg1.Text
                                    oBELfab.lotefab = txtlot1.Text
                                    oBELfab.greserva = Label27.Text
                                    oBELfab.cantidadp = Round(CDbl(txt21.Text) * a4, 3)
                                    oBELfab.codins = Label8.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label27.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)

                                ofabaux = Session.Item("codlote2")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg2.Text
                                    oBELfab.lotefab = txtlot2.Text
                                    oBELfab.greserva = Label28.Text
                                    oBELfab.cantidadp = Round(CDbl(txt22.Text) * a4, 3)
                                    oBELfab.codins = Label13.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label28.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)

                                ofabaux = Session.Item("codlote3")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg3.Text
                                    oBELfab.lotefab = txtlot3.Text
                                    oBELfab.greserva = Label29.Text
                                    oBELfab.cantidadp = Round(CDbl(txt23.Text) * a4, 3)
                                    oBELfab.codins = Label17.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label29.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)

                                ofabaux = Session.Item("codlote4")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg4.Text
                                    oBELfab.lotefab = txtlot4.Text
                                    oBELfab.greserva = Label30.Text
                                    oBELfab.cantidadp = Round(CDbl(txt24.Text) * a4, 3)
                                    oBELfab.codins = Label18.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label30.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)
                                oBELfab.tbatch = Round((CDbl(txt21.Text) * a4) + (CDbl(txt22.Text) * a4) + (CDbl(txt23.Text) * a4) + (CDbl(txt24.Text) * a4), 3)
                                oBELfab.cantidad = Round(CDbl(Label27.Text) + CDbl(Label28.Text) + CDbl(Label29.Text) + CDbl(Label30.Text), 3)

                            Case 3
                                'SI SON 3 INSUMOS
                                ofabaux = Session.Item("codlote1")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                oBELfab.base = a4
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg1.Text
                                    oBELfab.lotefab = txtlot1.Text
                                    oBELfab.greserva = Label27.Text
                                    oBELfab.cantidadp = Round(CDbl(txt21.Text) * a4, 3)
                                    oBELfab.codins = Label8.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label27.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)

                                ofabaux = Session.Item("codlote2")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg2.Text
                                    oBELfab.lotefab = txtlot2.Text
                                    oBELfab.greserva = Label28.Text
                                    oBELfab.cantidadp = Round(CDbl(txt22.Text) * a4, 3)
                                    oBELfab.codins = Label13.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label28.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)

                                ofabaux = Session.Item("codlote3")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg3.Text
                                    oBELfab.lotefab = txtlot3.Text
                                    oBELfab.greserva = Label29.Text
                                    oBELfab.cantidadp = Round(CDbl(txt23.Text) * a4, 3)
                                    oBELfab.codins = Label17.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label29.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)
                                oBELfab.tbatch = Round((CDbl(txt21.Text) * a4) + (CDbl(txt22.Text) * a4) + (CDbl(txt23.Text) * a4), 3)
                                oBELfab.cantidad = Round(CDbl(Label27.Text) + CDbl(Label28.Text) + CDbl(Label29.Text), 3)

                            Case 2
                                'SI SON 2 INSUMOS
                                'GRABAR EN DBATCH
                                ofabaux = Session.Item("codlote1")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                oBELfab.base = a4
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg1.Text
                                    oBELfab.lotefab = txtlot1.Text
                                    oBELfab.greserva = Label27.Text
                                    oBELfab.cantidadp = Round(CDbl(txt21.Text) * a4, 3)
                                    oBELfab.codins = Label8.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label27.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)

                                ofabaux = Session.Item("codlote2")
                                oBELfab.idlote = ofabaux.idlote
                                oBELfab.costo = ofabaux.costo
                                For i = 1 To CInt(a2)
                                    'GRABAR EN DBATCH
                                    oBELfab.idbatch = i
                                    oBELfab.origen = txtorg2.Text
                                    oBELfab.lotefab = txtlot2.Text
                                    oBELfab.greserva = Label28.Text
                                    oBELfab.cantidadp = Round(CDbl(txt22.Text) * a4, 3)
                                    oBELfab.codins = Label13.Text
                                    oFabricacion.Dbatch(oBELfab)
                                Next
                                oBELfab.greserva = Round(CDbl(Label28.Text) * (a4 / ab1), 3)
                                oFabricacion.Actuavtalotes(oBELfab)
                                oBELfab.tbatch = Round((CDbl(txt21.Text) * a4) + (CDbl(txt22.Text) * a4), 3)
                                oBELfab.cantidad = Round(CDbl(Label27.Text) + CDbl(Label28.Text), 3)
                        End Select
                        oBELfab.gentrada = ""
                        oBELfab.origen = ""
                        For i = 1 To CInt(a2)
                            oBELfab.idbatch = i
                            oFabricacion.batch(oBELfab)
                        Next
                    End If
                Next
                oFabricacion.Fabricacion(oBELfab)
                lblmensaje.Text = "RESERVA EXITOSA ..."
                btngraba.Enabled = False
                LinkButton2.Enabled = False
            Else
                lblmensaje.Text = "REVISE LOS DATOS ..."
            End If

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnCalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim a1 As Double = 0
        Dim a2 As Double = 0
        Dim a3 As Double = 0
        Dim a4 As Double = 0
        Dim a5 As Double = 0

        If CheckBox1.Checked = False Then
            txtcant.Text = ""
            txtnrobacth.Text = ""
            For Each row As GridViewRow In grvBase.Rows

                'cantidad a fabricar
                Dim txt_fab As TextBox = TryCast(row.FindControl("cant1"), TextBox)
                If String.IsNullOrEmpty(txt_fab.Text) Then
                    a1 = 0.0
                    txt_fab.Text = 0
                Else
                    a1 = CDbl(txt_fab.Text).ToString
                End If

                'cantidad de base
                Dim txt_base As Label = TryCast(row.FindControl("Label10"), Label)
                a4 = CDbl(txt_base.Text).ToString
                'cantidad de batch
                Dim txt_batch As Label = TryCast(row.FindControl("Label1"), Label)
                a2 = CDbl(txt_batch.Text).ToString

                'CALCULA EL NRO DE BATCH
                Dim cant As Double = 0  'Integer
                Dim base As Double = 0  'Integer
                Dim res As Double = 0
                Dim aux As Double = 0
                cant = CDbl(a1)
                base = CDbl(a4)
                If cant Mod base = 0 Then
                    a2 = CStr(cant / base)
                    If a2 = 0.0 Then
                        a1 = 0.0
                    End If
                Else
                    aux = cant / base
                    res = Round(cant / base)
                    If res > aux Then
                        a2 = CStr(Round(cant / base))
                        a1 = (res * base)
                    Else
                        a2 = CStr(Round(cant / base) + 1)
                        a1 = (res * base) + base
                    End If
                End If

                a3 = a3 + a2
                a5 = a5 + a1

                txt_batch.Text = a2.ToString()
                txt_fab.Text = a1.ToString()
                txt_fab.Enabled = False

            Next
            txtcant.Text = a5.ToString()
            txtnrobacth.Text = a3.ToString()
        End If
    End Sub

    Protected Sub btnCalcular1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim a1 As Double = 0
        Dim a2 As Double = 0
        Dim a3 As Double = 0
        Dim a4 As Double = 0
        Dim a5 As Double = 0

        If CheckBox1.Checked = True Then
            txtcant.Text = ""
            txtnrobacth.Text = ""
            For Each row As GridViewRow In grvBase1.Rows

                'cantidad a fabricar
                Dim txt_fab As TextBox = TryCast(row.FindControl("cant2"), TextBox)
                If String.IsNullOrEmpty(txt_fab.Text) Then
                    a1 = 0.0
                    txt_fab.Text = 0
                Else
                    a1 = CDbl(txt_fab.Text).ToString
                End If

                'cantidad de base
                Dim txt_base As TextBox = TryCast(row.FindControl("base2"), TextBox)
                a4 = CDbl(txt_base.Text).ToString
                a4 = Round(a4, 2)
                'cantidad de batch
                Dim txt_batch As Label = TryCast(row.FindControl("Label32"), Label)
                a2 = CDbl(txt_batch.Text).ToString

                'CALCULA EL NRO DE BATCH
                Dim cant As Double = 0  'Integer
                Dim base As Double = 0  'Integer
                Dim res As Double = 0
                Dim aux As Double = 0
                cant = CDbl(a1)
                base = CDbl(a4)
                If CInt(cant Mod base) = 0 Then
                    a2 = CStr(cant / base)
                    If a2 = 0.0 Then
                        a1 = 0.0
                    End If
                Else
                    aux = cant / base
                    res = Round(cant / base)
                    If res > aux Then
                        a2 = CStr(Round(cant / base))
                        a1 = (res * base)
                    Else
                        a2 = CStr(Round(cant / base) + 1)
                        a1 = (res * base) + base
                    End If
                End If

                a3 = a3 + a2
                a5 = a5 + a1

                txt_batch.Text = If(a2.ToString() = "NeuN", "0", a2.ToString())
                txt_fab.Text = If(a1.ToString() = "NeuN", "0", a1.ToString())
                txt_fab.Enabled = False
                txt_base.Enabled = False

            Next
            txtcant.Text = If(a5.ToString() = "NeuN", "0", a5.ToString())
            txtnrobacth.Text = If(a3.ToString() = "NeuN", "0", a3.ToString())
        End If
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim check As Boolean
        check = CheckBox1.Checked
        If check = False Then
            grvBase.Visible = True
            grvBase1.Visible = False

        Else
            grvBase1.Visible = True
            grvBase.Visible = False
        End If
        Limpiar()
        txtcant.Text = ""
        txtnrobacth.Text = ""

        Dim btn_Calcular As Button = If(check = False, TryCast(grvBase.FooterRow.FindControl("btnCalcular"), Button), TryCast(grvBase1.FooterRow.FindControl("btnCalcular0"), Button))
        btn_Calcular.Enabled = True
        For Each row As GridViewRow In If(check = False, grvBase.Rows, grvBase1.Rows)

            Dim txt_fab As TextBox = If(check = False, TryCast(row.FindControl("cant1"), TextBox), TryCast(row.FindControl("cant2"), TextBox))
            txt_fab.Text = "0.00"
            txt_fab.Enabled = True

            If check = True Then
                Dim txt_base As TextBox = TryCast(row.FindControl("base2"), TextBox)
                txt_base.Text = "0.00"
                txt_base.Enabled = True
            End If

            Dim txt_batch As Label = If(check = False, TryCast(row.FindControl("Label1"), Label), TryCast(row.FindControl("Label32"), Label))
            txt_batch.Text = "0"
        Next
        lblmensaje.Text = ""
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Sub Limpiar()
        Label8.Text = "."
        Label13.Text = "."
        Label17.Text = "."
        Label18.Text = "."
        Label9.Text = "."
        Label14.Text = "."
        Label19.Text = "."
        Label20.Text = "."
        txt21.Text = ""
        txt22.Text = ""
        txt23.Text = ""
        txt24.Text = ""
        Label27.Text = "."
        Label28.Text = "."
        Label29.Text = "."
        Label30.Text = "."
        txtorg1.Text = ""
        txtorg2.Text = ""
        txtorg3.Text = ""
        txtorg4.Text = ""
        txtlot1.Text = ""
        txtlot2.Text = ""
        txtlot3.Text = ""
        txtlot4.Text = ""
    End Sub

#End Region

#Region "FUNCIONES"

    Private Function validaDatos() As Boolean
        oBELpro.codigo = txtcodpro.Text
        Dim dss As New DataSet
        Dim cantidad As Integer

        'ELEJIREMOS EL CASO DEPENDIENDO LA CANTIDAD DE INSUMOS
        dss = oFabricacion.ConsProductoxcod(oBELpro)
        cantidad = dss.Tables(0).Rows.Count

        Select Case cantidad

            Case 2
                If Label8.Text = "." Or Label9.Text = "." Or txt21.Text = "" Or Label27.Text = "." Or Label13.Text = "." Or Label14.Text = "." Or txt22.Text = "" Or Label28.Text = "." Or txtorg1.Text = "" Or txtorg2.Text = "" Or txtlot1.Text = "" Or txtlot2.Text = "" Then
                    validaDatos = False
                Else
                    validaDatos = True
                End If

            Case 3
                If Label8.Text = "." Or Label9.Text = "." Or txt21.Text = "" Or Label27.Text = "." Or Label13.Text = "." Or Label14.Text = "." Or txt22.Text = "" Or Label28.Text = "." Or txtorg1.Text = "" Or txtorg2.Text = "" Or txtlot1.Text = "" Or txtlot2.Text = "" Or Label17.Text = "." Or Label19.Text = "." Or txt23.Text = "" Or Label29.Text = "." Or txtorg3.Text = "" Or txtlot3.Text = "" Then
                    validaDatos = False
                Else
                    validaDatos = True
                End If

            Case 4
                If Label8.Text = "." Or Label9.Text = "." Or txt21.Text = "" Or Label27.Text = "." Or Label13.Text = "." Or Label14.Text = "." Or txt22.Text = "" Or Label28.Text = "." Or txtorg1.Text = "" Or txtorg2.Text = "" Or txtlot1.Text = "" Or txtlot2.Text = "" Or Label17.Text = "." Or Label19.Text = "." Or txt23.Text = "" Or Label29.Text = "." Or txtorg3.Text = "" Or txtlot3.Text = "" Or Label18.Text = "." Or Label20.Text = "." Or txt24.Text = "" Or Label30.Text = "." Or txtorg4.Text = "" Or txtlot4.Text = "" Then
                    validaDatos = False
                Else
                    validaDatos = True
                End If

        End Select

    End Function

#End Region

End Class
