<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="frmAgrFor.aspx.vb" Inherits="frmAgrFor" title=":: Intranet - Sociedad Quimica Mercantil S.A ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <script language="javascript" src="Scripts\JScriptinsumo.js" type="text/javascript"></script>
  <script language="javascript" src="Scripts\script_limpiar.js" type="text/javascript"> </script>

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

<script type="text/javascript" language="javascript">  
function sumar1() {  
var a, b,c,d, r;     
    a = document.getElementById('<%=TextBox3.ClientID %>').value;  
    b = document.getElementById('<%=TextBox6.ClientID %>').value;  
    c = document.getElementById('<%=TextBox9.ClientID %>').value;  
    d = document.getElementById('<%=TextBox12.ClientID %>').value;
        if( a=='') { a='0' };
        if( b=='') { b='0' };
        if( c=='') { c='0' };
        if( d=='') { d='0' }; 
        a=Math.round(parseFloat(a)*Math.pow(10,3))/Math.pow(10,3);
        b=Math.round(parseFloat(b)*Math.pow(10,3))/Math.pow(10,3);
        c=Math.round(parseFloat(c)*Math.pow(10,3))/Math.pow(10,3);
        d=Math.round(parseFloat(d)*Math.pow(10,3))/Math.pow(10,3);
 
    r = a + b + c + d; 
    if( a=='0') { a='0.000' };
    r=Math.round(parseFloat(r)*Math.pow(10,3))/Math.pow(10,3);
document.getElementById('<%=Label3.ClientID %>').innerHTML = r; 
document.getElementById('<%=TextBox3.ClientID %>').value=a;  

}  
</script> 
<script type="text/javascript" language="javascript">  
function sumar2() {  
var a, b,c,d, r;     
    a = document.getElementById('<%=TextBox3.ClientID %>').value;  
    b = document.getElementById('<%=TextBox6.ClientID %>').value;  
    c = document.getElementById('<%=TextBox9.ClientID %>').value;  
    d = document.getElementById('<%=TextBox12.ClientID %>').value;
        if( a=='') { a='0' };
        if( b=='') { b='0' };
        if( c=='') { c='0' };
        if( d=='') { d='0' }; 
        a=Math.round(parseFloat(a)*Math.pow(10,3))/Math.pow(10,3);
        b=Math.round(parseFloat(b)*Math.pow(10,3))/Math.pow(10,3);
        c=Math.round(parseFloat(c)*Math.pow(10,3))/Math.pow(10,3);
        d=Math.round(parseFloat(d)*Math.pow(10,3))/Math.pow(10,3);
    r = a + b + c + d; 
    if( b=='0') { b='0.000' };
    r=Math.round(parseFloat(r)*Math.pow(10,3))/Math.pow(10,3);
document.getElementById('<%=Label3.ClientID %>').innerHTML = r; 
document.getElementById('<%=TextBox6.ClientID %>').value=b;  
}  
</script> 
<script type="text/javascript" language="javascript">  
function sumar3() {  
var a, b,c,d, r;     
    a = document.getElementById('<%=TextBox3.ClientID %>').value;  
    b = document.getElementById('<%=TextBox6.ClientID %>').value;  
    c = document.getElementById('<%=TextBox9.ClientID %>').value;  
    d = document.getElementById('<%=TextBox12.ClientID %>').value;
        if( a=='') { a='0' };
        if( b=='') { b='0' };
        if( c=='') { c='0' };
        if( d=='') { d='0' }; 
        a=Math.round(parseFloat(a)*Math.pow(10,3))/Math.pow(10,3);
        b=Math.round(parseFloat(b)*Math.pow(10,3))/Math.pow(10,3);
        c=Math.round(parseFloat(c)*Math.pow(10,3))/Math.pow(10,3);
        d=Math.round(parseFloat(d)*Math.pow(10,3))/Math.pow(10,3);                                                                                   
    r = a + b + c + d;
    if( c=='0') { c='0.000' };
    r=Math.round(parseFloat(r)*Math.pow(10,3))/Math.pow(10,3); 
document.getElementById('<%=Label3.ClientID %>').innerHTML = r; 
document.getElementById('<%=TextBox9.ClientID %>').value=c;  
}  
</script> 
<script type="text/javascript" language="javascript">  
function sumar4() {  
var a, b,c,d, r;     
    a = document.getElementById('<%=TextBox3.ClientID %>').value;  
    b = document.getElementById('<%=TextBox6.ClientID %>').value;  
    c = document.getElementById('<%=TextBox9.ClientID %>').value;  
    d = document.getElementById('<%=TextBox12.ClientID %>').value;
        if( a=='') { a='0' };
        if( b=='') { b='0' };
        if( c=='') { c='0' };
        if( d=='') { d='0' }; 
        a=Math.round(parseFloat(a)*Math.pow(10,3))/Math.pow(10,3);
        b=Math.round(parseFloat(b)*Math.pow(10,3))/Math.pow(10,3);
        c=Math.round(parseFloat(c)*Math.pow(10,3))/Math.pow(10,3);
        d=Math.round(parseFloat(d)*Math.pow(10,3))/Math.pow(10,3);                                                                                    
    r = a + b + c + d;
    if( d=='0') { d='0.000' };
    r=Math.round(parseFloat(r)*Math.pow(10,3))/Math.pow(10,3);
document.getElementById('<%=Label3.ClientID %>').innerHTML = r; 
document.getElementById('<%=TextBox12.ClientID %>').value=d;
}  
</script> 

<%--<script type="text/javascript" language="javascript">  
function sumar4() {  
var a, b,c,d, r;     
    a = document.getElementById('<%=TextBox3.ClientID %>').value;  
    b = document.getElementById('<%=TextBox6.ClientID %>').value;  
    c = document.getElementById('<%=TextBox9.ClientID %>').value;  
    d = document.getElementById('<%=TextBox12.ClientID %>').value;
        if( a=='') a='0';
        if( b=='') b='0';
        if( c=='') c='0';
        if( d=='') d='0';  
        a=Math.round(parseFloat(a) * 100) / 100;
        b=Math.round(parseFloat(b) * 100) / 100;
        c=Math.round(parseFloat(c) * 100) / 100;
        d=Math.round(parseFloat(d) * 100) / 100; 
    r = a + b + c + d; 
    r=Math.round(parseFloat(r) * 100) / 100;
             if( r>1)          d = 1 - (a + b + c);   
                                 d=Math.round(parseFloat(d) * 100) / 100; 
                                 document.getElementById('<%=TextBox12.ClientID %>').value=d;                                                                                               
    r = a + b + c + d;
    r=Math.round(parseFloat(r) * 100) / 100;   
document.getElementById('<%=Label2.ClientID %>').innerHTML = r; 
if(r<=1 && r >0)   document.getElementById(btngraba).disabled=false;
if(r>1)   document.getElementById(btngraba).disabled=true;
}  
</script> --%>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.numeric.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".numeric").numeric();
            $(".numeric").focus(function () { $(this).css("background-color", "#ECF8E0"); });
            $(".numeric").blur(function () { $(this).css("background-color", "white"); });
        });
    </script>

    <script type="text/javascript">
        var txtcod= '<%=txtcod.ClientID%>';
        var txtnombre = '<%=txtnombre.ClientID%>';  
        var btngraba = '<%=btngraba.ClientID%>';          
        var TextBox1='<%=TextBox1.ClientID%>';
        var TextBox2='<%=TextBox2.ClientID%>';
        var TextBox3='<%=TextBox3.ClientID%>';
        var TextBox4='<%=TextBox4.ClientID%>';
        var TextBox5='<%=TextBox5.ClientID%>';
        var TextBox6='<%=TextBox6.ClientID%>';
        var TextBox7='<%=TextBox7.ClientID%>';
        var TextBox8='<%=TextBox8.ClientID%>';
        var TextBox9='<%=TextBox9.ClientID%>';
        var TextBox10='<%=TextBox10.ClientID%>';
        var TextBox11='<%=TextBox11.ClientID%>';
        var TextBox12='<%=TextBox12.ClientID%>';
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
    {
        width: 45px;
    }
        </style>
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style1">         
        <tr>
            <td colspan="2"  style="font-family: VERDANA; font-size: small; color: #000000; font-weight: bold;">INGRESE PRODUCTO A BUSCAR</td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="font-family: verdana; font-size: x-small">
                <asp:TextBox ID="txtcod" runat="server" BorderWidth="0px" Visible="False" 
                    Width="50px" Font-Names="VERDANA" Font-Size="X-Small" Font-Bold="True"></asp:TextBox>
                <asp:TextBox ID="txtnombre" runat="server" Width="210px" Font-Names="VERDANA" 
                    Font-Size="X-Small" Font-Bold="False"></asp:TextBox>&nbsp;
                <asp:LinkButton ID="lnkbusca" runat="server" ForeColor="#5D7B9D">Busca ...</asp:LinkButton>
                <asp:GridView ID="grvproductos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Left" Width="100%" Font-Size="X-Small" Font-Bold="False">
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
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" 
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        
        <tr>
            <td colspan="2">
                <table align="right" class="style1" border="1" cellpadding="0" cellspacing="0" style="font-family: VERDANA; font-size: x-small" >
                
                        <tr bgcolor="#5D7B9D" style="font-family: VERDANA; font-size: x-small; color: #FFFFFF; font-weight: bold">
                            <td style="font-family: VERDANA; font-size: x-small; color: #FFFFFF" class="style3">.....</td>
                            <td style="font-family: VERDANA; font-size: x-small; color: #FFFFFF" class="style3">.....</td>
                            <td width="100">CODIGO</td>
                            <td>NOMBRE</td>
                            <td width="100">PROPORCION</td>
                             <td width="100">UM</td>
                        </tr>
                        
                        <tr bgcolor="#F7F6F3">
                            <td align="center" class="style3"><img alt="" src="Imagenes/Lupa.gif" onclick="pop_ins11()" style="width: 16px; height: 16px"  id="busca1"/>&nbsp;</td>
                            <td align="center" class="style3"><img alt="" src="Imagenes/eraser.png" onclick="pop_borrar5()" style="width: 19px; height: 16px"  id="borra1"/>&nbsp;</td>
                            <td><asp:TextBox ID="TextBox1" runat="server" BackColor="#F7F6F3" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="70px"></asp:TextBox></td>
                            <td align="left"><asp:TextBox ID="TextBox2" runat="server" BackColor="#F7F6F3" BorderWidth="0px" Font-Names="Verdana" Font-Size="X-Small" Width="200px"></asp:TextBox></td>
                            <td align="center"><asp:TextBox ID="TextBox3" runat="server" BackColor="#F7F6F3" BorderWidth="1px" Width="50px" Font-Names="verdana" Font-Size="X-Small" CssClass="numeric" MaxLength="10" >0.000</asp:TextBox></td>
                            <td align="center">KG</td>
                        </tr>
                        
                        <tr>
                            <td align="center" class="style3"><img alt="" src="Imagenes/Lupa.gif" onclick="pop_ins22()" style="width: 16px; height: 16px"  id="busca2"/>&nbsp;</td>
                            <td align="center" class="style3"><img alt="" src="Imagenes/eraser.png" onclick="pop_borrar6()" style="width: 19px; height: 16px"  id="borra2"/>&nbsp;</td>
                            <td><asp:TextBox ID="TextBox4" runat="server" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="70px"></asp:TextBox></td>
                            <td align="left"><asp:TextBox ID="TextBox5" runat="server" BorderWidth="0px" Font-Names="Verdana" Font-Size="X-Small" Width="200px"></asp:TextBox></td>
                            <td align="center"><asp:TextBox ID="TextBox6" runat="server" BorderWidth="1px" Width="50px" Font-Names="verdana" Font-Size="X-Small" CssClass="numeric" MaxLength="10" >0.000</asp:TextBox></td>
                            <td align="center">KG</td>
                        </tr>
                        <tr bgcolor="#F7F6F3">
                            <td align="center" class="style3"><img alt="" src="Imagenes/Lupa.gif" onclick="pop_ins33()" style="width: 16px; height: 16px" id="busca3"/>&nbsp;</td>
                            <td align="center" class="style3"><img alt="" src="Imagenes/eraser.png" onclick="pop_borrar7()" style="width: 19px; height: 16px" id="borra3"/>&nbsp;</td>
                            <td><asp:TextBox ID="TextBox7" runat="server" BackColor="#F7F6F3" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="70px"></asp:TextBox></td>
                            <td align="left"><asp:TextBox ID="TextBox8" runat="server" BackColor="#F7F6F3" BorderColor="#F7F6F3" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="200px"></asp:TextBox></td>
                            <td align="center"><asp:TextBox ID="TextBox9" runat="server" BackColor="#F7F6F3" BorderWidth="1px" Width="50px" Font-Names="verdana" Font-Size="X-Small" CssClass="numeric" MaxLength="10" >0.000</asp:TextBox></td>
                            <td align="center">KG</td>
                        </tr>
                        
                        <tr>
                            <td align="center" class="style3"><img alt="" src="Imagenes/Lupa.gif" onclick="pop_ins44()" style="width: 16px; height: 16px" id="busca4"/>&nbsp;</td>
                            <td align="center" class="style3"><img alt="" src="Imagenes/eraser.png" onclick="pop_borrar8()" style="width: 19px; height: 16px" id="borra4"/>&nbsp;</td>
                            <td><asp:TextBox ID="TextBox10" runat="server" BorderWidth="0px" Width="70px" Font-Names="verdana" Font-Size="X-Small"></asp:TextBox></td>
                            <td align="left"><asp:TextBox ID="TextBox11" runat="server" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="200px"></asp:TextBox></td>
                            <td align="center"><asp:TextBox ID="TextBox12" runat="server" BorderWidth="1px" Width="50px" Font-Names="verdana" Font-Size="X-Small" CssClass="numeric" MaxLength="10" >0.000</asp:TextBox></td>
                            <td align="center">KG</td> 
                        </tr>
                        
                        <tr>
                            <td class="style3" >&nbsp;</td>
                            <td class="style3" >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td  align="right">Total:</td>
                            <td align="center"><asp:Label ID="Label3" runat="server" Text="0.000" Font-Bold="True"></asp:Label></td>
                            <td>&nbsp;</td> 
                        </tr>
                        </table></td>
        </tr>
        
        <tr>
            <td align="left" width="500"><asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="Small" ForeColor="Red" Width="501px"></asp:Label></td>
            <td align="center">
                <asp:Button ID="btngraba" runat="server" BackColor="#5D7B9D" 
                    Font-Bold="True" Font-Names="verdana" Font-Size="Small" Text="Grabar" 
                    style="height: 40px" ForeColor="White" Height="30px"/><br /></td>
        </tr>
    </table>
</asp:Content>

