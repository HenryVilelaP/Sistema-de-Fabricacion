<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="frmAnula.aspx.vb" Inherits="frmAnula" title=":: Intranet - Sociedad Quimica Mercantil S.A ::" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
        .style3
    {
        }
        .style4
        {
            width: 445px;
        }
        .style5
        {
            width: 445px;
            height: 30px;
        }
        .style6
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<ajax:AjaxPanel ID="AjaxPanel1" runat="server" Width="625px">--%>
    <table class="style1" width="700px">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style5" 
                style="font-family: verdana; font-size: x-small">
                <b>Ingrese la Orden de Fabricación Anular:</b>
            </td>
            <td align="left" valign="bottom" class="style6">
                <asp:TextBox ID="txtcodfab" runat="server" Font-Names="VERDANA" 
                    Font-Size="X-Small" Width="40px"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnanula" runat="server" BackColor="#5D7B9D" Font-Bold="True" 
                    Font-Names="VERDANA" Font-Size="Small" ForeColor="White" Text="Anular" 
                    Width="66px" ToolTip="Anula la Reserva" />
                
            </td>
        </tr>
        <tr>
            <td  align="center" class="style3" 
                style="font-family: VERDANA; font-size: x-small;" colspan="2">
                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300"   ></asp:Label>
            </td>
        </tr>
    </table>
    <%--</ajax:AjaxPanel>--%>
</asp:Content>

