Partial Class Principal
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Menu1.DataSource = Server.MapPath("menuprinc/menu.xml")
        Menu1.CssClass = "menustyle"
        Menu1.DefaultCssClass = "menuitem"
        Menu1.DefaultMouseOverCssClass = "mouseover"
        Menu1.HighlightTopMenu = True
        Menu1.Opacity = 80
        Menu1.BorderWidth = 2
        Menu1.zIndex = 100
        Menu1.ClickToOpen = True
        Menu1.DataBind()

    End Sub

    Protected Sub LoginStatus2_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
        Session.Abandon()
        FormsAuthentication.SignOut()
    End Sub


End Class

