using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (CommonMethod.SessionInfo == null)
            //{
            //    Response.Redirect("~/Default.aspx");
            //}
           
            lblYear.Text = DateTime.Now.Year.ToString();
            if (Page.Title != "")
            {
                litPage.Text = Page.Title;
            }
            Page.Header.DataBind();
        }
    }
    
}
