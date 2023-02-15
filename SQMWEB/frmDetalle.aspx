<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="frmDetalle.aspx.vb" Inherits="frmDetalle" title=":: Intranet - Sociedad Quimica Mercantil S.A ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script language="javascript" src="Scripts\script_popup.js" type="text/javascript">
</script>
<script language="javascript" type="text/javascript">
	function Pagina_Consulta() 
	{	
    	var theForm = document.forms['aspnetForm'];
        if (!theForm) 
        {
            theForm = document.aspnetForm;
        }	
		 	theForm.action='frmDetalle.aspx';
		 	theForm.submit();
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
		
		
		
    <style type="text/css">
        .style1
        {
            height: 16px;
        }
        .style2
        {
            height: 23px;
        }
        .style3
        {
            height: 86px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table style="width: 900px; top: auto" >
<tr >
<td align="left" colspan="2" class="style3" >
       
           <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="verdana" 
               Font-Size="Small" Text="Productos a Fabricar"></asp:Label>
   
    
            <asp:GridView ID="grvfabrica" runat="server" CellPadding="4" 
                Font-Names="VERDANA" Font-Size="XX-Small" ForeColor="#333333" PageSize="10" 
                Width="890px" AutoGenerateColumns="False" AllowPaging="True">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" >
                        <ItemStyle ForeColor="Black" HorizontalAlign="Left" Width="50px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="CODFAB" HeaderText="CODFAB">
                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHA" HeaderText="FECHA" 
                        DataFormatString="{0:dd-MM-yyyy} " >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CODIGOF" HeaderText="CODIGOF" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDADF" HeaderText="CANTIDAD" >
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMBATCH" HeaderText="NRO. BATCH" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FF3300" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                    HorizontalAlign="Center" VerticalAlign="Middle" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
       
                    </td>
</tr>
<tr >
<td align="left" >
    
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" 
            Font-Size="Small" Text="Cantidad de Batch:"></asp:Label>
                           
                        <asp:Label ID="lblmens" runat="server" Font-Bold="True" Font-Names="verdana" 
                            Font-Size="Small" ForeColor="Red" Visible="False"></asp:Label>
    
                    </td><td align="right" >
                <asp:TextBox ID="txtcodigo" runat="server" BackColor="#F7F6F3" 
                    Font-Names="verdana" Font-Size="X-Small" Width="60px" TextMode="Password" 
                    Visible="False"></asp:TextBox>
    
                    <asp:Button ID="btnvalida" runat="server" BackColor="Red" Font-Bold="True" 
                        Font-Names="VERDANA" Font-Size="X-Small" ForeColor="White" 
                        Text="VALIDA" Width="74px" Visible="False" />
    
                        <asp:Button ID="Button1" runat="server" Text="FABRICA" Width="74px" 
                            BackColor="Red" Font-Bold="True" Font-Names="verdana" Font-Size="X-Small" 
                            ForeColor="White" Visible="False" style="height: 20px" /> &nbsp; &nbsp;   
                </td>
</tr>
<tr >
<td align="left" colspan="2" class="style2" >  
            <asp:GridView ID="grvcabbatch" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" Font-Names="verdana" Font-Size="XX-Small" ForeColor="#333333" 
                Width="890px" Visible="False">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True">
                        <ItemStyle ForeColor="Black" HorizontalAlign="Left" Width="50px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="CODFAB" HeaderText="CODFAB">
                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IDBATCH" HeaderText="IDBATCH" >
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CODIGOP" HeaderText="CODIGOP" >
                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TBATCH" HeaderText="TBATCH" />
                    <asp:BoundField DataField="UM" HeaderText="UM" >
                        <HeaderStyle HorizontalAlign="Center" Width="25px" />
                        <ItemStyle Width="25px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GENTRADA" HeaderText="GENTRADA" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ORIGENF" HeaderText="ORIGEN" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BASE" HeaderText="BASE" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FF3300" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                    HorizontalAlign="Center" VerticalAlign="Middle" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
   
    
            </td>
</tr>
<tr >
<td align="left" colspan="2" >
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="verdana" 
            Font-Size="Small" Text="Detalle de Batch:"></asp:Label>
                    </td>
</tr>
<tr >
<td colspan="2" >
            <asp:GridView ID="grvbatch" runat="server" 
                CellPadding="4" Font-Names="VERDANA" Font-Size="XX-Small" ForeColor="#333333" 
                PageSize="6" Width="890px" AutoGenerateColumns="False" 
                HorizontalAlign="Left" Visible="False">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" />
                <Columns>
                    <asp:BoundField DataField="CODFAB" HeaderText="CODFAB">
                        <ItemStyle ForeColor="Black" Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IDBATCH" HeaderText="IDBATCH">
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CODIGOP" HeaderText="CODIGOP" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="245px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" >
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UM" HeaderText="UM" >
                        <HeaderStyle HorizontalAlign="Center" Width="20px" />
                        <ItemStyle Width="20px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="QRESERVA" HeaderText="QRESERVA" >
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LOTEFAB" HeaderText="LOTEFAB" >
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ORIGEN" HeaderText="ORIGEN" >
                        <ItemStyle Width="45px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" >
                        <ItemStyle Width="45px" HorizontalAlign="Center" />
                    </asp:BoundField>
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
</table>







</asp:Content>

