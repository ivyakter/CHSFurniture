using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_Recieve_Payment_Repot : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        DateClanaderExtender1.SelectedDate = DateTime.Today;
        DateClanaderExtender2.SelectedDate = DateTime.Today;
        if (!IsPostBack)
        {
            GetpaymentRecieveInfo();
        }
    }
  
    private void GetpaymentRecieveInfo()
    {
        DataTable dt = mydal.GetDebitCreditInfo();

        GridView1.DataSource = dt;
        GridView1.DataBind();

    }   

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        GetpaymentRecieveInfo();
    }
    protected void btndatefilter_Click(object sender, EventArgs e)
    {
        var date1 = DateTime.Parse(txtDate1.Text);
        var date2 = DateTime.Parse(txtDate2.Text);
        DataTable dt = mydal.Getdatefilterforrec_pay(date1, date2);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void ddldborcr_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldborcr.SelectedValue.ToString() == "1")
        {
            DataTable dt = mydal.GetDebit(ddldborcr.SelectedItem.ToString());
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        else if (ddldborcr.SelectedValue.ToString() == "2")
        {
            DataTable dt = mydal.GetCredit(ddldborcr.SelectedItem.ToString());
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        else 
        {
            GetpaymentRecieveInfo();
        
        }
    }
}