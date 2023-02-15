
#Region "IMPORT"

Imports DALSQM
Imports BELSQM
Imports System.Net.Mail

#End Region

Public Class BLLUtilitario

#Region "DECLARACION"

    Private oDALutil As New DALUtilitario
    Private oDALLfab As New DALFabricacion
    Private oPersona As New BEPersona

#End Region

#Region "ENVIAR"

    '**************************************************************************
    'Nombre: BLL_ENVIA_CORREO
    'Propósito: Enviar correo
    'Entradas: objeto del tipo BELFabric
    'Se Asume: N/A
    'Retorno: boolean para verificar si tuvo exito la operacion
    '**************************************************************************
    Public Function EnviaCorreo(ByVal oFab As BELFabric, ByVal oPers As BEPersona) As Boolean
        Dim lista As New ArrayList
        Dim nombre As String
        lista = oDALLfab.ConsdloteLibera1(oFab)
        oFab.idlote = CInt(lista(0))
        oFab.origen = CStr(lista(1))
        oFab.codigof = CStr(lista(2))
        nombre = CStr(lista(3))
        oFab.lotefab = CStr(lista(4))
        Dim correo As New System.Net.Mail.MailMessage()
        Dim cor As String
        cor = "almacen@sociedadquimica.com.pe,ventas@sociedadquimica.com.pe,yanco@sociedadquimica.com.pe,vendedores@sociedadquimica.com.pe,lrojas@sociedadquimica.com.pe,yvera@sociedadquimica.com.pe,importaciones@sociedadquimica.com.pe,jcordova@indicolor.com.pe"
        'cor = "sistemas@sociedadquimica.com.pe"
        correo.To.Add(cor)
        correo.Subject = "LOTE LIBERADO"
        correo.Body = "SE HA LIBERADO :ORIGEN '" & oFab.origen & "' el LOTE'" & oFab.lotefab & "' la cantidad de '" & oFab.cantidad & "' KG del producto '" & nombre & "' CODIGO '" & oFab.codigof & "'"
        correo.IsBodyHtml = True
        correo.CC.Add("sistemas@sociedadquimica.com.pe")
        correo.Priority = System.Net.Mail.MailPriority.Normal
        Dim smtp As New SmtpClient With {
            .Host = "smtp.gmail.com",
            .EnableSsl = True,
            .Port = "25"
        }
        correo.From = New System.Net.Mail.MailAddress(oPers.Correo.Trim, "SQM.Informacion", System.Text.Encoding.Default)
        smtp.Credentials = New System.Net.NetworkCredential(oPers.Correo.Trim, oPers.Contrasena.Trim)
        smtp.EnableSsl = True


        smtp.Send(correo)
    End Function

    Public Function EnviaCorreoGenerico(ByVal oFab As BELFabric, ByVal oPers As BEPersona) As Boolean
        Dim lista As New List(Of String)
        Dim nombre As String
        lista = oDALLfab.ConsDetalleUltimoLote()
        oFab.idlote = CInt(lista(0))
        oFab.origen = CStr(lista(1))
        oFab.codigof = CStr(lista(3))
        oFab.lotefab = CStr(lista(4))
        oFab.cantidadp = CStr(lista(5))
        nombre = CStr(lista(2))
        Dim correo As New System.Net.Mail.MailMessage()
        Dim cor As String
        cor = "almacen@sociedadquimica.com.pe,ventas@sociedadquimica.com.pe,yanco@sociedadquimica.com.pe,vendedores@sociedadquimica.com.pe"
        'cor = "mparco@sociedadquimica.com.pe"
        correo.To.Add(cor)
        correo.Subject = "LOTE FABRICADO"
        correo.Body = "SE HA FABRICADO :ORIGEN '" & oFab.origen & "' LOTE FAB.:'" & oFab.lotefab & "' la cantidad de '" & oFab.cantidadp & "' KG del producto '" & nombre & "' CODIGO '" & oFab.codigof & "'"
        correo.IsBodyHtml = True
        correo.CC.Add("sistemas@sociedadquimica.com.pe")
        correo.Priority = System.Net.Mail.MailPriority.Normal
        Dim smtp As New SmtpClient With {
            .Host = "smtp.gmail.com",
            .EnableSsl = True,
            .Port = "25"
        }
        correo.From = New System.Net.Mail.MailAddress(oPers.Correo.Trim, "SQM.Informacion", System.Text.Encoding.Default)
        smtp.Credentials = New System.Net.NetworkCredential(oPers.Correo.Trim, oPers.Contrasena.Trim)
        smtp.EnableSsl = True
        smtp.Send(correo)

    End Function

    'Public Function EnviaCorreoAlerta(ByVal oFab As BELFabric, ByVal oPers As BEPersona) As Boolean
    '    Dim lista As New List(Of String)
    '    Dim listaCero As New DataTable
    '    Dim nombre As String
    '    lista = oDALLfab.ConsDetalleUltimoLote()
    '    'listaCero = oDALLfab.ConsDetalleUltimoLoteCero()
    '    oFab.idlote = CInt(lista(0))
    '    oFab.origen = CStr(lista(1))
    '    oFab.codigof = CStr(lista(3))
    '    oFab.lotefab = CStr(lista(4))
    '    oFab.cantidadp = CStr(lista(5))
    '    'oFab.costo '= CStr(lista(6))
    '    nombre = CStr(lista(2))
    '    Dim correo As New System.Net.Mail.MailMessage()
    '    Dim cor As String
    '    'cor = "importaciones@sociedadquimica.com.pe,yanco@sociedadquimica.com.pe"
    '    cor = "mparco@sociedadquimica.com.pe,jinga@sociedadquimica.com.pe"
    '    correo.To.Add(cor)
    '    correo.Subject = "AVISO - LOTE FABRICADO CON COSTO  0.00"
    '    correo.Body = "SE HA FABRICADO :ORIGEN '" & oFab.origen & "' LOTE FAB.:'" & oFab.lotefab & "' la cantidad de '" & oFab.cantidadp & "' KG del producto '" & nombre & "' CODIGO '" & oFab.codigof & "' COSTO '" & oFab.costo & "'"
    '    correo.IsBodyHtml = True
    '    correo.CC.Add("sistemas@sociedadquimica.com.pe")
    '    correo.Priority = System.Net.Mail.MailPriority.Normal
    '    Dim smtp As New System.Net.Mail.SmtpClient
    '    smtp.Host = "smtp.gmail.com"
    '    smtp.EnableSsl = True
    '    smtp.Port = "25"
    '    correo.From = New System.Net.Mail.MailAddress(oPers.Correo.Trim)
    '    smtp.Credentials = New System.Net.NetworkCredential(oPers.Correo.Trim, oPers.Contrasena.Trim)
    '    smtp.EnableSsl = True
    '    smtp.Send(correo)

    'End Function

    Public Function EnviaCorreoAlerta(ByVal oFab As BELFabric, ByVal oPers As BEPersona) As Boolean

        Dim lista As New List(Of String)
        Dim dsBody As New DataSet
        Dim nombre As String
        Dim vBody As String = ""
        Dim i As Integer
        lista = oDALLfab.ConsDetalleUltimoLote()
        dsBody = oDALLfab.ConsProductoCero(oFab)
        oFab.idlote = CInt(lista(0))
        oFab.origen = CStr(lista(1))
        oFab.codigof = CStr(lista(3))
        oFab.lotefab = CStr(lista(4))
        oFab.cantidadp = CStr(lista(5))
        'oFab.costo '= CStr(lista(6))
        nombre = CStr(lista(2))
        Dim correo As New System.Net.Mail.MailMessage()
        Dim cor As String
        cor = "importaciones@sociedadquimica.com.pe,yanco@sociedadquimica.com.pe"
        'cor = "mparco@sociedadquimica.com.pe"
        correo.To.Add(cor)
        correo.Subject = "AVISO - LOTE FABRICADO CON COSTO 0.00"

        vBody &= "SE HA FABRICADO :ORIGEN '" & oFab.origen & "' LOTE FAB.:'" & oFab.lotefab & "' la cantidad de '" & oFab.cantidadp & "' KG del producto '" & nombre & "' CODIGO '" & oFab.codigof & "' COSTO '" & oFab.costo & "'"
        vBody &= "<p></p>"
        vBody &= "<TABLE  border=""1""  bordercolor=""#000000"" >"
        ' vBody &= "<TH>"
        vBody &= "<TH  style=""background:#5D7B9D""  bordercolor=""#000000""  align=""center"">COD FABRI.</TH>"
        vBody &= "<TH  style=""background:#5D7B9D""  bordercolor=""#000000""  align=""center"">COD PROD.</TH>"
        vBody &= "<TH  style=""background:#5D7B9D""  bordercolor=""#000000""  align=""center"">NOMBRE</TH>"
        vBody &= "<TH  style=""background:#5D7B9D""  bordercolor=""#000000""  align=""center"">LOTE FAB.</TH>"
        vBody &= "<TH  style=""background:#5D7B9D""  bordercolor=""#000000""  align=""center"">ORIGEN</TH>"
        vBody &= "<TH  style=""background:#5D7B9D""  bordercolor=""#000000""  align=""center"">COSTO</TH>"
        'vBody &= "</TH>"

        For i = 0 To dsBody.Tables(0).Rows.Count - 1
            vBody &= "<TR>"
            vBody &= "<TD bordercolor=""#000000""  align=""center"">" & dsBody.Tables(0).Rows(i).Item(0).ToString & "</TD>"
            vBody &= "<TD bordercolor=""#000000""  align=""center"">" & dsBody.Tables(0).Rows(i).Item(1).ToString & "</TD>"
            vBody &= "<TD bordercolor=""#000000""  align=""left"">" & dsBody.Tables(0).Rows(i).Item(2).ToString & "</TD>"
            vBody &= "<TD bordercolor=""#000000""  align=""right"">" & dsBody.Tables(0).Rows(i).Item(3).ToString & "</TD>"
            vBody &= "<TD bordercolor=""#000000""  align=""right"">" & dsBody.Tables(0).Rows(i).Item(4).ToString & "</TD>"
            vBody &= "<TD bordercolor=""#000000""  align=""right"">" & dsBody.Tables(0).Rows(i).Item(5).ToString & "</TD>"
            vBody &= "</TR>"

        Next
        vBody &= "</TABLE>"

        correo.Body = vBody
        correo.IsBodyHtml = True
        correo.CC.Add("sistemas@sociedadquimica.com.pe")
        correo.Priority = System.Net.Mail.MailPriority.Normal
        Dim smtp As New SmtpClient With {
            .Host = "smtp.gmail.com",
            .EnableSsl = True,
            .Port = "25"
        }
        correo.From = New System.Net.Mail.MailAddress(oPers.Correo.Trim, "SQM.Informacion", System.Text.Encoding.Default)
        smtp.Credentials = New System.Net.NetworkCredential(oPers.Correo.Trim, oPers.Contrasena.Trim)
        smtp.EnableSsl = True
        smtp.Send(correo)

    End Function

#End Region

#Region "ACTUALIZACIONES"

    Public Function ActuaClave(ByVal oPersona As BEPersona) As Boolean
        Dim bandera As Boolean
        If oPersona.Correo <> "" And oPersona.Contrasena <> "" Then
            bandera = oDALutil.ActuaClave(oPersona)
        Else
            bandera = False
        End If
        Return bandera
    End Function

#End Region

#Region "CONSULTAS"

    Public Function ListarFecha(ByVal oFechaServ As BELServidor) As DataSet
        Try
            Return oDALutil.FechaServidor(oFechaServ)
        Catch ex As Exception
            Throw
        Finally
            oDALutil = Nothing
        End Try
    End Function

#End Region

End Class
