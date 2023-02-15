     function pop_ins1()
    {
      var confirmWin = null;
      var a1 = document.getElementById(txtcodpro).value;
      var a2 = document.getElementById(txtproducto).value;
      var update = document.getElementById(btnactualiza).disabled;
      if (  trim(a1).length != '0'  && trim(a2).length  != '0'  &&  update == false )  
     confirmWin =window.open('Ventanas/frmins1.aspx','anycontent','width=450,height=300,status,scrollbars=yes');
    };
     function pop_ins2() 
    {
      var confirmWin = null;
      var a1 = document.getElementById(txtcodpro).value;
      var a2 = document.getElementById(txtproducto).value;
      var update = document.getElementById(btnactualiza).disabled;
      if (  trim(a1).length != '0'  && trim(a2).length  != '0'  &&  update == false )  
     confirmWin =window.open('Ventanas/frmins2.aspx','anycontent','width=450,height=300,status,scrollbars=yes');
    };
     function pop_ins3()
    {
      var confirmWin = null;
      var a1 = document.getElementById(txtcodpro).value;
      var a2 = document.getElementById(txtproducto).value;
      var update = document.getElementById(btnactualiza).disabled;
      if (  trim(a1).length != '0'  && trim(a2).length  != '0'  &&  update == false )  
     confirmWin =window.open('Ventanas/frmins3.aspx','anycontent','width=450,height=300,status,scrollbars=yes');
    };
     function pop_ins4()
    {
      var confirmWin = null;
      var a1 = document.getElementById(txtcodpro).value;
      var a2 = document.getElementById(txtproducto).value;
      var update = document.getElementById(btnactualiza).disabled;
      if (  trim(a1).length != '0'  && trim(a2).length  != '0'  &&  update == false )  
     confirmWin =window.open('Ventanas/frmins4.aspx','anycontent','width=450,height=300,status,scrollbars=yes');
    };
    function pop_ins11()
    {
      var confirmWin = null;
      var a1 = document.getElementById(txtcod).value;
      var a2 = document.getElementById(txtnombre).value;
      var save = document.getElementById(btngraba).disabled;
      if (  trim(a1).length != '0'  && trim(a2).length  != '0'  &&  save == false )  
     confirmWin =window.open('Ventanas/frmins1.aspx','anycontent','width=450,height=300,status,scrollbars=yes');
    };
     function pop_ins22()
    {
      var confirmWin = null;
      var a1 = document.getElementById(txtcod).value;
      var a2 = document.getElementById(txtnombre).value;
      var save = document.getElementById(btngraba).disabled;
      if (  trim(a1).length != '0'  && trim(a2).length  != '0'  &&  save == false ) 
     confirmWin =window.open('Ventanas/frmins2.aspx','anycontent','width=450,height=300,status,scrollbars=yes');
    };
     function pop_ins33()
    {
      var confirmWin = null;
      var a1 = document.getElementById(txtcod).value;
      var a2 = document.getElementById(txtnombre).value;
      var save = document.getElementById(btngraba).disabled;
      if (  trim(a1).length != '0'  && trim(a2).length  != '0'  &&  save == false ) 
     confirmWin =window.open('Ventanas/frmins3.aspx','anycontent','width=450,height=300,status,scrollbars=yes');
    };
     function pop_ins44()
    {
      var confirmWin = null;
      var a1 = document.getElementById(txtcod).value;
      var a2 = document.getElementById(txtnombre).value;
      var save = document.getElementById(btngraba).disabled;
      if (  trim(a1).length != '0'  && trim(a2).length  != '0'  &&  save == false ) 
     confirmWin =window.open('Ventanas/frmins4.aspx','anycontent','width=450,height=300,status,scrollbars=yes');
    };
    
    function trim(str, chars) {
	 return ltrim(rtrim(str, chars), chars);
    }
    
    function ltrim(str, chars) {
	chars = chars || "\\s";
	return str.replace(new RegExp("^[" + chars + "]+", "g"), "");
    }

    function rtrim(str, chars) {
	chars = chars || "\\s";
	return str.replace(new RegExp("[" + chars + "]+$", "g"), "");
    }


