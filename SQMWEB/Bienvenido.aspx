<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Bienvenido.aspx.vb" Inherits="Bienvenido" title=":: Intranet - Sociedad Quimica Mercantil S.A ::" %>

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
            height: 38px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

                        
                        <table align="center" class="style1" 
                            style="font-family: verdana; font-size: small">
                            <tr>
                                <td class="style2" style="font-size: medium; font-weight: bold">
                                    VISION</td>
                            </tr>
                            <tr>
                                <td>
                                    Ser en el año 2015 la empresa líder en la oferta de<br />
                                    productos y servicios para la industria textil del<br />
                                    mercado nacional.</td>
                            </tr>
                              <tr>
                                <td></td>
                            </tr>
                            
                            <tr>
                                <td class="style2" style="font-size: medium; font-weight: bold">
                                    MISION</td>
                            </tr>
                            <tr>
                                <td>
                                    Comercializamos insumos y equipos para la
                                    <br />
                                    industria textil con altos estándares de calidad
                                    <br />
                                    respaldados por un eficiente soporte técnico-<br />
                                    comercial, alcanzando la satisfacción de nuestros
                                    <br />
                                    clientes y de nuestros trabajadores, respetando
                                    <br />
                                    además la preservación del medio ambiente y el
                                    <br />
                                    bienestar de la sociedad.</td>
                            </tr>
    </table>
     <p align="right">&nbsp;</p>
                       
                        
                    


</asp:Content>


