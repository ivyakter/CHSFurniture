using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_ListVendor : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getVendorList();
        }
    }
    protected void getVendorList()
    {
        DataTable dt = mydal.getVendorList();
        gv.DataSource = dt;
        gv.DataBind();
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        getVendorList();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            Label lblid = (Label)row.Cells[2].FindControl("lblid");

            bool delete = mydal.VendorDeletebyid(lblid.Text);
            getVendorList();
        }
        catch (Exception ex)
        { }

    }
}