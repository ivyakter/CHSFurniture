using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_AdminHeader : System.Web.UI.UserControl
{
   //dalNotice objNotice = new dalNotice();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Uid"] == null)
            {
                Response.Redirect("../../login.aspx");
            }
            else
            {
                lblUser.Text = Session["Uid"].ToString();
                Label1.Text = Session["Uid"].ToString();

            }
        }
    }


    protected void LoginStatus1_Click(object sender, EventArgs e)
    {
        CommonMethod.SessionInfo = null;
        Response.Redirect("~/Default.aspx");
    }
    protected void changepass_Click(object sender, EventArgs e)
    {
        CommonMethod.SessionInfo = null;
        Response.Redirect("~/Pages/UI/frm_changepassword.aspx");
    }
}