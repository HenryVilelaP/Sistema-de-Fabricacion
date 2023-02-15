<%@ Page Language="vb" %>
<%@ import Namespace="System.Configuration" %>
<%@ import Namespace="System.Web.UI.WebControls" %>
<%@ import Namespace="System" %>
<script runat="server">

    Private Sub Page_Load(sender As Object, e As System.EventArgs)
       If Not Page.IsPostBack Then
          Dim selected As String = Request.QueryString("selected")
          Dim id As String = Request.QueryString("id")
          Dim form As String = Request.QueryString("formname")
          Dim postBack As String = Request.QueryString("postBack")
    
          Cal.FirstDayofWeek = 1
    
          ' Select the Correct date for Calendar from query string
          ' If fails, pick the current date on Calendar
          Try
             Cal.SelectedDate = CDate(selected)
             Cal.VisibleDate = Cal.SelectedDate
          Catch
              Cal.SelectedDate = DateTime.Today
             Cal.VisibleDate = Cal.SelectedDate
          End Try
    
          ' Fills in correct values for the dropdown menus
          FillCalendarChoices()
          SelectCorrectValues()
    
          ' Add JScript to the OK button so that when the user clicks on it, the selected date
          ' is passed back to the calling page.
          OKButton.Attributes.Add("onClick", "window.opener.SetDate('" + form + "','" + id + "', document.Calendar.datechosen.value," + postBack + ");")
          CancelButton.Attributes.Add("onClick", "CloseWindow()")
       End If
    End Sub 'Page_Load
    
    
    '***************************************************************
    '
    ' FillCalendarChoices method is used to fill dropdowns with month and year values
    '
    '***************************************************************
    Private Sub FillCalendarChoices()
       Dim thisdate As New DateTime(DateTime.Today.Year, 1, 1)
    
       ' Fills in month values
       Dim x As Integer
       For x = 0 To 11
          ' Loops through 12 months of the year and fills in each month value
          Dim li As New ListItem(thisdate.ToString("MMMM"), thisdate.Month.ToString())
          MonthSelect.Items.Add(li)
          thisdate = thisdate.AddMonths(1)
       Next x
    
        ' Fills in year values and change y value to other years if necessary
        'antes: for y=1994 to thisdate.year
       Dim y As Integer
        For y = 1954 To 2030
            YearSelect.Items.Add(y.ToString())
        Next y
    End Sub 'FillCalendarChoices
    
    '***************************************************************************
    '
    ' The SelectCorrectValues method is used to select the correct values in dropdowns
    ' according to the selected date on Calendar
    '
    '***************************************************************************
    
    Private Sub SelectCorrectValues()
       lblDate.Text = Cal.SelectedDate.ToShortDateString()
       datechosen.Value = lblDate.Text
       MonthSelect.SelectedIndex = MonthSelect.Items.IndexOf(MonthSelect.Items.FindByValue(Cal.SelectedDate.Month.ToString()))
       YearSelect.SelectedIndex = YearSelect.Items.IndexOf(YearSelect.Items.FindByValue(Cal.SelectedDate.Year.ToString()))
    End Sub 'SelectCorrectValues
    
    '**************************************************************************
    '
    ' Cal_SelectionChanged event handler highlights the selected date on the Calendar and
    ' calls SelectCorrectValues() to synchronize to correct values on dropdowns.
    '
    '**************************************************************************
    
    Private Sub Cal_SelectionChanged(sender As Object, e As System.EventArgs)
       Cal.VisibleDate = Cal.SelectedDate
       SelectCorrectValues()
    End Sub 'Cal_SelectionChanged
    
    '**************************************************************************
    '
    ' MonthSelect_SelectedIndexChanged event handler selects the first day of the month when
    ' a month selection has being changed.
    '
    '**************************************************************************
    
    Private Sub MonthSelect_SelectedIndexChanged(sender As Object, e As System.EventArgs)
       Cal.VisibleDate = New DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value), Convert.ToInt32(MonthSelect.SelectedItem.Value), 1)
       Cal.SelectedDate = Cal.VisibleDate
       SelectCorrectValues()
    End Sub 'MonthSelect_SelectedIndexChanged
    
    '**************************************************************************
    '
    ' YearSelect_SelectedIndexChanged event handler selects a year value on the Calendar control
    ' when a year selection has being changed.
    '
    '**************************************************************************
    
    Private Sub YearSelect_SelectedIndexChanged(sender As Object, e As System.EventArgs)
       Cal.VisibleDate = New DateTime(Convert.ToInt32(YearSelect.SelectedItem.Value), Convert.ToInt32(MonthSelect.SelectedItem.Value), 1)
       Cal.SelectedDate = Cal.VisibleDate
       SelectCorrectValues()
    End Sub 'YearSelect_SelectedIndexChanged

  
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 

<html>
<head>
    <title>Calendario</title> 
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="styles.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
            function CloseWindow()
            {
                self.close();
            }
        </script>
    <style type="text/css">
        .btn
        {
            height: 20px;
        }
    </style>
</head>
<body bgcolor="White"  
    leftmargin="5" topmargin="5" alink="#ffffcc" text="#ffffff">
    <form id="Calendar" method="post" runat="server">
        <table cellspacing="0" cellpadding="1" border="0" 
            
            style="background-color: gainsboro; width: 239px; font-family: VERDANA; height: 207px;">
            <tbody>
                <tr bgcolor="white">
                    <td align="center" colspan="2" style="background-image: url(../Imagenes/Fondo1b.jpg)">
                        <asp:dropdownlist id="MonthSelect" runat="server" 
                            OnSelectedIndexChanged="MonthSelect_SelectedIndexChanged" AutoPostBack="True" 
                            Width="90px" Height="25px" CssClass="standard-text" Font-Size="XX-Small" 
                            Font-Names="verdana"></asp:dropdownlist>
                        &nbsp;
                        <asp:dropdownlist id="YearSelect" runat="server" 
                            OnSelectedIndexChanged="YearSelect_SelectedIndexChanged" AutoPostBack="True" 
                            Width="60px" Height="25px" CssClass="standard-text" Font-Size="XX-Small" 
                            Font-Names="verdana"></asp:dropdownlist>
                        <asp:calendar id="Cal" runat="server" CssClass="standard-text" 
                            OnSelectionChanged="Cal_SelectionChanged" FirstDayOfWeek="Monday" 
                            ForeColor="White" BorderColor="White" Font-Names="verdana" 
                            Font-Size="XX-Small" BorderStyle="Solid" ShowNextPrevMonth="False" 
                            ShowTitle="False" BorderWidth="5px" BackColor="#006699" Width="100%">
                            <todaydaystyle font-bold="True" forecolor="White" backcolor="Black"></todaydaystyle>
                            <daystyle borderwidth="3px" forecolor="Black" borderstyle="Solid" 
                                bordercolor="WhiteSmoke" backcolor="#EDEDED"></daystyle>
                            <dayheaderstyle forecolor="DimGray" BackColor="White" BorderColor="White" 
                                Font-Bold="False"></dayheaderstyle>
                            <selecteddaystyle font-bold="True" forecolor="#0099CC" backcolor="Red"></selecteddaystyle>
                            <SelectorStyle BorderWidth="4px" />
                            <weekenddaystyle forecolor="White" backcolor="#267FC4"></weekenddaystyle>
                            <othermonthdaystyle forecolor="#666666" backcolor="White"></othermonthdaystyle>
                            <TitleStyle BorderStyle="Solid" ForeColor="White" BackColor="Red" />
                        </asp:calendar>
                    </td>
                </tr>
                <tr>
                    <td align="middle" colspan="2" style="background-color: #FFFFFF">
                        &nbsp;<asp:Label id="lblDate" runat="server" Font-Bold="True" Font-Size="X-Small" 
                            ForeColor="#267FC4" Font-Names="VERDANA"></asp:Label>
                        <input id="datechosen" type="hidden" name="datechosen" runat="server" style="font-size: x-small" />
                    </td>
                </tr>
                <tr>
                    <td align="center" 
                        style="height: 5px; text-align: right; background-color: #FFFFFF;">
                        <asp:button id="OKButton" runat="server" Width="57px" CssClass="btn" 
                            Text="Aceptar" BackColor="#267FC4" Font-Names="verdana" Font-Size="XX-Small" 
                            ForeColor="White" ></asp:button>&nbsp;</td>
                    <td align="center" style="height: 5px; text-align: left; ; background-color: #FFFFFF;">
                        &nbsp;<a href="javascript:CloseWindow()" style="background-color: #FFFFFF"><asp:button 
                            id="CancelButton" runat="server" Width="57px" CssClass="btn" Text="Cancelar" 
                            BackColor="#267FC4" Font-Names="verdana" Font-Size="XX-Small" 
                            ForeColor="White"></asp:button>
                        </a></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>