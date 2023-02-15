<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmseguridad.aspx.vb" Inherits="Ventanas_frmseguridad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: Intranet - Sociedad Quimica Mercantil S.A ::</title>
    
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
    
    
    <style type="text/css">



        .style1
        {
            width: 219px;
        }
        .style2
        {
            width: 190px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <table align="center" class="style1" 
            style="font-size: x-small; font-family: verdana; width: 350px;">
            <tr>
                <td colspan="2" align="center" 
                    style="background-image: url('../../Imagenes/LOGOSQMBN.jpg')">
                    <img alt="" src="../Imagenes/LOGOSQMBN.jpg" 
                        style="width: 204px; height: 71px" /></td>
            </tr>
            
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td><td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" 
                        Text="LOTE ACTUALIZADO" Visible="False"></asp:Label>
                </td>
            </tr>
            
           <tr>
                <td class="style2">
                    El Lote se grabara con LOTEFAB:</td>
                <td>
                    <asp:TextBox ID="txtnombre" runat="server" Font-Names="verdana" 
                        Font-Size="X-Small" Width="127px" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="txtcosto" runat="server" Height="16px" 
                        Width="16px" AutoCompleteType="Disabled" Visible="False"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td class="style2">
                    ¿Ud. desea editarlo?</td>
                <td valign="baseline">
                    <asp:RadioButton ID="rbnsi" runat="server" Text="SI" AutoPostBack="True" />
                    <asp:RadioButton ID="rbnno" runat="server" Text="NO" AutoPostBack="True" />
                &nbsp;
                    <asp:Button ID="btneditar" runat="server" Font-Names="Verdana" 
                        Font-Size="X-Small" Text="Editar" />
                </td>
            </tr>
        </table>
    
    </form>
</body>
</html>
