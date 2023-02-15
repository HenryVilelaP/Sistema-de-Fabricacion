var popUp; 

    
 function pop_lab_reserva()
    {
      var confirmWin = null;
      confirmWin = window.open('Ventanas/frmagreserva.aspx','anycontent', 'width=400,height=400,status,scrollbars=yes');
    } ;
          
 function pop_producto()
    {
      var confirmWin = null;      
      var save = document.getElementById(btngraba).disabled;
      if ( save == false )   
      confirmWin = window.open('Ventanas/frmbuscapro.aspx','anycontent','width=400,height=400,status,scrollbars=yes');   
    };
    
  function pop_producto1()
    {
      var confirmWin = null;      
      var update = document.getElementById(btnactualiza).disabled;  
      if ( update == false )    
      confirmWin = window.open('Ventanas/frmbuscapro.aspx','anycontent','width=400,height=400,status,scrollbars=yes');   
    };
  
 function pop_seguridad()
    {
      var confirmWin = null;
      confirmWin = window.open('Ventanas/frmseguridad.aspx','anycontent','menubar=no,width=400,height=200,left=400,top=200,status=YES,scrollbars=no');
    }  ;
    


    
    
        
  