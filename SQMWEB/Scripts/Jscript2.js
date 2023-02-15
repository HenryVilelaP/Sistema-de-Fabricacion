      
      function pop_lot()
     {
      var confirmWin = null;
      var a1 =  document.getElementById(Label8).innerHTML;
      var a2 =  document.getElementById(Label9).innerHTML;
      var a3 = document.getElementById(txt21).value;
      var a4 =  document.getElementById(Label27).innerHTML;
      var save = document.getElementById(btngraba).disabled;
    if (  a1 != '.'  && a2 != '.'  && a3 != '' && a4 != '.' && save == false )     
     confirmWin =window.open('Ventanas/frmblote.aspx','anycontent', 'width=481,height=300,status,scrollbars=yes');
    }; 

    function pop_lot1()
    {
      var confirmWin = null;
      var a1 =  document.getElementById(Label13).innerHTML;
      var a2 =  document.getElementById(Label14).innerHTML;
      var a3 = document.getElementById(txt22).value;
      var a4 =  document.getElementById(Label28).innerHTML;
      var save = document.getElementById(btngraba).disabled;           
      if ( a1 != '.'  && a2 != '.'  && a3 != '' && a4 != '.' && save == false )  
     confirmWin =window.open('Ventanas/frmblote1.aspx','anycontent','width=481,height=300,status,scrollbars=yes');
    };
    
    function pop_lot2()
    {
      var confirmWin = null;
      var a1 =  document.getElementById(Label17).innerHTML;
      var a2 =  document.getElementById(Label19).innerHTML;
      var a3 = document.getElementById(txt23).value;
      var a4 =  document.getElementById(Label29).innerHTML;
      var save = document.getElementById(btngraba).disabled;
      if ( a1 != '.'  && a2 != '.'  && a3 != '' && a4 != '.' && save == false )  
     confirmWin =window.open('Ventanas/frmblote2.aspx','anycontent','width=481,height=300,status,scrollbars=yes');
    };
    function pop_lot3()
    {
      var confirmWin = null;
      var a1 =  document.getElementById(Label18).innerHTML;
      var a2 =  document.getElementById(Label20).innerHTML;
      var a3 = document.getElementById(txt24).value;
      var a4 =  document.getElementById(Label30).innerHTML;
      var save = document.getElementById(btngraba).disabled;
      if ( a1 != '.'  && a2 != '.'  && a3 != '' && a4 != '.' && save == false )   
     confirmWin =window.open('Ventanas/frmblote3.aspx','anycontent','width=481,height=300,status,scrollbars=yes');
    };