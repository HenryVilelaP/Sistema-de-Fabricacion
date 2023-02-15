<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="frmReporteCos.aspx.vb" Inherits="frmReporteCos" title="Página sin título" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

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
        .style2
        {
            width: 95%;
        }
               
        .style3
    {
    }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" width ="700px">
        <tr>
            <td colspan="2" 
                    style="font-family: VERDANA; font-size: small; font-weight: bold">
                    REPORTE DE FABRICACION DE PRODUCTO</td>
        </tr>
        <tr>
            <td class="style3">
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style3" 
                    style="font-family: verdana; font-size: x-small" colspan="2">
                Ingrese Código de Producto :
                <asp:TextBox ID="txtcodfabp" runat="server" Width="40px" Font-Names="VERDANA" 
                                                Font-Size="X-Small"></asp:TextBox>
                                        &nbsp; 
                <asp:Button ID="btnbusca" runat="server" Text="Genera Costos" 
                        Width="124px" BackColor="#5D7B9D" ForeColor="White" Font-Names="VERDANA" 
                        Font-Size="Small" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td align="center" class="style3" 
                                            
                style="font-family: VERDANA; font-size: x-small;" colspan="2">
                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300"   ></asp:Label>
                                        </td>
        </tr>
        <tr>
            <td class="style3">
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" 
                        AutoDataBind="true" 
                        EnableDatabaseLogonPrompt="False" ReuseParameterValuesOnRefresh="True" 
                        Width="350px" BorderStyle="Solid" GroupTreeStyle-Font-Names="Verdana" 
                        GroupTreeStyle-Font-Size="X-Small" HasRefreshButton="True" 
                        HasSearchButton="False" Height="50px" PageZoomFactor="90" 
                        ToolbarStyle-BackColor="#1892BB" ToolbarStyle-BorderColor="Black" 
                        ToolbarStyle-BorderStyle="Solid" ToolbarStyle-BorderWidth="1px" 
                        HasCrystalLogo="False" GroupTreeStyle-ForeColor="Black" 
                        ToolbarImagesFolderUrl="Imagenes/toolbar/" 
                    EnableParameterPrompt="False" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
        </tr>
    </table>
</asp:Content>

