
Public Class BELProducto

#Region "DECLARACION"

    Private bcodigo As String
    Private bnombre As String
    Private bcolor As String
    Private bproveedor As String
    Private bcostoreal As Double
    Private bcostoreposicion As Double

#End Region

#Region "PROPIEDAD"

    Public Property costoreal() As Double
        Get
            Return bcostoreal
        End Get
        Set(ByVal value As Double)
            bcostoreal = value
        End Set
    End Property

    Public Property costoreposicion() As Double
        Get
            Return bcostoreposicion
        End Get
        Set(ByVal value As Double)
            bcostoreposicion = value
        End Set
    End Property

    Public Property codigo() As String
        Get
            Return bcodigo
        End Get
        Set(ByVal value As String)
            bcodigo = value
        End Set
    End Property

    Public Property nombre() As String
        Get
            Return bnombre
        End Get
        Set(ByVal value As String)
            bnombre = value
        End Set
    End Property

    Public Property color() As String
        Get
            Return bcolor
        End Get
        Set(ByVal value As String)
            bcolor = value
        End Set
    End Property

    Public Property proveedor() As String
        Get
            Return bproveedor
        End Get
        Set(ByVal value As String)
            bproveedor = value
        End Set
    End Property

#End Region

End Class
