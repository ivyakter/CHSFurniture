using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_CustomerOrder : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getOrder();
        }
    }

    protected void getOrder()
    {
        DataTable dt = mydal.getOrders();
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void btnSeenComplete_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            Label lblid = (Label)row.Cells[10].FindControl("lblid");

            bool update = mydal.updateStatus(lblid.Text);
            getOrder();
        }
        catch (Exception ex)
        {
        }

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        gv.DataBind();
        getOrder();
    }
}