
Public Class BELReserva

#Region "DECLARACION"

    Private bid As Integer
    Private bfecha As Date
    Private bgentrada As String
    Private borigen As String
    Private bestado As String

#End Region

#Region "PROPIEDAD"

    Public Property id() As Integer
        Get
            Return bid
        End Get
        Set(ByVal value As Integer)
            bid = value
        End Set
    End Property

    Public Property fecha() As Date
        Get
            Return bfecha
        End Get
        Set(ByVal value As Date)
            bfecha = value
        End Set
    End Property

    Public Property gentrada() As String
        Get
            Return bgentrada
        End Get
        Set(ByVal value As String)
            bgentrada = value
        End Set
    End Property

    Public Property origen() As String
        Get
            Return borigen
        End Get
        Set(ByVal value As String)
            borigen = value
        End Set
    End Property

    Public Property estado() As String
        Get
            Return bestado
        End Get
        Set(ByVal value As String)
            bestado = value
        End Set
    End Property

#End Region

End Class
