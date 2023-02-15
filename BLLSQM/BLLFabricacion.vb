
#Region "IMPORT"

Imports BELSQM
Imports DALSQM

#End Region

Public Class BLLFabricacion

#Region "DECLARACION"

    Private BLLFabricacion As New DALFabricacion
    Private bllutil As New BLLUtilitario
    Private oPersona As New BEPersona

#End Region

#Region "INSERCIONES"

    Public Function Fabricacion(ByVal oFabric As BELFabric) As Boolean
        If BLLFabricacion.Fabricacion(oFabric) Then
            BLLFabricacion.Lab_det_reserva(oFabric)
            Return True
        End If
    End Function

    Public Function Dbatch(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.Dbatch(oFabric)
    End Function

    Public Function batch(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.Batch(oFabric)
    End Function

    Public Function mastersalidas(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.Mastersalidas(oFabric)
    End Function

    Public Function detallesalida(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.Detallesalida(oFabric)
    End Function

    Public Function formulas(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.Formulas(oFabric)
    End Function

    Public Function ProcesoKardex(ByVal oFabric As BELFabric) As Boolean
        Dim bandera As Boolean
        If BLLFabricacion.ProcesoKardex(oFabric) Then
            BLLFabricacion.ActuaLabDetReserva(oFabric)
        End If
        Return bandera
    End Function

#End Region

#Region "ACTUALIZACIONES"

    Public Function ActuaBacth(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.ActuaBacth(oFabric)
    End Function

    Public Function ActuaBacth1(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.ActuaBacth1(oFabric)
    End Function

    Public Function ActuaFBD(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.ActuaFBD(oFabric)

    End Function

    Public Function Actuavtalotes(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.Actuavtalotes(oFabric)
    End Function

    Public Function ActuaVtaLot(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.ActuaVtaLot(oFabric)
    End Function

    Public Function ActVtaLotsalres(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.ActVtaLotsalres(oFabric)
    End Function

    Public Function ActuavtalotesLoteFab(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.ActuavtalotesLoteFab(oFabric)
    End Function

    Public Function AnulaReserva(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.AnulaReserva(oFabric)
    End Function

#End Region

#Region "CONSULTAS"

    Private diction As New Dictionary(Of String, Double)

    Public Function ValidaUsuario(ByVal oPers As BEPersona) As DataSet
        Return BLLFabricacion.ValidaUsuario(oPers)
    End Function

    Public Function ConsProducto(ByVal oPro As BELProducto) As DataSet
        Return BLLFabricacion.ConsProducto(oPro)
    End Function

    'Consulta producto para agregar formula
    Public Function ConsProductoF(ByVal oPro As BELProducto) As DataSet
        Return BLLFabricacion.ConsProductoF(oPro)
    End Function

    Public Function ConsProductoxcodnoIngresado(ByVal oPro As BELProducto) As DataSet
        Return BLLFabricacion.ConsProductoxcodnoIngresado(oPro)
    End Function

    Public Function ConsUltimoLote(ByVal oFabric As BELFabric) As String
        Return BLLFabricacion.ConsUltimoLote(oFabric)
    End Function

    Public Function ConsFabrica() As DataSet
        Return BLLFabricacion.ConsFabrica
    End Function

    Public Function ConsDbatch(ByVal oFabr As BELFabric) As DataSet
        Return BLLFabricacion.ConsDbatch(oFabr)
    End Function

    Public Function Consbatch(ByVal oFabr As BELFabric) As DataSet
        Return BLLFabricacion.ConsBatch(oFabr)
    End Function

    Public Function ConsProductoxcod(ByVal oPro As BELProducto) As DataSet
        Return BLLFabricacion.ConsProductoxcod(oPro)
    End Function

    Public Function ConsdloteLibera() As DataSet
        Return BLLFabricacion.ConsdloteLibera()
    End Function

    Public Function ConsdloteLibera1(ByVal oFabr As BELFabric) As ArrayList
        Return BLLFabricacion.ConsdloteLibera1(oFabr)
    End Function

    Public Function ConsdlotePro(ByVal oPro As BELProducto) As DataSet
        Return BLLFabricacion.ConsdlotePro(oPro)
    End Function

    Public Function ConsdProducto(ByVal oPro As BELProducto) As DataSet
        Return BLLFabricacion.ConsdProducto(oPro)
    End Function

    Public Function ConsMaxCod() As Double
        Return BLLFabricacion.ConsMaxCod()
    End Function

    Public Function ConsIdlote(ByVal oFabr As BELFabric) As DataSet
        Return BLLFabricacion.ConsIdlote(oFabr)
    End Function

    Public Function ConsAgrabarDeSali(ByVal oFabr As BELFabric) As DataSet
        Return BLLFabricacion.ConsAgrabarDeSali(oFabr)
    End Function

    Public Function ValidaAnulacion(ByVal oFabric As BELFabric) As String
        Return BLLFabricacion.ValidaAnulacion(oFabric)
    End Function

    Public Function ConsVtaLot(ByVal oFabric As BELFabric) As DataSet
        Return BLLFabricacion.ConsVtaLot(oFabric)
    End Function

    Public Function ConsBase_mezcla() As DataSet
        Return BLLFabricacion.ConsBase_mezcla
    End Function

    'Public Function ConsProductoCero(ByVal oFabr As BELFabric) As DataSet
    '    Return BLLFabricacion.ConsProductoCero(oFabr)
    'End Function

    '-----------------------------------------------------------------
    '---------------------KARDEX--------------------------------------
    '-----------------------------------------------------------------

    Public Function ConsDbatch_K(ByVal oFabr As BELFabric) As Dictionary(Of String, Double)
        diction = ConsDbatch_K(oFabr)
        Return diction
    End Function

    Public Function ConsFilaDBatch(ByVal oFabr As BELFabric) As Integer
        Return BLLFabricacion.ConsFilaDBatch(oFabr)
    End Function

#End Region

#Region "ELIMINACIONES"

    Public Function EliminaFormula(ByVal oFabric As BELFabric) As Boolean
        Return BLLFabricacion.EliminaFormula(oFabric)
    End Function

#End Region

End Class
