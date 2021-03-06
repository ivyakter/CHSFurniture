using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Sales_SalesProductReport : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetPurchaseInfo();
            ////ShowVendorName();       
        }
    }


    protected void txtDate2_TextChanged(object sender, EventArgs e)
    {
        var date1 = DateTime.Parse(txtDate1.Text);
        var date2 = DateTime.Parse(txtDate2.Text);
        DataTable dt = mydal.GetdatefilterSalesProduct(date1, date2);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    //public void ShowVendorName()
    //{
    //    DataTable dt = mydal.GetVendorName();
    //    ddlsupliername.DataSource = dt;
    //    ddlsupliername.DataTextField = "VendorName";
    //    ddlsupliername.DataValueField = "ID";
    //    ddlsupliername.DataBind();
    //    ddlsupliername.Items.Insert(0, "--Select--");
    //}



    //protected void ddlsupliername_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dt = mydal.GetdetailsbyVendor(ddlsupliername.SelectedItem);
    //    GridView1.DataSource = dt;
    //    GridView1.DataBind();
    //}

    double total1 = 0;
    double total2 = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var totalquantity = e.Row.FindControl("lblqty") as Label;
            if (totalquantity != null)
            {
                total2 += double.Parse(totalquantity.Text);
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblquantity = (Label)e.Row.FindControl("lblAllquantity");
            lblquantity.Text = total2.ToString();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    private void GetPurchaseInfo()
    {
        DataTable dt = mydal.GetSalesProduct();
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}