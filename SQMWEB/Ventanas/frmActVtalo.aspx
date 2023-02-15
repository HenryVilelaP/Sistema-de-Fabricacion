<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmActVtalo.aspx.vb" Inherits="Ventanas_frmActVtalo" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: Intranet - Sociedad Quimica Mercantil S.A ::</title>
    <style type="text/css">

        .style1
        {
            width: 350px;
        }
        .style2
        {
            width: 165px;
        }
        .style3
        {
            width: 165px;
            height: 17px;
        }
        .style4
        {
            height: 17px;
        }
        </style>
</head>
<script language="javascript" type="text/javascript">
    function ValidarCampos()
    {    
        var txtNomMet = document.getElementById("txtclave");
        var sNomMet = txtNomMet.value;
        if(trim(sNomMet) == "")
        {
            txtNomMet.focus();
            alert('Ingrese tu clave');
            return false;
        }
        
        var txtInversa = document.getElementById("txtcantidad.Text");
        var sInversa = txtInversa.value;
        if(sInversa == "")
        {
            txtInversa.focus();
            alert('Ingrese la Cantidad');
            return false;
        }
      }
    
    function Cerrar()
    {    
        window.close();
        return false;
    }    
    
	function validaNumeroReal()
	{
		var tecla = window.event.keyCode;
		if ((tecla > 47 && tecla < 58)||(tecla == 46) || (tecla == 44))
		{}
		else
		{window.event.keyCode=0;}
	}
		
	function trim(cadena)
	{
		for(i=0; i<cadena.length; )
		{
			if(cadena.charAt(i)==" ")
				cadena=cadena.substring(i+1, cadena.length);
			else
				break;
		}

		for(i=cadena.length-1; i>=0; i=cadena.length-1)
		{
			if(cadena.charAt(i)==" ")
				cadena=cadena.substring(0,i);
			else
				break;
		}				
		return cadena;
	}						
    
</script>

<script language="JavaScript" type="text/javascript">
document.onkeydown = function(){   
    if(window.event && window.event.keyCode == 116){  
     window.event.keyCode = 505;   
    }  
    if(window.event && window.event.keyCode == 505){   
     return false;      
    }   
}
</script>


<body>
    <form id="form1" runat="server">
    <div>
    <table align="center" class="style1" 
            style="font-size: x-small; font-family: verdana">
            <tr>
                <td colspan="2" align="center" 
                    style="background-image: url('../../Imagenes/LOGOSQMBN.jpg')">
                    <img alt="" src="../Imagenes/LOGOSQMBN.jpg" 
                        style="width: 204px; height: 71px" /></td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Valida tu Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtclave" runat="server" Font-Names="Verdana" 
                        Font-Size="X-Small" Width="50px" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="btnvalida" runat="server" BackColor="#5D7B9D" 
                        Font-Names="Verdana" Font-Size="X-Small" ForeColor="White" Text="Validar" 
                        Width="57px" style="height: 20px" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Ingrese Cantidad a Liberar:" 
                        Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcantidad" runat="server" Font-Names="verdana" 
                        Font-Size="X-Small" style="margin-left: 0px" Visible="False" Width="50px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblres" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnliberar" runat="server" BackColor="#5D7B9D" Font-Bold="True" 
                        Font-Names="verdana" ForeColor="White" Text="Liberar" Visible="False" 
                        Width="100px" style="height: 26px" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    </td>
                <td class="style4">
                    </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
