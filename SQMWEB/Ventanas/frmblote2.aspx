<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmblote2.aspx.vb" Inherits="Ventanas_frmblote2" %>

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
            style="font-size: x-small; font-family: verdana" width="100%">
            <tr>
                <td colspan="2" align="center" 
                    style="background-image: url('../../Imagenes/LOGOSQMBN.jpg')">
                    <img alt="" src="../Imagenes/LOGOSQMBN.jpg" 
                        style="width: 204px; height: 71px" /></td>
            </tr>
             <tr>
                <td align="left" class="style2" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                 </td>
            </tr>
            
            <tr>
                <td class="style2" colspan="2">
                    <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="grvlote" runat="server" CellPadding="4" ForeColor="#333333" 
                        AutoGenerateColumns="False" Width="450px" >
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="ID" />
                            <asp:BoundField DataField="origen" HeaderText="ORIGEN" />
                            <asp:BoundField DataField="lotefab" HeaderText="LOTE" />
                            <asp:BoundField DataField="Disponible" HeaderText="DISP." />
                            <asp:BoundField DataField="COSTO" HeaderText="COSTO" />
                            <asp:BoundField DataField="ubicacion" HeaderText="UBICACION" />
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
