'**************************************************************************
' (c) 2011 SQM - Sistemas / SOCIEDAD QUIMICA MERCANTIL   
' 
' Nombre .........: DAL_UTILITARIOS
' Objetivo........: DIVERSAS FUNCIONES
' Programador.....: MHUAROTO
' Fecha...........: 01/04/2011
' Version.........: 1.0.0
'**************************************************************************
#Region "IMPORT"

Imports BELSQM
Imports MySql.Data.MySqlClient
Imports System.Net.Mail

#End Region

Public Class DALUtilitario

#Region "DECLARACION"
    Private strcons As String
    Private ds01 As New DataSet
    Private CMD As New MySqlCommand
    Private cnx As New Coneccion
    Private MyDA As New MySqlDataAdapter(CMD)
    Private vexito As Boolean
#End Region

#Region "ACTUALIZAR"

    Public Function ActuaClave(ByVal oUsuario As BEPersona) As Boolean

        Try
            CMD.CommandText = "sp_actualiza_clave"
            CMD.Parameters.Clear()
            CMD.Parameters.AddWithValue("xusuario", oUsuario.Usuario)
            CMD.Parameters.AddWithValue("xcorreo", oUsuario.Correo)
            CMD.Parameters.AddWithValue("xclaveweb", oUsuario.Claveweb)
            CMD.Parameters.AddWithValue("xcontrasena", oUsuario.Contrasena)
            CMD.Parameters.AddWithValue("xsecurity", oUsuario.Security)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Connection = cnx.ObtenerConexion
            CMD.Connection.Open()
            CMD.ExecuteNonQuery()
            CMD.Connection.Close()
            vexito = True
        Catch ex As Exception
            CMD.Connection.Close()
            vexito = False
            Throw ex
        End Try
        Return vexito
    End Function

#End Region

#Region "CONSULTAS"

    Public Function FechaServidor(ByVal oFechaServ As BELServidor) As DataSet
        Try
            CMD.Parameters.Clear()
            strcons = "SELECT sysdate() AS FECHA"
            CMD.Connection = cnx.ObtenerConexion
            CMD.CommandText = strcons
            CMD.CommandType = CommandType.Text
            CMD.Connection.Open()
            ds01.Clear()
            MyDA.Fill(ds01)
            CMD.Connection.Dispose()
        Catch ex As Exception
            CMD.Connection.Close()
        End Try
        Return ds01

    End Function

#End Region

End Class
