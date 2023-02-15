
Public Class BEPersona

#Region "DECLARACION"

    Private bDNI As Double
    Private bNombre As String
    Private bApePat As String
    Private bApeMat As String
    Private bSexo As String
    Private bDomic As String
    Private bFecNac As Date
    Private bOcupa As String
    Private bFecIng As Date
    Private btipusuario As Short
    Private bUsuario As String
    Private bClaveweb As String
    Private bSecurity As String
    Private bCorreo As String
    Private bContrasena As String

#End Region

#Region "PROPIEDAD"

    Public Property Contrasena() As String
        Get
            Return bContrasena
        End Get
        Set(ByVal value As String)
            bContrasena = value
        End Set
    End Property

    Public Property Correo() As String
        Get
            Return bCorreo
        End Get
        Set(ByVal value As String)
            bCorreo = value
        End Set
    End Property

    Public Property Security() As String
        Get
            Return bSecurity
        End Get
        Set(ByVal value As String)
            bSecurity = value
        End Set
    End Property

    Public Property Claveweb() As String
        Get
            Return bClaveweb
        End Get
        Set(ByVal value As String)
            bClaveweb = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return bUsuario
        End Get
        Set(ByVal value As String)
            bUsuario = value
        End Set
    End Property

    Public Property Tipusuario() As Short
        Get
            Return btipusuario
        End Get
        Set(ByVal value As Short)
            btipusuario = value
        End Set
    End Property

    Public Property DNI() As Double
        Get
            Return bDNI
        End Get
        Set(ByVal value As Double)
            bDNI = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return bNombre
        End Get
        Set(ByVal value As String)
            bNombre = value
        End Set
    End Property

    Public Property ApePat() As String
        Get
            Return bApePat
        End Get
        Set(ByVal value As String)
            bApePat = value
        End Set
    End Property

    Public Property ApeMat() As String
        Get
            Return bApeMat
        End Get
        Set(ByVal value As String)
            bApeMat = value
        End Set
    End Property

    Public Property Domic() As String
        Get
            Return bDomic
        End Get
        Set(ByVal value As String)
            bDomic = value
        End Set
    End Property


    Public Property FecNac() As Date
        Get
            Return bFecNac
        End Get
        Set(ByVal value As Date)
            bFecNac = value
        End Set
    End Property

    Public Property Sexo() As String
        Get
            Return bSexo
        End Get
        Set(ByVal value As String)
            bSexo = value
        End Set
    End Property

    Public Property Ocupa() As String
        Get
            Return bOcupa
        End Get
        Set(ByVal value As String)
            bOcupa = value
        End Set
    End Property

    Public Property FecIng() As String
        Get
            Return bFecIng
        End Get
        Set(ByVal value As String)
            bFecIng = value
        End Set
    End Property

#End Region

End Class
