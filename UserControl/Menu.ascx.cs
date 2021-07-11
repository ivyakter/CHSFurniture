using System;

public partial class UserControls_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    if (!IsPostBack)
        //    {
        //        SetMenu("Annonymous");
        //        if (Page.User.IsInRole("SystemAdmin") || Page.User.IsInRole("Admin"))
        //        {
        //            AdminMenuBar.Visible = false;
        //        }
        //        else
        //        {
        //            AnmsMenuBar.Visible = false;
        //        }
        //    }
        //}
        //catch (Exception)
        //{
        //}
    }

    //protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    //{
    //    Session["RedirectFrom"] = null;

    //    Response.Redirect("Home", true);
    //}

    //private void SetMenu(string strRole)
    //{
    //}
}