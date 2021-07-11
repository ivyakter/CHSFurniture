using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Admin_Dashboard : BasePage
{

    string uid;
    Hashtable HolidayList;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (CommonMethod.SessionInfo.UserName == null)
        //    Response.Redirect("~/Default.aspx");

        //if (!IsPostBack)
        //{
        //   // LoadEmployee();
        //    //CalculateAL();
        //}
        //uid = Session["Uid"].ToString();

        //if (uid == "admin")
        //{
        //    pnlAdmin.Visible = true;
        //}
        //else
        //{
        //    pnlAdmin.Visible = false;
        //}        
    }

   
}