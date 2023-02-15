
Public Class BELFabric

#Region "DECLARACION"

    Private bfecha As Date
    Private bcodfab As String 'codigo de fabricacion
    Private bcodins As String
    Private bcodigof As String 'codigo del producto q se va fabricar
    Private bcantidad As Double 'cantidad del producto a fabricar
    Private bnumbatch As Integer ' numeros de batch
    Private bestado As String ' estado de fabricacion
    Private borigen As String 'origen del producto por batch
    Private blotefab As String
    Private bidlote As Integer
    Private bidbatch As Integer
    Private bgreserva As Double
    Private bgsaldov As Double
    Private btbatch As Double
    Private bcantidadp As Double
    Private bgentrada As String
    Private bcosto As Double
    Private btipodoc As String
    Private binsvisadox As String
    Private bresultado As String
    Private brecibio As String
    Private bfecfab As Date
    Private bhorain As Date
    Private bhorafin As Date
    Private bfecEntM As Date
    Private bhora2 As Date
    Private bvbdirtec As String
    Private bobservacion As String
    Private bunicosal As Integer
    Private bunicoent As Integer
    Private bbase As Double
    Private bporcentaje As Double

#End Region

#Region "PROPIEDAD"

    Public Property observacion() As String
        Get
            Return bobservacion
        End Get
        Set(ByVal value As String)
            bobservacion = value
        End Set
    End Property

    Public Property gsaldov() As Double
        Get
            Return bgsaldov
        End Get
        Set(ByVal value As Double)
            bgsaldov = value
        End Set
    End Property

    Public Property vbdirtec() As String
        Get
            Return bvbdirtec
        End Get
        Set(ByVal value As String)
            bvbdirtec = value
        End Set
    End Property

    Public Property hora2() As String
        Get
            Return bhora2
        End Get
        Set(ByVal value As String)
            bhora2 = value
        End Set
    End Property

    Public Property fecEntM() As Date
        Get
            Return bfecEntM
        End Get
        Set(ByVal value As Date)
            bfecEntM = value
        End Set
    End Property

    Public Property horafin() As String
        Get
            Return bhorafin
        End Get
        Set(ByVal value As String)
            bhorafin = value
        End Set
    End Property

    Public Property horain() As String
        Get
            Return bhorain
        End Get
        Set(ByVal value As String)
            bhorain = value
        End Set
    End Property

    Public Property fecfab() As Date
        Get
            Return bfecfab
        End Get
        Set(ByVal value As Date)
            bfecfab = value
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


    Public Property recibio() As String
        Get
            Return brecibio
        End Get
        Set(ByVal value As String)
            brecibio = value
        End Set
    End Property

    Public Property resultado() As String
        Get
            Return bresultado
        End Get
        Set(ByVal value As String)
            bresultado = value
        End Set
    End Property

    Public Property insvisadox() As String
        Get
            Return binsvisadox
        End Get
        Set(ByVal value As String)
            binsvisadox = value
        End Set
    End Property

    Public Property tipodoc() As String
        Get
            Return btipodoc
        End Get
        Set(ByVal value As String)
            btipodoc = value
        End Set
    End Property

    Public Property costo() As Double
        Get
            Return bcosto
        End Get
        Set(ByVal value As Double)
            bcosto = value
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

    Public Property tbatch() As Double
        Get
            Return btbatch
        End Get
        Set(ByVal value As Double)
            btbatch = value
        End Set
    End Property

    Public Property codins() As String
        Get
            Return bcodins
        End Get
        Set(ByVal value As String)
            bcodins = value
        End Set
    End Property

    Public Property cantidadp() As Double
        Get
            Return bcantidadp
        End Get
        Set(ByVal value As Double)
            bcantidadp = value
        End Set
    End Property


    Public Property greserva() As Double
        Get
            Return bgreserva
        End Get
        Set(ByVal value As Double)
            bgreserva = value
        End Set
    End Property

    Public Property idbatch() As Integer
        Get
            Return bidbatch
        End Get
        Set(ByVal value As Integer)
            bidbatch = value
        End Set
    End Property

    Public Property idlote() As Integer
        Get
            Return bidlote
        End Get
        Set(ByVal value As Integer)
            bidlote = value
        End Set
    End Property

    Public Property lotefab() As String
        Get
            Return blotefab
        End Get
        Set(ByVal value As String)
            blotefab = value
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

    Public Property numbatch() As Integer
        Get
            Return bnumbatch
        End Get
        Set(ByVal value As Integer)
            bnumbatch = value
        End Set
    End Property

    Public Property cantidad() As Double
        Get
            Return bcantidad
        End Get
        Set(ByVal value As Double)
            bcantidad = value
        End Set
    End Property



    Public Property codfab() As String
        Get
            Return bcodfab
        End Get
        Set(ByVal value As String)
            bcodfab = value
        End Set
    End Property

    Public Property codigof() As String
        Get
            Return bcodigof
        End Get
        Set(ByVal value As String)
            bcodigof = value
        End Set
    End Property

    Public Property unicosal() As Integer
        Get
            Return bunicosal
        End Get
        Set(ByVal value As Integer)
            bunicosal = value
        End Set
    End Property

    Public Property unicoent() As Integer
        Get
            Return bunicoent
        End Get
        Set(ByVal value As Integer)
            bunicoent = value
        End Set
    End Property

    Public Property base() As Double
        Get
            Return bbase
        End Get
        Set(ByVal value As Double)
            bbase = value
        End Set
    End Property

    Public Property porcentaje() As Double
        Get
            Return bporcentaje
        End Get
        Set(ByVal value As Double)
            bporcentaje = value
        End Set
    End Property

#End Region

End Class
