using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Procurement_PurchaseAccessoriesReport : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GetPurchaseInfo();
            ShowVendorName();
            ShowAccessoriesName();
        
        }
    }
    protected void txtDate2_TextChanged(object sender, EventArgs e)
    {
        var date1 = DateTime.Parse(txtDate1.Text);
        var date2 = DateTime.Parse(txtDate2.Text);
        DataTable dt = mydal.Getdatefilterpurchase(date1, date2);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void ShowAccessoriesName()
    {
        DataTable dt = mydal.GetAccessoriesName();
        ddlitem.DataSource = dt;
        ddlitem.DataTextField = "AccessoriesName";
        ddlsupliername.DataValueField = "ID";
        ddlitem.DataBind();
        ddlitem.Items.Insert(0, "--Select--");
    }
    public void ShowVendorName()
    {
        DataTable dt = mydal.GetVendorName();
        ddlsupliername.DataSource = dt;
        ddlsupliername.DataTextField = "VendorName";
        ddlsupliername.DataValueField = "ID";
        ddlsupliername.DataBind();
        ddlsupliername.Items.Insert(0, "--Select--");
    }

    protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = mydal.GetdetailsbyAccessories(ddlitem.SelectedItem);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void ddlsupliername_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtDate1.Text == "" || txtDate2.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Please Select Date');", true);
        }
        else
        {
            var date1 = DateTime.Parse(txtDate1.Text);
            var date2 = DateTime.Parse(txtDate2.Text);

            DataTable dt = mydal.GetdetailsbyVendor(ddlsupliername.SelectedItem, date1, date2);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    Decimal total1 = 0;
    Decimal total2 = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            var totalamount = e.Row.FindControl("lbltotal") as Label;
            var totalquantity = e.Row.FindControl("lblqty") as Label;
            if (totalquantity != null & totalamount != null)
            {
                total1 += Decimal.Parse(totalamount.Text);
                total2 += Decimal.Parse(totalquantity.Text);
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblquantity = (Label)e.Row.FindControl("lblAllquantity");
            Label lblamount = (Label)e.Row.FindControl("lblAlltotal");

            lblamount.Text = total1.ToString();
            lblquantity.Text = total2.ToString();

        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        ShowAccessoriesName();
    }

    private void GetPurchaseInfo()
    {
        DataTable dt = mydal.GetPurchaseInfo();

        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
}