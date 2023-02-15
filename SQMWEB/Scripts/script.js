var popUp; 

function OpenCalendar(idname, postBack)
{
	popUp = window.open('Utilitarios/Calendar.aspx?formname=' + document.forms[0].name + 
		'&id=' + idname + '&selected=' + document.forms[0].elements[idname].value + '&postBack=' + postBack, 
		'popupcal', 
		'width=120,height=220,left=250,top=250');
}

function SetDate(formName, id, newDate, postBack)
{
	eval('var theform = document.' + formName + ';');
	popUp.close();
	theform.elements[id].value = newDate;
	if (postBack)
		__doPostBack(id,'');
}		
    
function pop_libera()
    {
      var confirmWin = null;
      confirmWin = window.open('Ventanas/frmActVtalo.aspx','anycontent','width=400,height=280,status,scrollbars=yes');
    }  
    
function pop_actUsu()
    {
      var confirmWin = null;
      confirmWin = window.open('Ventanas/frmActUsu.aspx','anycontent','width=460,height=330,left=400,top=200,status,scrollbars=yes');
    }
    
 function Funcion_Numeros()
    {
    var tecla = window.event.keyCode;
    if (tecla < 48 || tecla > 57)
    {
    window.event.keyCode=0;
    }
    }
  
function Funcion_Letras()
    {
    var tecla = window.event.keyCode;
    if (tecla < 65 || tecla > 122 || tecla == 91 || tecla == 92 || tecla == 93 || tecla == 94 || tecla == 95 || tecla == 96)
    {
    window.event.keyCode=0;
    }
    }
    
    
    
    
    
