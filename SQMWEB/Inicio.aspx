<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Inicio.aspx.vb" Inherits="Inicio" title=":: Intranet - Sociedad Quimica Mercantil S.A ::" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <script language="javascript" src="Scripts\script_popup.js" type="text/javascript"></script>
<script language="javascript" src="Scripts\script.js" type="text/javascript"></script>
<script language="javascript" src="Scripts\Jscript2.js" type="text/javascript"></script>

<script language="JavaScript" type="text/javascript">
document.onkeydown = function(){   
    if(window.event && window.event.keyCode == 116){  
     window.event.keyCode = 505;   
    }  
    if(window.event && window.event.keyCode == 505){   
     return false;      
    }   
}
  
      function cambiarFoco(idBoton)
{
    var boton = document.getElementById(idBoton);  
    boton.focus();
}

</script>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.numeric.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".numeric").numeric();
            $(".numeric").focus(function () { $(this).css("background-color", "#ECF8E0"); });
            $(".numeric").blur(function () { $(this).css("background-color", "white"); });
        });    
    </script>
    
         <%--<script language="javascript" type="text/javascript">
        $().ready(function() {
            $("#<%=CheckBox1.ClientID%>").click(function() {
                var seleccionado = true;
                $("#<%=CheckBox1.ClientID%>").each(function() {
                    if (this.checked)
                        seleccionado = false;
                });
                var botondeshabilitar = $("#<%=grvBase.ClientID%>");
                var botondeshabilitar1 = $("#<%=grvBase1.ClientID%>");                  
                if (seleccionado)
                {  botondeshabilitar.removeAttr('disabled'); 
                   botondeshabilitar1.attr('disabled', 'disabled');
                   document.getElementById(grvBase1).style.display="none";
                   document.getElementById(grvBase).style.display="block";
                   document.getElementById(txtcant).value=" ";
                   document.getElementById(txtnrobacth).value=" ";
                 }
                else 
                {  botondeshabilitar.attr('disabled', 'disabled'); 
                   botondeshabilitar1.removeAttr('disabled'); 
                   document.getElementById(grvBase).style.display="none";
                   document.getElementById(grvBase1).style.display="block";  }
            })
        });
    </script>--%>
    

   
    <script type="text/javascript">
        var Label8 = '<%=Label8.ClientID%>';
        var Label9 = '<%=Label9.ClientID%>';
        var txt21 = '<%=txt21.ClientID%>';
        var Label27 = '<%=Label27.ClientID%>';
        
        var Label13 = '<%=Label13.ClientID%>';
        var Label14 = '<%=Label14.ClientID%>';
        var txt22 = '<%=txt22.ClientID%>';
        var Label28 = '<%=Label28.ClientID%>';
        
        var Label17 = '<%=Label17.ClientID%>';
        var Label19 = '<%=Label19.ClientID%>';
        var txt23 = '<%=txt23.ClientID%>';
        var Label29 = '<%=Label29.ClientID%>';
        
        var Label18 = '<%=Label18.ClientID%>';
        var Label20 = '<%=Label20.ClientID%>';
        var txt24 = '<%=txt24.ClientID%>';
        var Label30 = '<%=Label30.ClientID%>';
        
        var txtcant='<%=txtcant.ClientID%>';
        var txtnrobacth='<%=txtnrobacth.ClientID%>';
             
        var grvBase= '<%=grvBase.ClientID%>';
        var grvBase1 = '<%=grvBase1.ClientID%>';

        
        var btngraba = '<%=btngraba.ClientID%>';        
        
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style4
        {
            height: 129px;
        }
        .style11
        {
            width: 189px;
        }
        .style12
        {
            height: 16px;
            width: 189px;
        }
        .style13
        {
            height: 16px;
        }
        .style14
        {
            width: 155px;
            height: 3px;
        }
        .style15
        {
            height: 3px;
        }
        .style19
        {
            width: 100px;
        }
        .style20
        {
            width: 124px;
        }
        .style23
        {
            width: 171px;
        }
        .style24
        {
            height: 16px;
            }
        .style25
        {
            height: 3px;
            }
        .style27
        {
            width: 110px;
        }
        .style28
        {
            width: 120px;
        }
        .style29
        {
            width: 889px;
        }
        .style30
        {
            width: 51px;
        }
        .style31
        {
            width: 665px;
        }
        .style32
        {
            width: 129px;
        }
        .style33
        {
            width: 155px;
        }
        .style34
        {
            height: 16px;
            width: 155px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    
                    
        <br />
    
        <table  class="style1" 
            style="font-family: verdana; font-size: x-small; height: 250px;" 
            width="20">
            <tr>
                <td align="left" class="style33">
                    Producto a Fabricar:&nbsp;&nbsp;&nbsp; </td>
                <td colspan="3" align ="left">        
                    <asp:TextBox ID="txtcodpro" runat="server" Width="60px" Font-Names="verdana" Font-Size="X-Small"></asp:TextBox>
                    <asp:TextBox ID="txtproducto" runat="server" Width="400px" Font-Names="verdana" Font-Size="X-Small"></asp:TextBox>
                    <img alt="" src="Imagenes/Lupa.gif" onclick="pop_producto()" style="width: 16px; height: 16px"  id="lupa0"/>&nbsp;
                                    </td>
            </tr>
            <tr>
                <td align="left" class="style33">Nro. Orden de Fabricacion:</td>
                <td align="left" class="style23">
                    <asp:TextBox ID="txtorfa" runat="server" Width="60px" Font-Names="verdana" 
                        Font-Size="X-Small"></asp:TextBox>
                                    </td>
                <td align="left" class="style11">
                    &nbsp;Fecha:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtfecha" runat="server" Width="70px" Font-Names="verdana" 
                        Font-Size="X-Small"></asp:TextBox>
                                    </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" class="style34">Cantidad a Fabricar:</td>
                <td align="left" class="style23">
                    <asp:TextBox ID="txtcant" runat="server" Width="60px" Font-Names="verdana" 
                        Font-Size="X-Small"></asp:TextBox>
                </td>
                <td align="left" class="style12">
                    Nro. de Batch:
                    <asp:TextBox ID="txtnrobacth" runat="server" Width="40px" Font-Names="verdana" 
                        Font-Size="X-Small" AutoPostBack="True"></asp:TextBox>
                </td>
                <td align="left" class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" class="style34">Base:</td>
                <td align="left" class="style23">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Manual" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"  />
                </td>
                <td align="left" class="style12">
                    &nbsp;</td>
                <td align="left" class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" class="style34">
                    &nbsp;</td>
                <td align="left"  colspan="2" >
                            <asp:GridView ID="grvBase" runat="server" Width="260px" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                        ShowFooter="True" EnableTheming="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField HeaderText="id" DataField="id" ReadOnly="True" Visible="False" >
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="base" FooterStyle-HorizontalAlign="Center" 
                                ControlStyle-Width="70px" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label10" runat="server"  
                                           Text='<%# eval("peso_kg") %>'  Width="70px"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="70px"></ControlStyle>
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="cantidad" FooterStyle-HorizontalAlign="Center" 
                                ControlStyle-Width="70px" >
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="cant1" runat="server" 
                                    Width="62px" Height="13px" Font-Names="verdana"  Font-Size="X-Small"  
                                    Enabled="True" ReadOnly="False"  CssClass="numeric" MaxLength="10" Text="0" />
                                        </ItemTemplate>
                                        <ControlStyle Width="60px"></ControlStyle>
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                        <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="batch" FooterStyle-HorizontalAlign="Center" 
                                ControlStyle-Width="70px" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="0" ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btnCalcular" runat="server" 
                                           Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="X-Small" 
                                           Font-Strikeout="False" Font-Underline="False" Height="18px" 
                                           onclick="btnCalcular_Click" Text="CALCULAR" Width="73px"  />
                                        </FooterTemplate>
                                        <ControlStyle Width="60px" />
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                        <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            
                    
                            <asp:GridView ID="grvBase1" runat="server" Width="260px" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                        ShowFooter="True" EnableTheming="True" Visible="False"> <%--style="display:none"--%>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                                <Columns>
                                    <asp:TemplateField HeaderText="base" FooterStyle-HorizontalAlign="Center" 
                                ControlStyle-Width="70px" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="base2" runat="server" 
                                    Width="62px" Height="13px" Font-Names="verdana"  Font-Size="X-Small"  
                                    Enabled="True" ReadOnly="False"  CssClass="numeric" MaxLength="10" text="0.00" />
                                        </ItemTemplate>
                                        <ControlStyle Width="70px"></ControlStyle>
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="cantidad" FooterStyle-HorizontalAlign="Center" ControlStyle-Width="70px" >
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="cant2" runat="server" 
                                    Width="62px" Height="13px" Font-Names="verdana"  Font-Size="X-Small"  
                                    Enabled="True" ReadOnly="False"  CssClass="numeric" MaxLength="10" Text="0.00" />
                                        </ItemTemplate>
                                        <ControlStyle Width="60px"></ControlStyle>
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                        <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="batch" FooterStyle-HorizontalAlign="Center" 
                                ControlStyle-Width="70px" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label32" runat="server" Text="0" ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btnCalcular0" runat="server" 
                                           Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="X-Small" 
                                           Font-Strikeout="False" Font-Underline="False" Height="18px" 
                                           onclick="btnCalcular1_Click" Text="CALCULAR" Width="73px"  />
                                        </FooterTemplate>
                                        <ControlStyle Width="60px" />
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                        <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                   
                    
                </td>
                <td align="left" class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" class="style34">
                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True">Visualizar 
                    Formula</asp:LinkButton>
                </td>
                <td align="left" class="style24" colspan="2">
                    </td>
                <td align="left" class="style13">                     
                    </td>
            </tr>
            <tr>
                <td align="left" class="style14">
                    
                </td>
                <td align="left" class="style25" colspan="2">
                    </td>
                <td align="left" class="style15">
                    </td>
            </tr>
            <tr>
                <td align="left" colspan="4" class="style4">
                    <table  class="style29" border="2" cellpadding="1" >
                        <tr>
                            <td class="style30">
                                &nbsp;</td>
                            <td class="style20">
                                <asp:Label ID="lblcodigo" runat="server" Text="CODIGO" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="style31">
                                <asp:Label ID="lblproducto" runat="server" Text="PRODUCTO" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="style32">
                                <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="PORCENTAJE"></asp:Label>
                            </td>      
                             <td class="style19">    
                                 <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="RESERVA"></asp:Label>                             
                            </td>
                            <td class="style28">
                                <asp:Label ID="lblorigen" runat="server" Text="ORIGEN" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="style27">
                                <asp:Label ID="lbllote" runat="server" Text="LOTE" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style30">
                                <img alt="" src="Imagenes/Lupa.gif" onclick="pop_lot()" style="width: 16px; height: 16px"  id="lupa1" /></td>
                            <td class="style20">
                                <asp:Label ID="Label8" runat="server" Text="."></asp:Label>
                            </td>
                            <td class="style31">
                                <asp:Label ID="Label9" runat="server" Text="."></asp:Label>
                            </td>
                            <td align="right" class="style32">                    
                                <asp:TextBox ID="txt21" runat="server" BorderWidth="0px" Font-Names="VERDANA" 
                                    Font-Size="XX-Small" ReadOnly="True" Width="60px"></asp:TextBox>    
                            </td>
                            <td align="right" class="style19">       
                                <asp:Label ID="Label27" runat="server" Text="."></asp:Label>                       
                            </td>
                            <td class="style28">
                                <asp:TextBox ID="txtorg1" runat="server" BorderWidth="0px" 
                                    Font-Names="verdana" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                            <td class="style27">
                                <asp:TextBox ID="txtlot1" runat="server" BorderWidth="0px" 
                                    Font-Names="verdana" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style30">
                                <img alt="" src="Imagenes/Lupa.gif" onclick="pop_lot1()" style="width: 16px; height: 16px"  id="lupa2"/></td>
                            <td class="style20">
                                <asp:Label ID="Label13" runat="server" Text="."></asp:Label>
                            </td>
                            <td class="style31">
                                <asp:Label ID="Label14" runat="server" Text="."></asp:Label>
                            </td>
                            <td align="right" class="style32">                     
                                <asp:TextBox ID="txt22" runat="server" BorderWidth="0px" Font-Names="VERDANA" 
                                    Font-Size="XX-Small" Height="16px" ReadOnly="True" Width="60px"></asp:TextBox>     
                            </td>
                            <td align="right" class="style19">
                                <asp:Label ID="Label28" runat="server" Text="."></asp:Label>                     
                            </td>
                            
                            <td class="style28">
                                <asp:TextBox ID="txtorg2" runat="server" BorderWidth="0px" 
                                    Font-Names="verdana" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                            <td class="style27">
                                <asp:TextBox ID="txtlot2" runat="server" BorderWidth="0px" 
                                    Font-Names="verdana" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style30">
                                <img alt="" src="Imagenes/Lupa.gif" onclick="pop_lot2()" style="width: 16px; height: 16px"  id="lupa3"/></td>
                            <td class="style20">
                                <asp:Label ID="Label17" runat="server" Text="."></asp:Label>
                            </td>
                            <td class="style31">
                                <asp:Label ID="Label19" runat="server" Text="."></asp:Label>
                            </td>
                            <td align="right" class="style32"> 
                                <asp:TextBox ID="txt23" runat="server" BorderWidth="0px" Font-Names="VERDANA" 
                                    Font-Size="XX-Small" ReadOnly="True" Width="60px" Height="16px"></asp:TextBox>      
                            </td>
                            <td align="right" class="style19">                                                               
                                <asp:Label ID="Label29" runat="server" Text="."></asp:Label>                                                   
                            </td>
                            <td class="style28">
                                <asp:TextBox ID="txtorg3" runat="server" BorderWidth="0px" 
                                    Font-Names="verdana" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                            <td class="style27">
                                <asp:TextBox ID="txtlot3" runat="server" BorderWidth="0px" 
                                    Font-Names="Verdana" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style30">
                                <img alt="" src="Imagenes/Lupa.gif" onclick="pop_lot3()" style="width: 16px; height: 16px" id="lupa4" /></td>
                            <td class="style20">
                                <asp:Label ID="Label18" runat="server" Text="."></asp:Label>
                            </td>
                            <td class="style31">
                                <asp:Label ID="Label20" runat="server" Text="."></asp:Label>
                            </td>
                            <td align="right" class="style32">  
                                <asp:TextBox ID="txt24" runat="server" BorderWidth="0px" Font-Names="VERDANA" 
                                    Font-Size="XX-Small" ReadOnly="True" Width="60px"></asp:TextBox>  
                            </td>
                            <td align="right" class="style19">
                                <asp:Label ID="Label30" runat="server" Text="."></asp:Label>
                            </td>
                            <td class="style28">
                                <asp:TextBox ID="txtorg4" runat="server" BorderWidth="0px" 
                                    Font-Names="verdana" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                            <td class="style27">
                                <asp:TextBox ID="txtlot4" runat="server" BorderWidth="0px" 
                                    Font-Names="verdana" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" class="style17">
                    <asp:Label ID="lblmensaje" runat="server" Font-Bold="True" Font-Names="verdana" 
                        Font-Size="Small" ForeColor="#FF3300"></asp:Label>
                </td>
                <td align="right" class="style11">
                                </td>
                <td align="left" class="style17">
                    <asp:Button ID="btngraba" runat="server" BackColor="#5D7B9D" Font-Bold="True" 
                        Font-Names="verdana" Text="Grabar" 
                          style="height: 40px" ForeColor="White" Height="25px" ToolTip="Grabar"/>
                    <br />
                </td>
            </tr>
                       
        </table>
        

                       
   </asp:Content>


