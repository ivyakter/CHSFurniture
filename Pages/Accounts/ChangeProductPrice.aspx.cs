using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_ChangeProductPrice : System.Web.UI.Page
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
        Loadgridbyproduct();
    }

    protected void Loadgridbyproduct()
    {
        DataTable dt = mydal.GetProductdetailsbyid(ddlproduct.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }   
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Loadgridbyproduct(); 
    }
    
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string[] insert = new string[10];
            insert[0] = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblID")).Text;
            insert[1] = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtsellprice")).Text;

            bool Edit = mydal.EditProductsellprice(insert);

            GridView1.EditIndex = -1;
            Loadgridbyproduct(); 
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Loadgridbyproduct();
    }
}