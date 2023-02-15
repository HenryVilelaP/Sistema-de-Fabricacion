
Public Class BELServidor

#Region "DECLARACION"

    Private bfechaServ As Date

#End Region

#Region "PROPIEDAD"

    Public Property fechaServ() As Date
        Get
            Return bfechaServ
        End Get
        Set(ByVal value As Date)
            bfechaServ = value
        End Set
    End Property

#End Region

End Class
