<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmbuscapro.aspx.vb" Inherits="Ventanas_frmbuscapro" %>

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
            width: 100%;
        }
        .style2
        {
            height: 7px;
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
                <td align="right" class="style2">
                    </td>
                <td class="style2">
                    
                </td>
            </tr>
            <tr>
                <td align="right">
                    Ingrese Producto :
                </td>
                <td>
                    <asp:TextBox ID="txtproducto" runat="server" Font-Names="VERDANA" 
                        Font-Size="X-Small"></asp:TextBox>
                    <asp:Button ID="btnbusca" runat="server" BackColor="#5D7B9D" 
                        Font-Names="verdana" Font-Size="X-Small" ForeColor="White" Text="Busca" 
                        Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    
    </div>
                    <asp:GridView ID="grvproducto" runat="server" CellPadding="4"  Width ="100%"
                        ForeColor="#333333" AutoGenerateColumns="False" BorderColor="#5D7B9D" 
                        BorderStyle="Dashed" Font-Names="verdana" Font-Size="X-Small" PageSize="8">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="codigo" HeaderText="CODIGO" />
                            <asp:BoundField DataField="nombre" HeaderText="NOMBRE" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
    </form>
</body>
</html>
