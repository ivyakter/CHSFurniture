using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class frm_changepassword : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null)
        {
            Response.Redirect("~/login.aspx", false);
            return;
        }
        else
        {
           lalogid.Text=Session["Uid"].ToString();
        }

    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (txtoldpassword.Text != Session["Pwd"].ToString())
        {
            laMeg.Text = "Current password is wrong";
            return;
        }
        if (txtnewpassword.Text != txtrepassword .Text)
        {
            laMeg.Text = "Password is not matched";
            return;
        }
        string[] fivalue = new string[2];
        fivalue[0] = lalogid.Text;
        fivalue[1] = txtnewpassword.Text;
       bool success= mydal.update_user_password(fivalue);
       if (success == true)
       {
           laMeg.Text = "Your password is changed";
           Session["Pwd"] = txtnewpassword.Text;
       }
    }
}
