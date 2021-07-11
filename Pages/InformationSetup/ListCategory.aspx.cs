using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_ListCategory : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getCategoryList();
        }
    }
    protected void getCategoryList()
    {
        DataTable dt = mydal.getCategoryList();
        gv.DataSource = dt;
        gv.DataBind();
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            Label lblid = (Label)row.Cells[2].FindControl("lblid");

            bool delete = mydal.CategoryDeletebyid(lblid.Text);
            getCategoryList();
        }
        catch (Exception ex)
        { }

    }
}