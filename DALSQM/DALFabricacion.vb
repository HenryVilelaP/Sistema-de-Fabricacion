
'**************************************************************************
' (c) 2011 SQM - Sistemas / SOCIEDAD QUIMICA MERCANTIL   
' 
' Nombre .........: DAL_MANIPULACION_DATOS
' Objetivo........: COMUNICACION CON LA BASE DE DATOS
' Programador.....: MHUAROTO
' Fecha...........: 17/03/2011
' Version.........: 1.0.0
'**************************************************************************

#Region "IMPORT"

Imports MySql.Data.MySqlClient
Imports BELSQM
Imports System.Collections.Generic

#End Region

Public Class DALFabricacion

#Region "DECLARACION"

    Private strcons As String
    Private cmd As New MySqlCommand
    Private cnx As New Coneccion
    Private MyDA As New MySqlDataAdapter(cmd)
    Private vexito As Boolean
    Private transaction As MySqlTransaction
    Private dj As New DataSet
    Private dconsmast As New DataSet
    Private dconsmast1 As New DataSet
    Private dk As New DataSet
    Private dp As New DataSet
    Private ds As New DataSet
    Private ds1 As New DataSet
    Private dr As New DataSet
    Private dm As New DataSet
    Private db As New DataSet
    Private du As New DataSet
    Private dux As New DataSet
    Private dx As New DataSet
    Private dvta As New DataSet
    Private dvta2 As New DataSet
    Private dcantcorre As New DataSet
    Private dact As New DataSet
    Private diction As New Dictionary(Of String, Double)
    Private listacod As New List(Of String)
    Private listasumas As New List(Of Double)
    Private listasaldos As New List(Of Double)
    Private Lista As New List(Of String)
    Private dt As New DataTable

#End Region

#Region "INSERCIONES"

    '**************************************************************************
    'Nombre: DAL_INSERTA_FABRICA
    'Propósito: Inserta en la tabla fabrica
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Fabricacion(ByVal oFabric As BELFabric) As Boolean
        Try
            cmd.CommandText = "sp_inserta_fab"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codfabx", oFabric.codfab)
            cmd.Parameters.AddWithValue("fechax", oFabric.fecha)
            cmd.Parameters.AddWithValue("codigofx", oFabric.codigof)
            cmd.Parameters.AddWithValue("cantidadfx", oFabric.cantidad)
            cmd.Parameters.AddWithValue("numbatchx", oFabric.numbatch)
            cmd.Parameters.AddWithValue("contbatchx", 0)
            cmd.Parameters.AddWithValue("estadox", oFabric.estado)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_DBATCH
    'Propósito: Inserta en la tabla dbatch
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Dbatch(ByVal oFabric As BELFabric) As Boolean
        Try
            cmd.CommandText = "sp_inserta_dbatch"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codfabx", oFabric.codfab)
            cmd.Parameters.AddWithValue("idbatchx", oFabric.idbatch)
            cmd.Parameters.AddWithValue("codigopx", oFabric.codins)
            cmd.Parameters.AddWithValue("umx", "KG")
            cmd.Parameters.AddWithValue("idlotex", oFabric.idlote)
            cmd.Parameters.AddWithValue("lotefabx", oFabric.lotefab)
            cmd.Parameters.AddWithValue("origenx", oFabric.origen)
            cmd.Parameters.AddWithValue("estadox", oFabric.estado)
            cmd.Parameters.AddWithValue("qreservax", oFabric.greserva)
            cmd.Parameters.AddWithValue("cantidadpx", oFabric.cantidadp)
            cmd.Parameters.AddWithValue("costox", oFabric.costo)
            cmd.Parameters.AddWithValue("basex", oFabric.base)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_LAB_DET_RESERVA
    'Propósito: Inserta en la tabla lab_det_reserva, el detalle de cada reserva
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Sub Lab_det_reserva(ByVal oFabric As BELFabric)
        Try
            dvta2.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT codfab, sum(cantidadp), idlote,(SELECT NOMBRE FROM SQMDATA.PRODUCTOS WHERE CODIGO='" & oFabric.codigof & "') FROM dbatch d where codfab='" & oFabric.codfab & "' group by idlote"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(dvta2)
            For i = 0 To dvta2.Tables(0).Rows.Count - 1
                cmd.CommandText = "sp_inserta_lab_det_reserva"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("codfabx", dvta2.Tables(0).Rows(i).Item(0))
                cmd.Parameters.AddWithValue("idlotex", dvta2.Tables(0).Rows(i).Item(2))
                cmd.Parameters.AddWithValue("fechax", DateTime.Today)
                cmd.Parameters.AddWithValue("detallex", "FABRICACION DEL PRODUCTO '" & dvta2.Tables(0).Rows(i).Item(3).ToString.Trim & "' CON CODIGO DE PRODUCTO '" & oFabric.codigof.Trim & "'")
                cmd.Parameters.AddWithValue("estadox", 1)
                cmd.Parameters.AddWithValue("qreservax", dvta2.Tables(0).Rows(i).Item(1))
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnx.ObtenerConexion
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            Next
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try

    End Sub

    '**************************************************************************
    'Nombre: DAL_INSERTA_BATCH
    'Propósito: Inserta en la tabla batch
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Batch(ByVal oFabric As BELFabric) As Boolean
        Try
            cmd.CommandText = "sp_inserta_batch"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codfabx", oFabric.codfab)
            cmd.Parameters.AddWithValue("idbatchx", oFabric.idbatch)
            cmd.Parameters.AddWithValue("codigopx", oFabric.codigof)
            cmd.Parameters.AddWithValue("tbatchx", oFabric.tbatch)
            cmd.Parameters.AddWithValue("umx", "KG")
            cmd.Parameters.AddWithValue("estadox", oFabric.estado)
            cmd.Parameters.AddWithValue("gentradax", oFabric.gentrada)
            cmd.Parameters.AddWithValue("origenfx", oFabric.origen)
            cmd.Parameters.AddWithValue("basex", oFabric.base)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_MASTERINGRESO
    'Propósito: Inserta en la tabla MASTERINGRESO
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Masteringreso(ByVal oFabric As BELFabric) As Boolean
        Dim maxmastingreso As Integer
        Dim nummensual As Integer = ConsMaxCorreIngreso(oFabric)
        Dim origen As String
        Dim cad As String
        Dim cad3 As String
        Dim cad4 As String
        Dim concantcorr As Integer = ConsCantCorreIng(oFabric)
        If concantcorr < 10 Then
            cad = "00" + CStr(concantcorr)
        ElseIf (concantcorr >= 10 And concantcorr < 100) Then
            cad = "0" + CStr(concantcorr)
        Else : cad = CStr(concantcorr)
        End If
        If oFabric.fecha.Month < 10 Then
            cad4 = "0" + CStr(oFabric.fecha.Month)
        Else : cad4 = CStr(oFabric.fecha.Month)
        End If

        If nummensual < 10 Then
            cad3 = "00" + CStr(nummensual)
        ElseIf (nummensual >= 10 And nummensual < 100) Then
            cad3 = "0" + CStr(nummensual)
        Else : cad3 = CStr(nummensual)
        End If
        origen = "F" + "-" + CStr(oFabric.fecha.Year).Substring(2, 2) + "-" + cad
        maxmastingreso = ConsMaxMasterIngresos()
        oFabric.unicoent = maxmastingreso
        oFabric.origen = origen
        oFabric.gentrada = CStr(oFabric.fecha.Year) + "-" + cad4 + "-" + cad3
        ActuaBacth1(oFabric)
        If ConsProter(oFabric) = 0 Then
            ActuaFab(oFabric)
        End If
        Try
            cmd.CommandText = "sp_inserta_masteringresos"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("unicox", maxmastingreso)
            cmd.Parameters.AddWithValue("fechax", oFabric.fecha)
            cmd.Parameters.AddWithValue("nummensualx", nummensual)
            cmd.Parameters.AddWithValue("tipox", "F")
            cmd.Parameters.AddWithValue("origenx", origen)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_MASTERSALIDAS
    'Propósito: Inserta en la tabla mastersalidas
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Mastersalidas(ByVal oFabric As BELFabric) As Boolean
        Dim nummensual As Integer
        Dim unico As Integer
        unico = ConsMaxMasterSalida()
        nummensual = ConsMaxCorrelativo(oFabric)
        oFabric.fecha = (Today.ToString).Substring(0, 10)
        oFabric.unicosal = unico
        Try
            cmd.CommandText = "sp_inserta_mastersalidas"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("unicox", unico)
            cmd.Parameters.AddWithValue("fechax", oFabric.fecha)
            cmd.Parameters.AddWithValue("correlativox", nummensual)
            cmd.Parameters.AddWithValue("tipox", "FABRICACION")
            cmd.Parameters.AddWithValue("codtipox", "F")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_DETALLESALIDA
    'Propósito: Inserta en la tabla detallesalida
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Detallesalida(ByVal oFabric As BELFabric) As Boolean
        Try
            Dim unic As Integer
            unic = ConsMaxMasterSalida()
            cmd.CommandText = "sp_inserta_detallesalida"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("unicox", unic - 1)
            cmd.Parameters.AddWithValue("productox", oFabric.codins)
            cmd.Parameters.AddWithValue("cantidadx", oFabric.cantidad)
            cmd.Parameters.AddWithValue("umx", "KG")
            cmd.Parameters.AddWithValue("costox", oFabric.costo)
            cmd.Parameters.AddWithValue("monedax", "M2")
            cmd.Parameters.AddWithValue("unicoorigenx", oFabric.idlote)
            cmd.Parameters.AddWithValue("idorigenx", 0)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_FORMULA
    'Propósito: Inserta en la tabla formula
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Formulas(ByVal oFabric As BELFabric) As Boolean
        Try
            cmd.CommandText = "sp_inserta_formula"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codfabpx", oFabric.codigof)
            cmd.Parameters.AddWithValue("codigopx", oFabric.codins)
            'cmd.Parameters.AddWithValue("cantidadx", oFabric.cantidad)
            cmd.Parameters.AddWithValue("porcentajex", oFabric.porcentaje)
            cmd.Parameters.AddWithValue("umx", "KG")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_PROCESO_KARDEX
    'Propósito: Inserta en la tabla KARDEX a traves de la funcion KARDEX y KARDEX1
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ProcesoKardex(ByVal oFabric As BELFabric) As Boolean
        Dim con As Integer
        cmd.Connection = cnx.ObtenerConexion
        cmd.Connection.Open()
        transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            cmd.Transaction = transaction
            '-----GRABAMOS MASTER SALIDAS
            Mastersalidas(oFabric)

            '-----HAGO CONSULTA PARA GRABAR SOBRE DETALLE SALIDA
            dj = ConsAgrabarDeSali(oFabric)
            For con = 0 To dj.Tables(0).Rows.Count - 1
                oFabric.idbatch = dj.Tables(0).Rows(con).Item(0)
                oFabric.codins = dj.Tables(0).Rows(con).Item(1)
                oFabric.cantidad = dj.Tables(0).Rows(con).Item(2)
                oFabric.idlote = dj.Tables(0).Rows(con).Item(4)
                oFabric.costo = dj.Tables(0).Rows(con).Item(5)
                '---GRABA EN DETALLE SALIDA
                Detallesalida(oFabric)
            Next


            '--------ACTUALIZA BATCH-------
            ActuaBacth(oFabric)

            '--------GRABA EN KARDEX-------
            Dim dic As Dictionary(Of String, Double)
            Dim kar(4, 3) As Array
            Dim fila As Integer
            Dim colum As Integer = 0
            Dim codigo As String
            Dim suma As Double
            Dim i As Integer = 0
            Dim diction As New Dictionary(Of String, Double)
            Dim listacod As New List(Of String)
            Dim listasumas As New List(Of Double)
            Dim listasaldos As New List(Of Double)
            fila = 0
            dr.Clear()
            ds.Clear()
            cmd.Parameters.Clear()
            dic = ConsDbatch_K(oFabric)
            For Each kvp As KeyValuePair(Of String, Double) In dic
                dr.Clear() ' aca puse
                cmd.CommandText = "select saldo from kardex where id=(select max(id) from kardex where producto='" & kvp.Key & "')"
                cmd.CommandType = CommandType.Text
                MyDA.Fill(dr)
                If dr.Tables(0).Rows.Count = 0 Then
                    listasaldos.Add(0.00)
                Else
                    listasaldos.Add(dr.Tables(0).Rows(fila).Item(0))
                End If
                codigo = kvp.Key
                suma = kvp.Value
                'fila = fila + 1
                colum = colum + 1
                listacod.Add(codigo)
                listasumas.Add(suma)
                Dim numero5 As Integer
                Dim saldo As Double
                oFabric.fecha = Today
                oFabric.codins = listacod(i)
                'numcorr = ConsMaxCorrelativo(oFabric)
                'numero5 = CStr(Today.Year) + "-" + CStr(Today.Month) + "-" + CStr(numcorr)
                saldo = CDbl(listasaldos(i)) - CDbl(listasumas(i))
                '----------GRABA EN KARDEX LOS INSUMOS--------------
                oFabric.tipodoc = "GS"

                Dim cad5 As String
                numero5 = ConsMaxCorrelativo(oFabric)
                If numero5 < 10 Then
                    cad5 = "00" + CStr(numero5)
                ElseIf (numero5 >= 10 And numero5 < 100) Then
                    cad5 = "0" + CStr(numero5)
                Else : cad5 = CStr(numero5)
                End If

                Dim aux As String
                If CInt(Today.Month) < 10 Then
                    aux = "0" + CStr(Today.Month)
                Else : aux = CStr(Today.Month)
                End If

                Kardex(oFabric, CStr(Today.Year) + "-" + aux + "-" + cad5, listasumas(i), saldo)
                '---------------------------------------
                i = i + 1
            Next
            '----------GRABA EN KARDEX EL PRODUCTO FINAL-------------
            oFabric.tipodoc = "GE"
            Dim cad2 As String
            Dim numero As Integer = ConsMaxCorrelativo(oFabric) - 1
            If numero < 10 Then
                cad2 = "00" + CStr(numero)
            ElseIf (numero >= 10 And numero < 100) Then
                cad2 = "0" + CStr(numero)
            Else : cad2 = CStr(numero)
            End If

            Dim aux1 As String
            If CInt(Today.Month) < 10 Then
                aux1 = "0" + CStr(Today.Month)
            Else : aux1 = CStr(Today.Month)
            End If

            Kardex1(oFabric, CStr(Today.Year) + "-" + aux1 + "-" + cad2)

            '----------GRABAR EN MASTERINGRESOS ---------------------
            Masteringreso(oFabric)
            '----------GRABA EN VTALOTES-----------------------------
            Vtalotes(oFabric)
            '----------ACTUALIZA LOTE DE LOS INSUMOS ----------------
            ActVtaLotsalres(oFabric)

            transaction.Commit()

            ActuaMasterIngreso(oFabric)


        Catch ex As Exception
            transaction.Rollback()
        End Try
        cmd.Connection.Close()
        Return True
    End Function

    'Public Function MastersalidaId(ByVal oFabric As BELFabric) As Integer
    '    Dim SalidaId As Integer
    '    Try
    '        cmd.Parameters.Clear()
    '        cmd.Connection = cnx.obtenerConexion
    '        strcons = "SELECT ID FROM MASTERSALIDAS WHERE UNICO = '" & oFabric.unicosal & "' ;"
    '        cmd.CommandText = strcons
    '        cmd.CommandType = CommandType.Text
    '        MyDA.Fill(dx)
    '        SalidaId = CInt(dx.Tables(0).Rows(0).Item(0))
    '    Catch ex As Exception
    '        cmd.Connection.Close()
    '    End Try
    '    Return SalidaId
    'End Function

    '***********************************************************************************
    'Nombre: DAL_INSERTA_KARDEX1
    'Propósito: Inserta en la tabla KARDEX los productos que se utilizaron en una mezcla
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '************************************************************************************
    Public Function Kardex1(ByVal oFabric As BELFabric, ByVal num As String) As Boolean
        Try
            Dim dkar As New DataSet
            Dim cant As Double
            dkar = ConsBatch2(oFabric)
            cant = CDbl(dkar.Tables(0).Rows(0).Item(0))
            cmd.CommandText = "sp_inserta_kardex1"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codigopx", oFabric.codigof)
            cmd.Parameters.AddWithValue("fechax", oFabric.fecha)
            cmd.Parameters.AddWithValue("numerox", num)
            cmd.Parameters.AddWithValue("saldox", cant)
            cmd.Parameters.AddWithValue("ingresox", cant)
            cmd.Parameters.AddWithValue("tipodocx", oFabric.tipodoc)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_KARDEX
    'Propósito: Inserta en la tabla kardex los datos del nuevo producto ingresado
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Kardex(ByVal oFabric As BELFabric, ByVal num As String, ByVal salida As Double, ByVal saldo As Double) As Boolean
        Try
            cmd.CommandText = "sp_inserta_kardex"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codigopx", oFabric.codins)
            cmd.Parameters.AddWithValue("fechax", oFabric.fecha)
            cmd.Parameters.AddWithValue("numerox", num)
            cmd.Parameters.AddWithValue("salidax", salida)
            cmd.Parameters.AddWithValue("saldox", saldo)
            cmd.Parameters.AddWithValue("tipodocx", oFabric.tipodoc)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_INSERTA_VTALOTES
    'Propósito: Inserta en la tabla vtalotes el lote ingresado
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Vtalotes(ByVal oFabric As BELFabric) As Boolean
        Try
            Dim unico As Integer
            Dim origen As String 'Integer
            unico = ConsMaxMasterIngresos() - 1
            'origen = origenVtalotes(oFabric)
            origen = oFabric.origen
            'Dim cadorigen As String
            'Dim cad1 As String
            'If origen < 10 Then
            'cad1 = "00" + CStr(origen)
            ' ElseIf (origen >= 10 And origen < 100) Then
            ' cad1 = "0" + CStr(origen)
            'Else : cad1 = CStr(origen)
            'End If


            Dim canti As Double
            cmd.Parameters.Clear()
            'strcons = "SELECT TBATCH FROM BATCH WHERE CODFAB='" & oFabric.codfab & "' AND IDBATCH= '" & oFabric.idbatch & "' "
            strcons = "SELECT TBATCH FROM BATCH WHERE CODFAB='" & oFabric.codfab & "' AND IDBATCH= '" & oFabric.idbatch & "'  and  BASE= '" & oFabric.base & "' "

            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            canti = cmd.ExecuteScalar
            oFabric.cantidad = canti


            '-----------------------------------------
            Dim costo1 As Double
            cmd.Parameters.Clear()
            'strcons = "select if(costo=0,0,sum((cantidadp * costo))/sum(cantidadp)) from dbatch where codfab='" & oFabric.codfab & "' and idbatch='" & oFabric.idbatch & "'  "
            strcons = "select if(costo=0,0,round(sum(cantidadp * costo)/sum(cantidadp),2)) from dbatch where codfab='" & oFabric.codfab & "' and idbatch='" & oFabric.idbatch & "'  and  BASE= '" & oFabric.base & "' "
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            costo1 = cmd.ExecuteScalar
            oFabric.costo = costo1
            '-----------------------------------------------------------------------------
            '----ELEJIMOS EL LOTE DE MAYOR CANTIDAD PARA ASIGANARLE A NUESTRO NUEVO LOTE SU LOTEFAB---------------
            Dim LOTE As String
            'strcons = "SELECT D.LOTEFAB FROM DBATCH D WHERE D.CODFAB='" & oFabric.codfab & "'  AND D.IDBATCH='" & oFabric.idbatch & "' AND   QRESERVA= (SELECT MAX(QRESERVA) FROM DBATCH WHERE CODFAB='" & oFabric.codfab & "'  AND IDBATCH='" & oFabric.idbatch & "')"
            strcons = "SELECT D.LOTEFAB FROM DBATCH D WHERE D.CODFAB='" & oFabric.codfab & "'  AND D.IDBATCH='" & oFabric.idbatch & "' AND BASE='" & oFabric.base & "'  AND   QRESERVA= (SELECT MAX(QRESERVA) FROM DBATCH WHERE CODFAB='" & oFabric.codfab & "'  AND IDBATCH='" & oFabric.idbatch & "' AND BASE='" & oFabric.base & "' )"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(du)
            LOTE = du.Tables(0).Rows(0).Item(0).ToString
            '--------------------------------------
            'cadorigen = "F" + "-" + CStr(oFabric.fecha.Year).Substring(2, 2) + "-" + cad1
            cmd.CommandText = "sp_inserta_vtalotes"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("unicox", unico)
            cmd.Parameters.AddWithValue("fingresox", oFabric.fecha)
            cmd.Parameters.AddWithValue("tipoorigenx", "F")
            'cmd.Parameters.AddWithValue("origenxx", cadorigen.Trim)
            cmd.Parameters.AddWithValue("origenxx", origen)
            cmd.Parameters.AddWithValue("productox", oFabric.codigof)
            cmd.Parameters.AddWithValue("qingx", oFabric.cantidad)
            cmd.Parameters.AddWithValue("qsaldovx", oFabric.cantidad)
            cmd.Parameters.AddWithValue("umx", "KG")
            cmd.Parameters.AddWithValue("costox", oFabric.costo)
            cmd.Parameters.AddWithValue("lotefabx", LOTE.Trim)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function


#End Region

#Region "ACTUALIZACIONES"

    '**************************************************************************
    'Nombre: DAL_ACTUALIZA_BATCH
    'Propósito: Actualiza en la tabla dbatch y batch, pasando ambos estados a fabricado
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ActuaBacth(ByVal oFabric As BELFabric) As Boolean
        Try
            cmd.CommandText = "sp_actualiza_batch"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codfabx", oFabric.codfab)
            cmd.Parameters.AddWithValue("idbatchx", oFabric.idbatch)
            cmd.Parameters.AddWithValue("basex", oFabric.base)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function


    '**************************************************************************
    'Nombre: AnulaReserva
    'Propósito: Actualiza en la tabla dbatch y batch, pasando ambos estados a fabricado
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************

    Public Function AnulaReserva(ByVal oFabric As BELFabric) As Boolean
        Try
            cmd.CommandText = "sp_anula_reserva"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codfabx", oFabric.codfab)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_ACTUALIZA_BATCH
    'Propósito: Actualiza en la tabla dbatch y batch, pasando ambos estados a fabricado
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion

    '**************************************************************************
    Public Function ActuaLabDetReserva(ByVal oFabric As BELFabric) As Boolean
        Try
            dk.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT idlote,codfab,cantidadp FROM dbatch d where codfab='" & oFabric.codfab & "' and idbatch= '" & oFabric.idbatch & "'  and base= '" & oFabric.base & "' "
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dk)
            For i = 0 To dact.Tables(0).Rows.Count - 1
                cmd.CommandText = "sp_actualiza_lab_det_reserva"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("codfabx", dk.Tables(0).Rows(i).Item(1))
                cmd.Parameters.AddWithValue("idlotex", dk.Tables(0).Rows(i).Item(0))
                cmd.Parameters.AddWithValue("cantidadx", dk.Tables(0).Rows(i).Item(2))
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnx.ObtenerConexion
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            Next
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_ACTUALIZA_FABRICA
    'Propósito: Actualiza en la tabla Fabrica, pasando ambos estados a fabricado
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************

    Public Function ActuaFab(ByVal oFabric As BELFabric) As Boolean
        Try
            cmd.CommandText = "sp_actualiza_fabrica"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codfabx", oFabric.codfab)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_ACTUALIZA_BATCH
    'Propósito: Actualiza en la tabla batch, agregandole entrada y origen
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ActuaBacth1(ByVal oFabric As BELFabric) As Boolean
        Try
            cmd.CommandText = "sp_actualiza_batch1"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("idbatchx", oFabric.idbatch)
            cmd.Parameters.AddWithValue("gentradax", oFabric.gentrada)
            cmd.Parameters.AddWithValue("origenfx", oFabric.origen)
            cmd.Parameters.AddWithValue("codfabx", oFabric.codfab)
            cmd.Parameters.AddWithValue("basex", oFabric.base)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_ACTUALIZA_VTALOTE
    'Propósito: Actualiza en la tabla vtalote, liberando lotes en cuarentena
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion 
    '**************************************************************************
    Public Function ActuaVtaLot(ByVal oFabric As BELFabric) As Boolean

        Try
            cmd.CommandText = "sp_actualiza_vtalotes3"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("idlotex", oFabric.idlote)
            cmd.Parameters.AddWithValue("quarantinex", oFabric.cantidad)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True

        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_ACTUALIZA_FBD
    'Propósito: Actualiza en la tabla vtalote, liberando lotes en cuarentena
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ActuaFBD(ByVal oFabric As BELFabric) As Boolean

        Try
            cmd.CommandText = "sp_actualiza_fbd"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("codfabx", oFabric.codfab)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_ActVtaLotsalres
    'Propósito: Actualiza en la tabla vtalote, actualiza el saldo y la reserva
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ActVtaLotsalres(ByVal oFabric As BELFabric) As Boolean
        Try
            Dim num As Integer = 0
            Dim nro As Integer = 0
            dact.Clear()
            cmd.Parameters.Clear()
            'strcons = "SELECT idlote,cantidadp FROM dbatch d where codfab='" & oFabric.codfab & "' and idbatch='" & oFabric.idbatch & "' "
            strcons = "SELECT idlote,cantidadp FROM dbatch d where codfab='" & oFabric.codfab & "' and idbatch='" & oFabric.idbatch & "' and base='" & oFabric.base & "'   "
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dact)
            nro = dact.Tables(0).Rows.Count - 1
            For num = 0 To nro
                oFabric.idlote = dact.Tables(0).Rows(num).Item(0)
                oFabric.greserva = dact.Tables(0).Rows(num).Item(1)
                cmd.CommandText = "sp_act_vtalo_qres_qsal"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("idlotex", oFabric.idlote)
                cmd.Parameters.AddWithValue("greservax", oFabric.greserva)
                cmd.Parameters.AddWithValue("gsaldovx", oFabric.greserva)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.ExecuteNonQuery()
            Next


            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    '**************************************************************************
    'Nombre: DAL_ACTUALIZA_VTALOTE
    'Propósito: Actualiza en la tabla vtalote, reservando cantidades para la fabricacion
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function Actuavtalotes(ByVal oFabric As BELFabric) As Boolean

        Try
            cmd.CommandText = "sp_actualiza_vtalotes"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("idx", oFabric.idlote)
            cmd.Parameters.AddWithValue("greservax", oFabric.greserva)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    Public Function ActuavtalotesLoteFab(ByVal oFabric As BELFabric) As Boolean

        Try

            Dim ID As Integer
            cmd.Parameters.Clear()
            cmd.Connection = cnx.ObtenerConexion
            strcons = "select MAX(ID) from vtalotes WHERE TIPOORIGEN='F'"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(du)
            ID = du.Tables(0).Rows(0).Item(0)
            cmd.CommandText = "sp_actualiza_vtalote_lotefab"
            cmd.Parameters.AddWithValue("lotefabx", oFabric.lotefab)
            cmd.Parameters.AddWithValue("idx", ID)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

    Public Function ActuaMasterIngreso(ByVal oFabric As BELFabric) As Boolean
        ' Dim contrapartida As Integer = MastersalidaId(oFabric)
        Try
            cmd.CommandText = "sp_actualiza_masteringresos"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("unicox", oFabric.unicoent)
            cmd.Parameters.AddWithValue("contrapartidax", oFabric.unicosal)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

#End Region

#Region "CONSULTAS"

    '**************************************************************************
    'Nombre: DAL_CONSULTA_BATCH
    'Propósito: Consulta en la tabla batch, para ver si su estado es EN PROCESO
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ConsProter(ByVal oFabr As BELFabric) As Integer
        Dim can As Integer
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            strcons = "select count(CODFAB) from batch where estado='EN PROCESO' AND CODFAB='" & oFabr.codfab & "'"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            can = cmd.ExecuteScalar
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return can
    End Function

    '**************************************************************************
    'Nombre: DAL_VALIDA_USUARIO
    'Propósito: Valida en la tabla clave, el acceso al sistema
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ValidaUsuario(ByVal oPers As BEPersona) As DataSet
        'Try
        '    cmd.Parameters.Clear()
        '    strcons = "SELECT usuario,security,correo,contrasena FROM sqmdata.CLAVE WHERE USUARIO='" & oPers.Usuario & "' AND CLAVEWEB='" & oPers.Claveweb & "'"
        '    cmd.Connection = cnx.ObtenerConexion
        '    cmd.CommandText = strcons
        '    cmd.CommandType = CommandType.Text
        '    cmd.Connection.Open()
        '    ds.Clear()
        '    MyDA.Fill(ds)

        '    cmd.Connection.Dispose()
        'Catch ex As Exception
        '    cmd.Connection.Close()
        'End Try
        'Return ds

        Try
            cmd.CommandText = "sp_valida_usuario"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("usuariox", oPers.Usuario)
            cmd.Parameters.AddWithValue("clavex", oPers.Claveweb)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Close()
        Catch ex As Exception
            cmd.Connection.Close()
        Throw ex
        End Try

        Return ds
    End Function

    '**************************************************************************
    'Nombre: DAL_CONSULTA_PRODUCTO
    'Propósito: Consula de tabla producto
    'Entradas: objeto del tipo BELProducto
    'Se Asume: N/A
    'Retorno: Un dataset con todos los datos del producto
    '**************************************************************************
    Public Function ConsProducto(ByVal oPro As BELProducto) As DataSet
        Try
            cmd.Parameters.Clear()
            'strcons = "select P.codigo, P.nombre FROM PRODUCTOS P, FORMULAS F where P.CODIGO=F.CODFABP AND P.nombre like '%" & oPro.nombre & "%' GROUP BY F.CODFABP "
            strcons = "select P.codigo, P.nombre FROM PRODUCTOS P, FORMULAS F where F.ESTADO='1' AND P.CODIGO=F.CODFABP AND P.nombre like '%" & oPro.nombre & "%' GROUP BY F.CODFABP "
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            ds.Clear()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    'BUSCA PRODUCTO PARA CREAR NUEVA FORMULA

    Public Function ConsProductoF(ByVal oPro As BELProducto) As DataSet
        Try
            cmd.Parameters.Clear()
            ds.Clear()
            strcons = "select P.codigo, P.nombre FROM PRODUCTOS P where  (tipoproducto between '00' and '12') AND P.nombre like '%" & oPro.nombre & "%' AND P.activo='1' "
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            ds.Clear()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsProductoxcod(ByVal oPro As BELProducto) As DataSet
        Try
            cmd.Parameters.Clear()
            'strcons = "SELECT P.CODIGO,P.NOMBRE, F.cantidad as CANTIDAD,F.CODIGOP AS COD_INSUMOS,(SELECT NOMBRE FROM PRODUCTOS WHERE CODIGO=COD_INSUMOS) AS INSUMOS FROM PRODUCTOS P, FORMULAS F WHERE F.CODFABP=P.CODIGO AND P.CODIGO like '%" & oPro.codigo & "%'"
            strcons = "SELECT P.CODIGO,P.NOMBRE, F.porcentaje as CANTIDAD,F.CODIGOP AS COD_INSUMOS,(SELECT NOMBRE FROM PRODUCTOS WHERE CODIGO=COD_INSUMOS) AS INSUMOS FROM PRODUCTOS P, FORMULAS F WHERE F.ESTADO='1' AND F.CODFABP=P.CODIGO AND P.CODIGO like '%" & oPro.codigo & "%' "
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            ds.Clear()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsProductoxcodnoIngresado(ByVal oPro As BELProducto) As DataSet
        Try
            cmd.Parameters.Clear()
            strcons = "SELECT P.codigo, P.nombre FROM PRODUCTOS P left join (select codfabp FROM FORMULAS where ESTADO='1' GROUP BY CODFABP) F ON P.CODIGO=F.CODFABP where (P.tipoproducto between '00' and '12') and P.activo='1' and codfabp is null and P.nombre like '%" & oPro.nombre & "%'   "
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            ds.Clear()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsdProducto(ByVal oPro As BELProducto) As DataSet
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT F.CODIGOP AS COD_INSUMOS,(SELECT NOMBRE FROM PRODUCTOS WHERE CODIGO=COD_INSUMOS) AS INSUMOS FROM PRODUCTOS P, FORMULAS F WHERE F.CODFABP=P.CODIGO AND P.NOMBRE like '%" & oPro.nombre & "%'"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsMaxCod() As Double
        Dim i As Integer
        Try
            cmd.Parameters.Clear()
            strcons = "select count(*) from fabrica "
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            i = cmd.ExecuteScalar()
            cmd.Connection.Close()
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return i + 1
    End Function

    Public Function OrigenVtalotes(ByVal oFabr As BELFabric) As Integer
        Dim nro As Integer
        Try
            dvta2.Clear()
            strcons = "SELECT COUNT(*) + 1 FROM VTALOTES WHERE YEAR(FINGRESO)='" & oFabr.fecha.Year & "' AND TIPOORIGEN='F' "
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dvta2)
            nro = CInt(dvta2.Tables(0).Rows(0).Item(0))
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return nro
    End Function

    Public Function ConsMaxCorrelativo(ByVal oFabr As BELFabric) As Integer
        Try
            Dim i As Integer = ConsCantCorrelativo(oFabr)
            If i = 0 Then
                Return 1
            Else
                cmd.Parameters.Clear()
                strcons = "select MAX(CORRELATIVO)+1 from mastersalidas WHERE YEAR(FECHA)= '" & Today.Year & "'  AND MONTH(FECHA)='" & Today.Month & "'"
                cmd.CommandText = strcons
                cmd.CommandType = CommandType.Text
                i = cmd.ExecuteScalar()
                Return i
            End If
        Catch ex As Exception
            cmd.Connection.Close()
        End Try

    End Function

    Public Function ConsMaxCorreIngreso(ByVal oFabr As BELFabric) As Integer

        Try
            Dim i As Integer = ConsCantCorreIng(oFabr)
            If i = 0 Then
                Return 1
            Else
                cmd.Parameters.Clear()
                strcons = "select MAX(nummensual)+1 from masteringresos WHERE YEAR(FECHA)= '" & oFabr.fecha.Year & "'  AND MONTH(FECHA)='" & oFabr.fecha.Month & "'"
                cmd.CommandText = strcons
                cmd.CommandType = CommandType.Text
                MyDA.Fill(dcantcorre)
                If dcantcorre.Tables(0).Rows(0).Item(0).ToString = "" Then
                    i = 1 '0
                Else
                    i = CInt(dcantcorre.Tables(0).Rows(0).Item(0))
                End If
                Return i
            End If
        Catch ex As Exception
            cmd.Connection.Close()
        End Try

    End Function

    Public Function ConsMaxOrigen(ByVal oFabr As BELFabric) As Integer

        Try
            Dim i As Integer = ConsCantCorreIng(oFabr)
            If i = 0 Then
                Return CStr(1)
            Else
                cmd.Parameters.Clear()
                strcons = "SELECT count(id) +1 FROM masteringresos m where  year(fecha)='" & oFabr.fecha.Year & "'"
                cmd.CommandText = strcons
                cmd.CommandType = CommandType.Text
                i = cmd.ExecuteScalar()
                Return i
            End If
        Catch ex As Exception
            cmd.Connection.Close()
        End Try

    End Function

    Public Function ConsCantCorrelativo(ByVal oFabr As BELFabric) As Integer

        Try
            Dim i As Integer
            strcons = "select count(CORRELATIVO) from mastersalidas WHERE YEAR(FECHA)= '" & Today.Year & "'  AND MONTH(FECHA)='" & Today.Month & "'"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            i = cmd.ExecuteScalar()
            Return i
        Catch ex As Exception
            cmd.Connection.Close()
        End Try

    End Function

    Public Function ConsCantCorreIng(ByVal oFabr As BELFabric) As Integer

        Try
            Dim i As Integer
            cmd.Parameters.Clear()
            'strcons = "select count(*) from masteringresos WHERE TIPO='F' AND YEAR(FECHA)= '" & oFabr.fecha.Year & "'   "
            strcons = "select ifnull(max(convert(substring(origen,6,3),SIGNED INTEGER)),0) from masteringresos WHERE TIPO='F' AND YEAR(FECHA)= '" & oFabr.fecha.Year & "'   "
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            i = cmd.ExecuteScalar()
            Return i + 1
        Catch ex As Exception
            cmd.Connection.Close()
        End Try

    End Function

    Public Function ConsMaxMasterSalida() As Integer
        Dim m As Integer
        Try
            dconsmast.Clear()
            cmd.Parameters.Clear()
            strcons = "select max(unico) from mastersalidas"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dconsmast)
            If dconsmast.Tables(0).Rows(0).Item(0).ToString = "" Then
                m = 0
            Else
                m = CInt(dconsmast.Tables(0).Rows(0).Item(0))
            End If
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return m + 1
    End Function

    Public Function ConsMaxMasterSalidaId() As Integer
        Dim m1 As Integer
        Try
            dconsmast1.Clear()
            cmd.Parameters.Clear()
            strcons = "select max(id) from mastersalidas"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dconsmast1)
            If dconsmast1.Tables(0).Rows(0).Item(0).ToString = "" Then
                m1 = 0
            Else
                m1 = CInt(dconsmast1.Tables(0).Rows(0).Item(0))
            End If
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return m1
    End Function

    Public Function ConsMaxVtalotes() As Integer
        Dim a As Integer
        Try
            dvta.Clear()
            cmd.Parameters.Clear()
            strcons = "select max(unico) from vtalotes WHERE YEAR(FINGRESO)>2009"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dvta)
            If dvta.Tables(0).Rows(0).Item(0).ToString = "" Then
                a = 0
            Else
                a = CInt(dvta.Tables(0).Rows(0).Item(0))
            End If
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return a + 1
    End Function

    Public Function ConsUltimoLote(ByVal oFabric As BELFabric) As String
        Dim LOTE As String
        cmd.Parameters.Clear()
        cmd.Connection = cnx.ObtenerConexion
        'strcons = "SELECT TRIM(D.LOTEFAB),D.COSTO FROM DBATCH D WHERE D.CODFAB='" & oFabric.codfab & "'  AND D.IDBATCH='" & oFabric.idbatch & "' AND   QRESERVA= (SELECT MAX(QRESERVA) FROM DBATCH WHERE CODFAB='" & oFabric.codfab & "'  AND IDBATCH='" & oFabric.idbatch & "')"
        strcons = "SELECT TRIM(D.LOTEFAB),D.COSTO FROM DBATCH D WHERE D.CODFAB='" & oFabric.codfab & "'  AND D.IDBATCH='" & oFabric.idbatch & "' AND D.BASE='" & oFabric.base & "'  AND   QRESERVA= (SELECT MAX(QRESERVA) FROM DBATCH WHERE CODFAB='" & oFabric.codfab & "'  AND IDBATCH='" & oFabric.idbatch & "' AND BASE='" & oFabric.base & "' )"
        cmd.CommandText = strcons
        cmd.CommandType = CommandType.Text
        MyDA.Fill(du)

        LOTE = (du.Tables(0).Rows(0).Item(0).ToString + ";" + du.Tables(0).Rows(0).Item(1).ToString)
        'LOTE1 = du.Tables(0).Rows(0).Item(1).ToString
        'Return (LOTE And LOTE1)
        Return LOTE
    End Function

    Public Function ConsMaxMasterIngresos() As Integer
        Dim i As Integer
        Try
            dm.Clear()
            cmd.Parameters.Clear()
            strcons = "select max(unico) from masteringresos"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dm)
            If dm.Tables(0).Rows(0).Item(0).ToString = "" Then
                i = 0
            Else
                i = CInt(dm.Tables(0).Rows(0).Item(0))
            End If
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return i + 1
    End Function

    Public Function ConsdlotePro(ByVal oPro As BELProducto) As DataSet
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT id,origen,lotefab,costo,qsaldov-(qreserva+qstandby+qexterno+quarantine) as Disponible,DATE_FORMAT(fingreso,'%d/%m/%Y')AS fec,costo,if(ubicacion='L','LINCE',IF(ubicacion='P','SAN PEDRITO','')) ubicacion  FROM Vtalotes where qsaldov>0 and producto like '%" & oPro.codigo & "%'"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    '**************************************************************************
    'Nombre: DAL_CONSULTA_VTALOTE
    'Propósito: Consulta la tabla VTALOTE, verificando que la cuarentena sea mayor a cero y el tipo sea W o D
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion 
    '**************************************************************************
    Public Function ConsdloteLibera() As DataSet
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            strcons = "select id,fingreso,tipoorigen AS T,origen,producto, (select nombre from sqmdata.productos where codigo=producto) as Nombre, qing, qven, qreserva, qstandby,quarantine,qexterno, qsaldov-(qreserva+qstandby+qexterno+quarantine) as Disponible, costo,lotefab from sqmdata.vtalotes where anulada=0 and tipoorigen in ('W','D','I') and qstandby>0 order by fingreso desc"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    '**************************************************************************
    'Nombre: DAL_CONSULTA_VTALOTE1
    'Propósito: Consulta la tabla VTALOTE, verificando que la cuarentena sea mayor a cero y el tipo sea W o D
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ConsdloteLibera1(ByVal oFabr As BELFabric) As ArrayList
        Dim lista As New ArrayList
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            strcons = "select id,origen,producto, (select nombre from sqmdata.productos where codigo=producto) as Nombre, lotefab from sqmdata.vtalotes where tipoorigen in ('W','D','I') and id= '" & oFabr.idlote & "' order by producto"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            For i = 0 To 4
                lista.Add(ds.Tables(0).Rows(0).Item(i).ToString)
            Next
            cmd.Connection.Dispose()

        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return lista
    End Function

    '**************************************************************************
    'Nombre: DAL_CONSULTA_PRODUCTO_DE_FABRICA
    'Propósito: Consulta la tabla PRODUCTO y FABRICA, verificando que la cuarentena sea mayor a cero y el tipo sea W o D
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ConsFabrica() As DataSet
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT F.CODFAB, F.FECHA, F.CODIGOF, F.CANTIDADF, F.NUMBATCH, F.ESTADO, TRIM(P.NOMBRE)NOMBRE FROM FABRICA F, PRODUCTOS P  WHERE F.CODIGOF=P.CODIGO order by F.CODFAB desc"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsBatch(ByVal oFabr As BELFabric) As DataSet
        Try

            ds.Clear()
            ds.Tables(0).Columns.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT * FROM BATCH WHERE CODFAB = '" & oFabr.codfab & "' ORDER BY BASE, IDBATCH"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsBatch2(ByVal oFabr As BELFabric) As DataSet
        Try
            db.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT tbatch FROM BATCH WHERE CODFAB = '" & oFabr.codfab & "' and idbatch='" & oFabr.idbatch & "' ORDER BY IDBATCH"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(db)
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return db
    End Function

    Public Function ConsDbatch(ByVal oFabr As BELFabric) As DataSet
        Try
            ds.Clear()
            ds.Tables(0).Columns.Clear()
            cmd.Parameters.Clear()
            'strcons = "SELECT D.CODFAB,D.IDBATCH,D.CODIGOP,D.cantidadp AS CANTIDAD,D.UM,D.QRESERVA,D.LOTEFAB,D.ORIGEN,D.ESTADO,P.NOMBRE FROM DBATCH D,PRODUCTOS P WHERE D.CODIGOP=P.CODIGO AND D.IDBATCH= '" & oFabr.idbatch & "' and  D.CODFAB = '" & oFabr.codfab & "' ORDER BY IDBATCH "
            strcons = "SELECT D.CODFAB,D.IDBATCH,D.CODIGOP,D.cantidadp AS CANTIDAD,D.UM,D.QRESERVA,D.LOTEFAB,D.ORIGEN,D.ESTADO,P.NOMBRE FROM DBATCH D,PRODUCTOS P WHERE D.CODIGOP=P.CODIGO AND D.IDBATCH= '" & oFabr.idbatch & "' and  D.CODFAB = '" & oFabr.codfab & "' and D.BASE = '" & oFabr.base & "'ORDER BY IDBATCH "
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsIdlote(ByVal oFabr As BELFabric) As DataSet
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT idlote FROM dbatch d where codfab= '" & oFabr.codfab & "' and idbatch= '" & oFabr.idbatch & "' order by idbatch;"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsAgrabarDeSali(ByVal oFabr As BELFabric) As DataSet
        Try
            dj.Clear()
            cmd.Parameters.Clear()
            'strcons = "SELECT d.idbatch, d.codigop, d.cantidadp, d.um, d.idlote,v.costo FROM dbatch d, vtalotes v where d.codfab='" & oFabr.codfab & "' and  d.idbatch= '" & oFabr.idbatch & "' and  v.id = d.idlote order by idbatch"
            strcons = "SELECT d.idbatch, d.codigop, d.cantidadp, d.um, d.idlote,v.costo FROM dbatch d, vtalotes v where d.codfab='" & oFabr.codfab & "' and  d.idbatch= '" & oFabr.idbatch & "' and  v.id = d.idlote  and  d.base= '" & oFabr.base & "' order by idbatch"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dj)
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return dj
    End Function

    Public Function ValidaAnulacion(ByVal oFabric As BELFabric) As String
        Dim validaA As String = ""
        Try
            If VerificaOrden(oFabric) = 0 Then
                validaA = "CODIGO NO EXISTE"
            Else
                cmd.Parameters.Clear()
                cmd.Connection = cnx.ObtenerConexion
                'strcons = "select distinct if(trim(f.estado)=('ANULADO' or 'FABRICADO'),'NO SE ANULO','ANULADO CORRECTAMENTE') estado from fabrica f where f.codfab='" & oFabric.codfab & "';"
                'strcons = "select distinct trim(f.estado)estado from fabrica f where f.codfab='" & oFabric.codfab & "' and length(f.codfab)=length('" & oFabric.codfab & "') ;"
                strcons = "SELECT c.estado from (SELECT distinct trim(b.estado)estado FROM BATCH b WHERE CODFAB = '" & oFabric.codfab & "' ORDER BY IDBATCH)c  where trim(c.estado)=('FABRICADO') or trim(c.estado)=('ANULADO');"
                cmd.CommandText = strcons
                cmd.CommandType = CommandType.Text
                MyDA.Fill(dux)
                validaA = dux.Tables(0).Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return validaA
    End Function

    Public Function VerificaOrden(ByVal oFabric As BELFabric) As String
        Dim verifica As String = ""
        Try
            cmd.Parameters.Clear()
            cmd.Connection = cnx.ObtenerConexion
            strcons = "SELECT COUNT(*) REGISTRO FROM BATCH b WHERE CODFAB = '" & oFabric.codfab & "'  AND LENGTH(CODFAB)=LENGTH('" & oFabric.codfab & "') ORDER BY IDBATCH;"
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(du)
            verifica = du.Tables(0).Rows(0).Item(0).ToString
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return verifica
    End Function

    Public Function ConsVtaLot(ByVal oFabric As BELFabric) As DataSet
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            'strcons = "select id, qstandby from vtalotes where id='" & oFabric.idlote & "' and qstandby >='" & oFabric.cantidad & "'  "
            strcons = "select id, qstandby from vtalotes where id='" & oFabric.idlote & "' and qstandby >='" & oFabric.cantidad & "'  and  qstandby>'0.00' "
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            cmd.Connection.Dispose()

        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds
    End Function

    Public Function ConsBase_mezcla() As DataSet
        Try
            ds1.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT id,peso_kg FROM base_mezcla  where estado=1 order by 2"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds1)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds1
    End Function

    '-----------------------------------------------------------------
    '---------------------KARDEX--------------------------------------
    '-----------------------------------------------------------------

    Public Function ConsDbatch_K(ByVal oFabr As BELFabric) As Dictionary(Of String, Double)
        Try
            Dim nrofilas As Integer
            Dim i As Integer
            dp.Clear()
            cmd.Parameters.Clear()
            'strcons = "SELECT D.CODIGOP,SUM(D.CANTIDADP)FROM DBATCH D,PRODUCTOS P WHERE D.CODIGOP=P.CODIGO AND D.IDBATCH= '" & oFabr.idbatch & "' and D.CODFAB = '" & oFabr.codfab & "'  GROUP BY D.CODIGOP ORDER BY IDBATCH "
            strcons = "SELECT D.CODIGOP,SUM(D.CANTIDADP)FROM DBATCH D,PRODUCTOS P WHERE D.CODIGOP=P.CODIGO AND D.IDBATCH= '" & oFabr.idbatch & "' and D.CODFAB = '" & oFabr.codfab & "' and D.BASE = '" & oFabr.base & "' GROUP BY D.CODIGOP ORDER BY IDBATCH "
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            MyDA.Fill(dp)
            nrofilas = dp.Tables(0).Rows.Count
            For i = 1 To nrofilas
                diction.Add((dp.Tables(0).Rows(i - 1).Item(0).ToString), CDbl(dp.Tables(0).Rows(i - 1).Item(1)))
            Next
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return diction
    End Function

    Public Function ConsSaldo_K(ByVal oFabr As BELFabric) As List(Of String)
        Try
            'Dim nrofilas As Integer
            Dim MyDA As New MySqlDataAdapter(cmd)
            Dim dic As Dictionary(Of String, Double)
            Dim kar(4, 3) As Array
            Dim fila As Integer = 0
            Dim colum As Integer = 0
            Dim codigo As String
            Dim suma As Double
            Dim i As Integer = 0

            ds.Clear()
            dj.Clear()
            cmd.Parameters.Clear()
            dic = ConsDbatch_K(oFabr)
            For Each kvp As KeyValuePair(Of String, Double) In dic

                strcons = "select saldo from kardex where id=(select max(id) from kardex where producto='" & kvp.Key & "')"
                cmd.Connection = cnx.ObtenerConexion
                cmd.CommandText = strcons
                cmd.CommandType = CommandType.Text
                MyDA.Fill(dj)
                If dj.Tables(0).Rows.Count = 0 Then
                    listasaldos.Add(0.0)
                Else
                    listasaldos.Add(dj.Tables(0).Rows(fila).Item(0))
                End If
                codigo = kvp.Key
                suma = kvp.Value
                fila = fila + 1
                colum = colum + 1
                listacod.Add(codigo)
                listasumas.Add(suma)

                Dim num As String
                Dim numcorr As Integer
                Dim saldo As Double
                oFabr.fecha = Today
                oFabr.codins = listacod(i)
                numcorr = ConsMaxCorrelativo(oFabr)
                num = CStr(Today.Year) + "-" + CStr(Today.Month) + "-" + CStr(numcorr)
                saldo = CDbl(listasaldos(i)) - CDbl(listasumas(i))
                '----------GRABA EN KARDEX--------------
                Kardex(oFabr, num, listasumas(i), saldo)
                '---------------------------------------
                i = i + 1
            Next


            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return listacod
    End Function

    Public Function ConSaldo(ByVal oFabr As BELFabric) As Double
        dk.Clear()
        strcons = "select saldo from kardex where id=(select max(id) from kardex where producto='" & oFabr.codigof & "')"
        cmd.CommandText = strcons
        cmd.CommandType = CommandType.Text
        MyDA.Fill(dk)
        If dk.Tables(0).Rows.Count = 0 Then
            Return 0.0
        Else
            Return CDbl(dk.Tables(0).Rows(0).Item(0))
        End If

    End Function

    '**************************************************************************
    'Nombre: DAL_CONSULTA_BATCH
    'Propósito: Consulta en la tabla batch, para ver si su estado es EN PROCESO
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ConsFilaDBatch(ByVal oFabr As BELFabric) As Integer
        Dim can As Integer
        Try
            ds.Clear()
            cmd.Parameters.Clear()
            'strcons = "select count(*) from sqmdata.batch where codfab='" & oFabr.codfab & "'"
            strcons = "select count(*) from sqmdata.batch where codfab='" & oFabr.codfab & "' and length(codfab)=length('" & oFabr.codfab & "')"
            cmd.CommandText = strcons
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            can = cmd.ExecuteScalar
            cmd.Connection.Close()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return can
    End Function

    '**************************************************************************
    'Nombre: CONSDETALLEULTIMOLOTE
    'Propósito: CONSULTA LOS DATOS DEL ULTIMO LOTE INGRESADO EN LA FABRICACION
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function ConsDetalleUltimoLote() As List(Of String)
        Try
            Dim i As Integer
            ds.Clear()
            cmd.Parameters.Clear()
            strcons = "select v.unico,v.origen,(select nombre from productos where codigo=v.producto),v.producto, v.lotefab,v.qing from vtalotes v where v.id=(select max(id) from vtalotes) and tipoorigen='F'"
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds)
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Lista.Add(ds.Tables(0).Rows(0).Item(0).ToString)
                Lista.Add(ds.Tables(0).Rows(0).Item(1).ToString)
                Lista.Add(ds.Tables(0).Rows(0).Item(2).ToString)
                Lista.Add(ds.Tables(0).Rows(0).Item(3).ToString)
                Lista.Add(ds.Tables(0).Rows(0).Item(4).ToString)
                Lista.Add(ds.Tables(0).Rows(0).Item(5).ToString)
            Next
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return Lista
    End Function

    Public Function ConsProductoCero(ByVal oFabr As BELFabric) As DataSet
        Try
            ds1.Clear()
            cmd.Parameters.Clear()
            strcons = "SELECT distinct d.CODFAB,d.CODIGOP,trim(p.nombre) NOMBRE,d.LOTEFAB,d.ORIGEN,d.COSTO from dbatch d inner join productos p on d.codigop=p.codigo where d.codfab='" & oFabr.codfab & "' and d.costo='0.00' "
            'strcons = "SELECT distinct d.CODFAB,d.CODIGOP,trim(p.nombre) NOMBRE,d.LOTEFAB,d.ORIGEN,d.COSTO from dbatch d inner join productos p on d.codigop=p.codigo where d.codfab='" & oFabr.codfab & "'  "
            cmd.Connection = cnx.ObtenerConexion
            cmd.CommandText = strcons
            cmd.CommandType = CommandType.Text
            cmd.Connection.Open()
            MyDA.Fill(ds1)
            cmd.Connection.Dispose()
        Catch ex As Exception
            cmd.Connection.Close()
        End Try
        Return ds1
    End Function

#End Region

#Region "ELIMINACIONES"

    Public Function EliminaFormula(ByVal oFabric As BELFabric) As Boolean
        Try
            'cmd.CommandText = "DELETE FROM FORMULAS WHERE CODFABP= '" & oFabric.codigof & "'"
            cmd.CommandText = "UPDATE FORMULAS SET ESTADO='0' WHERE CODFABP= TRIM('" & oFabric.codigof & "')    "
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnx.ObtenerConexion
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            vexito = True
        Catch ex As Exception
            cmd.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

#End Region

End Class
