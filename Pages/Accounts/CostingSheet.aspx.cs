using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_CostingSheet : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //GetRecieveFromClientInfo();
            Loadproductname();
        }
    }

    protected void Loadproductname()
    {
        DataTable dt = mydal.bindProduct();

        if (dt.Rows.Count > 0)
        {
            ddlproduct.DataSource = dt;
            ddlproduct.DataValueField = "ProId";
            ddlproduct.DataTextField = "PName";
            ddlproduct.DataBind();
            ddlproduct.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }

    protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
    {    
        DataTable dt = mydal.GetProductcostingbyid(ddlproduct.SelectedValue);

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }     
    }

    double total2 = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblAccessoriesTotal = e.Row.FindControl("lblAccessoriesTotal") as Label;

            if (lblAccessoriesTotal != null)
            {
                total2 += double.Parse(lblAccessoriesTotal.Text);
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblAccessoriesTotalToatal = (Label)e.Row.FindControl("lblAccessoriesTotalToatal");
            lblAccessoriesTotalToatal.Text = total2.ToString();       
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

}