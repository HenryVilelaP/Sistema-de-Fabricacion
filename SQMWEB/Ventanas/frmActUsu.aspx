<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmActUsu.aspx.vb" Inherits="Ventanas_frmActUsu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    
    
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
            width: 369px;
        }
        .style2
        {
            width: 165px;
        }
        </style>
</head>
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
                    Ingrese Usuario:</td>
                <td>
                    <asp:TextBox ID="txtusuario" runat="server" Font-Names="Verdana" 
                        Font-Size="X-Small" Width="50px"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Clave:</td>
                <td>
                    <asp:TextBox ID="txtclave" runat="server" Font-Names="verdana" 
                        Font-Size="X-Small" style="margin-left: 0px" Width="50px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Security:</td>
                <td>
                    <asp:TextBox ID="txtsecurity" runat="server" Font-Names="verdana" 
                        Font-Size="X-Small" style="margin-left: 0px" Width="50px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td class="style2">
                    Correo electrónico</td>
                <td>
                    <asp:TextBox ID="txtcorreo" runat="server" Font-Names="verdana" 
                        Font-Size="X-Small" style="margin-left: 0px" Width="234px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    Contraseña</td>
                <td>
                    <asp:TextBox ID="txtcontrasena" runat="server" Font-Names="verdana" 
                        Font-Size="X-Small" style="margin-left: 0px" Width="90px" 
                        TextMode="Password">&amp;</asp:TextBox>
                </td>
            </tr>
            
             <tr>
                <td class="style2">
                    Confirma contraseña</td>
                <td>
                    <asp:TextBox ID="txtcontrasena2" runat="server" Font-Names="verdana" 
                        Font-Size="X-Small" style="margin-left: 0px" Width="90px" 
                        TextMode="Password">%</asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="style2">
                    <asp:Label ID="lblres" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnactualiza" runat="server" BackColor="#5D7B9D" Font-Bold="False" 
                        Font-Names="verdana" ForeColor="White" Text="Actualizar" 
                        Width="85px" Font-Size="Small" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td style="color: #FF0000">
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Editar" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
