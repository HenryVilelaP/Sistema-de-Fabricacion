<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="frmLLote.aspx.vb" Inherits="frmLLote" title=":: Intranet - Sociedad Quimica Mercantil S.A ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="javascript" src="Scripts\script.js" type="text/javascript">
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
        width: 100%;
    }
        .style2
        {
            height: 14px;
        }
        .style3
        {
            width: 646px;
        }
        .style4
        {
            width: 646px;
            height: 54px;
        }
        .style5
        {
            height: 54px;
        }
    </style>
    
  <script language="javascript" type="text/javascript">
	function Pagina_Consulta_lote() 
	{	
    	var theForm = document.forms['aspnetForm'];
        if (!theForm) 
        {
            theForm = document.aspnetForm;
        }	
		 	theForm.action='frmLLote.aspx';
		 	theForm.submit();
	}	
		</script>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
               
                            <table align="center" cellspacing="1" class="style1" 
                                style="font-family: verdaba; font-size: small; width: 100%;">
                                <tr>
                                    <td align="left" class="style3">
                                        Lotes sin Liberar: </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr align="left" >
                                    <td colspan="2" align="center" class="style2">
                                            <asp:GridView ID="grvlotes" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                                                Font-Names="verdana" Font-Size="XX-Small" ForeColor="#333333" 
                                                HorizontalAlign="Center" PageSize="5" Width="895px">
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <EditItemTemplate>
                                                            <img src="Imagenes/Lupa.gif" style="width: 16px; height: 16px" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Names="verdana" 
                                                                Font-Size="X-Small" ForeColor="Black">Seleccion</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="fingreso" DataFormatString="{0:dd-MM-yyyy} " 
                                                        HeaderText="F. ING">
                                                        <ItemStyle Width="80px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="T" HeaderText="T">
                                                        <ItemStyle Width="10px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="origen" HeaderText="ORIGEN">
                                                        <ItemStyle Width="60px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="producto" HeaderText="PRODUCTO" />
                                                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="qing" HeaderText="QING">
                                                        <ItemStyle Width="40px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="qven" HeaderText="QVEN">
                                                        <ItemStyle Width="40px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="qreserva" HeaderText="QRES">
                                                        <ItemStyle Width="40px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="qstandby" HeaderText="QSTAND">
                                                        <ItemStyle Width="40px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="quarantine" HeaderText="QUARANT">
                                                        <ItemStyle Width="40px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="qexterno" HeaderText="QEXT">
                                                        <ItemStyle Width="40px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="disponible" HeaderText="DISPONI">
                                                        <ItemStyle Width="40px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="costo" HeaderText="COSTO">
                                                        <ItemStyle Width="40px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="LOTEFAB" HeaderText="LOTEFAB" />
                                                </Columns>
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            </asp:GridView>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <br />

                                        <br />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style4">
                                        <br />
                                        <br />
                                    </td>
                                    <td class="style5">
                                        </td>
                                </tr>
                            </table>
                       
                        <p style="height: 50px">
                            &nbsp;</p>
                      
</asp:Content>


