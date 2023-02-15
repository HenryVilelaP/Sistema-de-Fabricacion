
#Region "IMPORT"

Imports System.Configuration
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

#End Region

Public Class Coneccion

    Public Function ObtenerConexion() As MySqlConnection
        Dim conexion As String = ConfigurationManager.ConnectionStrings("ConServer").ConnectionString
        Dim cnx As New MySqlConnection(conexion)
        Return cnx
    End Function

End Class

