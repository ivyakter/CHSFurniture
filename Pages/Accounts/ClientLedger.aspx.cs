using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_ClientLedger : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //GetRecieveFromClientInfo();
          
            ShowClientName();
        }
    }    
    public void ShowClientName()
    {
        DataTable dt = mydal.GetAccountsReciveable();
        ddlclient.DataSource = dt;
        ddlclient.DataTextField = "AccName";
        ddlclient.DataValueField = "AccCode";
        ddlclient.DataBind();
        ddlclient.Items.Insert(0, "--Select--");
    }

    protected void ddlclient_SelectedIndexChanged(object sender, EventArgs e)
    {
        var date1 = DateTime.Parse(txtDate1.Text);
        var date2 = DateTime.Parse(txtDate2.Text);

        DataTable dt = mydal.GetRecieveAmountbydateandclient(ddlclient.SelectedValue, date1,date2);

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        DataTable totalsold = mydal.GetSalesbydateandclient(ddlclient.SelectedValue, date1, date2);

        if (totalsold.Rows.Count > 0)
        {
            lbltotalsold.Text = totalsold.Rows[0]["Totalsum"].ToString();

            GridView2.DataSource = totalsold;
            GridView2.DataBind();
        }

        lbltotaldue.Text = (double.Parse(lbltotalsold.Text == "" ? "0" : lbltotalsold.Text) - double.Parse(lbltotalpayment.Text == "" ? "0" : lbltotalpayment.Text)).ToString();
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

    //private void GetRecieveFromClientInfo()
    //{
    //    DataTable dt = mydal.GetReciveClientInfo();

    //    GridView1.DataSource = dt;
    //    GridView1.DataBind();

    //}

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
            lbltotalsold.Text = total1.ToString();
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
        ddlclient_SelectedIndexChanged(null, null);
    }
}