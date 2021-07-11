using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_VendorLedger : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //GetRecieveFromClientInfo();

            ShowVendor();

        }
    }
    public void ShowVendor()
    {
        DataTable dt = mydal.GetVendor();
        ddlVendor.DataSource = dt;
        ddlVendor.DataTextField = "VendorName";
        ddlVendor.DataValueField = "AccCode";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "--Select--");
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        GridView2.DataSource = null;
        GridView2.DataBind();

        var date1 = DateTime.Parse(txtDate1.Text);
        var date2 = DateTime.Parse(txtDate2.Text);

        DataTable dt = mydal.GetRecieveAmountbydateandclient(ddlVendor.SelectedValue, date1, date2);

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        DataTable totalsold = mydal.GetpurchasedbydateandVendor(ddlVendor.SelectedValue, date1, date2);

        if (totalsold.Rows.Count > 0)
        {
            lbltotalpurchased.Text = totalsold.Rows[0]["Totalsum"].ToString();

            GridView2.DataSource = totalsold;
            GridView2.DataBind();
        }

        lbltotaldue.Text = (double.Parse(lbltotalpurchased.Text == "" ? "0" : lbltotalpurchased.Text) - double.Parse(lbltotalpayment.Text == "" ? "0" : lbltotalpayment.Text)).ToString();


    }   
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
            lbltotalpayment.Text = total2.ToString();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
        ddlVendor_SelectedIndexChanged(null, null);
    }

    double total1 = 0;
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {       
     
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblTotal = e.Row.FindControl("lblTotal") as Label;

            if (lblTotal != null)
            {

                total1 += double.Parse(lblTotal.Text);

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblquantity = (Label)e.Row.FindControl("lblallTotal");

            lblquantity.Text = total1.ToString();
            lbltotalpurchased.Text = total1.ToString();
        }
    }
   
}