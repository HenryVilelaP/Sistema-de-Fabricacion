<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="frmActFor.aspx.vb" Inherits="frmActFor" title=":: Intranet - Sociedad Quimica Mercantil S.A ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script language="javascript" src="Scripts\script_popup.js" type="text/javascript"> </script>
<script language="javascript" src="Scripts\JScriptinsumo.js" type="text/javascript"> </script>
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
    a = document.getElementById('<%=Txt21.ClientID %>').value;  
    b = document.getElementById('<%=Txt22.ClientID %>').value;  
    c = document.getElementById('<%=Txt23.ClientID %>').value;  
    d = document.getElementById('<%=Txt24.ClientID %>').value;
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
document.getElementById('<%=Txt21.ClientID %>').value=a;  
}  
</script> 

<script type="text/javascript" language="javascript">  
function sumar2() {  
var a, b,c,d, r;     
    a = document.getElementById('<%=Txt21.ClientID %>').value;  
    b = document.getElementById('<%=Txt22.ClientID %>').value;  
    c = document.getElementById('<%=Txt23.ClientID %>').value;  
    d = document.getElementById('<%=Txt24.ClientID %>').value;
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
document.getElementById('<%=Txt22.ClientID %>').value=b;  
}  
</script> 

<script type="text/javascript" language="javascript">  
function sumar3() {  
var a, b,c,d, r;     
    a = document.getElementById('<%=Txt21.ClientID %>').value;  
    b = document.getElementById('<%=Txt22.ClientID %>').value;  
    c = document.getElementById('<%=Txt23.ClientID %>').value;  
    d = document.getElementById('<%=Txt24.ClientID %>').value;
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
document.getElementById('<%=Txt23.ClientID %>').value=c;  
}  
</script> 

<script type="text/javascript" language="javascript">  
function sumar4() {  
var a, b,c,d, r;     
    a = document.getElementById('<%=Txt21.ClientID %>').value;  
    b = document.getElementById('<%=Txt22.ClientID %>').value;  
    c = document.getElementById('<%=Txt23.ClientID %>').value;  
    d = document.getElementById('<%=Txt24.ClientID %>').value;
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
document.getElementById('<%=Txt24.ClientID %>').value=d;
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
    
        <script type="text/javascript">
        var txtcodpro = '<%=txtcodpro.ClientID%>';
        var txtproducto = '<%=txtproducto.ClientID%>';  
        var btnactualiza = '<%=btnactualiza.ClientID%>';   
        var TextBox1='<%=TextBox1.ClientID%>';
        var TextBox2='<%=TextBox2.ClientID%>';
        var TextBox4='<%=TextBox4.ClientID%>';
        var TextBox5='<%=TextBox5.ClientID%>';
        var TextBox7='<%=TextBox7.ClientID%>';
        var TextBox8='<%=TextBox8.ClientID%>';
        var TextBox10='<%=TextBox10.ClientID%>';
        var TextBox11='<%=TextBox11.ClientID%>';
        var txt21='<%=txt21.ClientID%>';
        var txt22='<%=txt22.ClientID%>';
        var txt23='<%=txt23.ClientID%>';
        var txt24='<%=txt24.ClientID%>';
                 
    </script>


    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style6
        {
            width: 155px;
        }
        .style11
        {
            width: 281px;
        }
        .style4
        {
            height: 104px;
        }
        .style3
        {
            height: 82px;
        }
        .style12
        {
            width: 115px;
        }
        .style13
        {
            width: 155px;
            height: 16px;
        }
        .style16
        {
            width: 30px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style1" style="font-family: verdana; font-size: x-small; height: 250px;" width="20">
        <tr>
            <td align="left" class="style13">Formula a Modificar:&nbsp;&nbsp;&nbsp;</td>
            <td colspan="3" align ="left"> &nbsp;
                    <asp:TextBox ID="txtcodpro" runat="server" Width="70px" Font-Names="verdana" Font-Size="X-Small"></asp:TextBox>
                    <asp:TextBox ID="txtproducto" runat="server" Width="423px" Font-Names="verdana" Font-Size="X-Small"></asp:TextBox>
                    <img alt="" src="Imagenes/Lupa.gif" onclick="pop_producto1()" style="width: 18px; height: 18px" id="busca0" />&nbsp;            </td>
        </tr>
        <tr>
            <td align="left" class="style6"><asp:LinkButton ID="LinkButton2" runat="server">Visualizar Formula</asp:LinkButton></td>
            <td align="left">&nbsp;</td>
            <td align="right" class="style11"></td>
            <td align="left">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="4" class="style4">
                <table align="center" class="style1" border="2" cellpadding="1" >
                    <tr align="center" bgcolor="#5D7B9D" style="font-family: VERDANA; font-size: x-small; color: #FFFFFF; font-weight: bold">
                        <td class="style16">&nbsp;</td>
                        <td class="style16">&nbsp;</td>
                        <td class="style12"><asp:Label ID="lblcodigo" runat="server" Text="CODIGO" Font-Bold="True"></asp:Label></td>
                        <td><asp:Label ID="lblproducto" runat="server" Text="PRODUCTO" Font-Bold="True"></asp:Label></td>
                        <td><asp:Label ID="Label25" runat="server" Font-Bold="True" Text="PROPORCION"></asp:Label></td>                
                    </tr>
                    
                    <tr align="left" bgcolor="#F7F6F3">
                        <td align="center" class="style16"><img alt="" src="Imagenes/Lupa.gif" onclick="pop_ins1()" style="width: 16px; height: 16px" id="busca1"/> </td>
                        <td align="center" class="style16"><img alt="" src="Imagenes/eraser.png" onclick="pop_borrar1()" style="width: 19px; height: 16px" id="borra1"/> </td>
                        <td class="style12" align="center"><asp:TextBox ID="TextBox1" runat="server" Width="90px" BackColor="#F7F6F3" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox2" runat="server" BackColor="#F7F6F3" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="400px"></asp:TextBox></td>
                        <td align="center"><asp:TextBox ID="txt21" runat="server" Font-Names="VERDANA" Font-Size="XX-Small" Width="60px" CssClass="numeric" MaxLength="10" >0.000</asp:TextBox></td>                                        
                    </tr>
                    
                    <tr bgcolor="White">
                        <td align="center" class="style16"><img alt="" src="Imagenes/Lupa.gif" onclick="pop_ins2()" style="width: 16px; height: 16px" id="busca2" /></td>
                        <td align="center" class="style16"><img alt="" src="Imagenes/eraser.png" onclick="pop_borrar2()" style="width: 19px; height: 16px" id="borra2" /></td>
                        <td class="style12" align="center"><asp:TextBox ID="TextBox4" runat="server" Width="90px" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small"></asp:TextBox>
                        </td>
                        <td><asp:TextBox ID="TextBox5" runat="server" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="400px"></asp:TextBox></td>
                        <td align="center"><asp:TextBox ID="txt22" runat="server" Font-Names="VERDANA" Font-Size="XX-Small" Width="60px" CssClass="numeric" MaxLength="10" >0.000</asp:TextBox></td>              
                        
                    </tr>
                    <tr bgcolor="#F7F6F3">
                        <td align="center" class="style16"><img alt="" src="Imagenes/Lupa.gif" onclick="pop_ins3()" style="width: 16px; height: 16px" id="busca3"/></td>
                        <td align="center" class="style16"><img alt="" src="Imagenes/eraser.png" onclick="pop_borrar3()" style="width: 19px; height: 16px" id="borra3"/></td>
                        <td class="style12" align="center"><asp:TextBox ID="TextBox7" runat="server" BackColor="#F7F6F3" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="90px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox8" runat="server" BackColor="#F7F6F3" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="400px"></asp:TextBox></td>
                        <td align="center"><asp:TextBox ID="txt23" runat="server" Font-Names="VERDANA" Font-Size="XX-Small" Width="60px" CssClass="numeric" MaxLength="10" >0.000</asp:TextBox></td>
                    </tr>
                    
                    <tr>
                        <td align="center" class="style16"><img alt="" src="Imagenes/Lupa.gif" onclick="pop_ins4()" style="width: 16px; height: 16px" id="busca4"/></td>
                        <td align="center" class="style16"><img alt="" src="Imagenes/eraser.png" onclick="pop_borrar4()" style="width: 19px; height: 16px" id="borra4"/></td>
                        <td class="style12" align="center"><asp:TextBox ID="TextBox10" runat="server" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="90px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox11" runat="server" BorderWidth="0px" Font-Names="verdana" Font-Size="X-Small" Width="400px"></asp:TextBox></td>
                        <td align="center"><asp:TextBox ID="txt24" runat="server" Font-Names="VERDANA" Font-Size="XX-Small" Width="60px" CssClass="numeric" MaxLength="10" >0.000</asp:TextBox></td>       
                    </tr>
                     <tr>
                            <td class="style16" >&nbsp;</td>
                            <td class="style16" >&nbsp;</td>
                            <td >&nbsp;</td>
                            <td  align="right">Total:</td>
                            <td align="center"><asp:Label ID="Label3" runat="server" Text="0.000" Font-Bold="True"></asp:Label></td>
                     </tr>                        
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" class="style3"><asp:Label ID="lblmensaje" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="Small" ForeColor="#FF3300"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td align="left" class="style3"><br /><asp:Button ID="btnactualiza" runat="server" BackColor="#5D7B9D" Font-Bold="True"  Font-Names="verdana" Text="Modificar" style="height: 40px" ForeColor="White" Height="25px" ToolTip="Grabar"/></td>
        </tr>
    </table>
</asp:Content>

