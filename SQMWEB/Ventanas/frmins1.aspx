<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmins1.aspx.vb" Inherits="Ventanas_frmins1" %>

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
            width: 203px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table align="center" class="style1" 
            style="font-size: x-small; font-family: verdana" width="400">
            <tr>
                <td colspan="2" align="center" 
                    style="background-image: url('../../Imagenes/LOGOSQMBN.jpg')">
                    <img alt="" src="../Imagenes/LOGOSQMBN.jpg" 
                        style="width: 204px; height: 71px" /></td>
            </tr>
             <tr>
                <td align="center" class="style2" colspan="2" align ="left" width="450" >
                    Ingrese Nombre:
                    <asp:TextBox ID="txtnombre" runat="server" Font-Names="verdana" 
                        Font-Size="X-Small" Width="147px"></asp:TextBox>
&nbsp;
                    <asp:LinkButton ID="lnkbusca" runat="server">Busca ...</asp:LinkButton>
                 </td>
            </tr>
           
            <tr>
                <td class="style2" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="grvproductos" runat="server" CellPadding="4" 
                        ForeColor="#333333" Width="440px" >
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
