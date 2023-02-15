<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Logueo.aspx.vb" Inherits="Logueo"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">   
<head runat="server">
    <title>:: Intranet - Sociedad Quimica Mercantil S.A ::</title>
      <script language="javascript" type='text/javascript'></script>

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
            width: 350px;
            height: 31px;
        }
        .style2
        {
            width: 165px;
            height: 33px;
        }
        .style3
        {
            width: 160px;
            height: 33px;
        }
        .style4
        {
            width: 165px;
            height: 40px;
        }
        .style5
        {
            width: 350px;
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="text-align: center">       
            <table border="0" cellpadding="0" cellspacing="0" style="width: 900px; height: 100%;">
                <tr>
                    <td align="right" colspan="4" style="background-image: url('Imagenes/banner.png'); vertical-align: text-bottom; height: 100px; width: 100%; text-align: right;">
                        
                        <tr style="background-image: url('Imagenes/banner.png'); vertical-align: text-bottom; height: 95px; width: 100%; text-align: right;">
            
                        <asp:Label ID="lblfecha" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana" Font-Size="X-Small" Text="Label" Width="412px"></asp:Label></td>
                </tr>
                <tr>
                    <td class="style1"></td>
                    <td colspan="2" class="style1"></td>
                    <td  title=":: Intranet - Sociedad Quimica Mercantil S.A ::" class="style1"></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 35px"><span style="font-size: 19pt; font-family: Verdana"><strong>Sociedad Quimica Mercantil</strong></span></td>
                </tr>
                <tr>
                    <td align="center" class="style4"></td>
                    <td align="center" colspan="2" class="style5"></td>
                    <td align="center" class="style4"></td>
                </tr>
                    <tr>
                    <td style="width: 100px; height: 40px; text-align: left; vertical-align: middle;"></td>
                    <td style="width: 160px; height: 20px; text-align: right;"><span style="font-size: 9pt; font-family: Verdana">Usuario :&nbsp;</span></td>
                    <td style="width: 165px; text-align: left;">
                        <asp:TextBox ID="txtUsuario" runat="server" font-names="Verdana" font-size="X-Small" Height="20px" Width="90px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Ingrese Usuario">+</asp:RequiredFieldValidator></td>
                    <td style="width: 100px; height: 40px; text-align: left; vertical-align: middle;"></td>
                </tr>
                <tr>
                    <td style="width: 165px; height: 40px; vertical-align: middle;"></td>
                    <td style="width: 160px; height: 20px; text-align: right;"><span style="font-size: 9pt"><span style="font-family: Verdana">Contraseña :&nbsp;</span></span></td>
                    <td style="width: 165px; text-align: left;">
                        <asp:TextBox ID="txtContrasena" runat="server" font-names="Verdana" font-size="X-Small" Height="20px" Width="90px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContrasena" ErrorMessage="Ingrese Contraseña">+</asp:RequiredFieldValidator> </td>
                    <td style="width: 165px; height: 40px; vertical-align: middle;"></td>
                </tr>
                <tr>
                    <td class="style2"></td>
                    <td style="text-align: right;" class="style3"></td>
                    <td style="text-align: left;" class="style2"></td>
                    <td class="style2"></td>
                </tr>
                <tr>
                    <td align="center" style="width: 165px; height: 15px;"></td>
                    <td align="center" style="width: 160px; height: 20px; text-align: right;"><asp:Button ID="btnIng" runat="server" BackColor="SteelBlue" BorderColor="Moccasin" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White" Height="30px" Text="Aceptar" Width="81px"/>&nbsp;</td>
                    <td align="center" style="width: 165px; text-align: left;">&nbsp;<asp:Button ID="btnExit" runat="server" BackColor="SteelBlue" BorderColor="Moccasin" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White" Height="30px" Text="Cancelar" Width="81px" /></td>
                    <td align="center" style="width: 165px; height: 35px;"></td>
                </tr>
                <tr>
                    <td align="center" style="width: 165px; height: 25px"></td>
                    <td align="center" style="width: 160px; height: 20px; text-align: right;"></td>
                    <td align="center" style="width: 165px; text-align: left;"></td>
                    <td align="center" style="width: 165px; height: 25px"></td>
                </tr>
                <tr>
                    <td style="width: 165px; height: 40px"></td>
                    <td colspan="2" style="height: 40px; width: 165px;">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderColor="Black" Font-Italic="True" Width="246px" />
                        <asp:Label ID="lblNoValido" runat="server" BorderColor="Black" Font-Bold="False" Font-Italic="True" Font-Size="9pt" ForeColor="Red" Style="position: static" Text="USUARIO O PASSWORD INCORRECTO" Visible="False" Width="300px"></asp:Label></td>
                    <td style="width: 165px; height: 40px"></td>
                </tr>       
                <tr>
                    <td colspan="4" style="height: 70px; text-align: right; background-image: url('Imagenes/banner_inf.png'); vertical-align: bottom; width: 100%;">
                        <span style="font-size: 10pt; color: #ffffff; font-family: Verdana"><strong><em>&nbsp; </em></strong>
                        <span style="font-size: 9pt; color: #ffffff; font-family: Verdana">© Copyright SQM Perú - 2014. Todos los Derechos reservados<br />
                        <span style="font-size: 7pt">Resolución Recomendada 1024 x 768</span></span> &nbsp;&nbsp;</span></td>
                </tr>
            </table>        

        </div>
    </div>
    </form>
</body>
</html>



