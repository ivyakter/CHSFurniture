using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_SalaryReport : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //GetPurchaseInfo();
            ////ShowVendorName();
          
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
    double total3 = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblBasicSalary = e.Row.FindControl("lblBasicSalary") as Label;
            var lblPayment = e.Row.FindControl("lblPayment") as Label;
            var lblDue = e.Row.FindControl("lblDue") as Label;

            if (lblBasicSalary != null && lblPayment != null && lblDue!=null)
            {
                total1 += double.Parse(lblBasicSalary.Text);
                total2 += double.Parse(lblPayment.Text);
                total3 += double.Parse(lblDue.Text);
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotalbasic = (Label)e.Row.FindControl("lbltotalbasic");
            Label lbltotalpayment = (Label)e.Row.FindControl("lbltotalpayment");
            Label lbltotaldue = (Label)e.Row.FindControl("lbltotaldue");

            lbltotalbasic.Text = total1.ToString();
            lbltotalpayment.Text = total2.ToString();
            lbltotaldue.Text = total3.ToString();
        }
    }



    protected void btncalculate_Click(object sender, EventArgs e)
    {
        var date1 = DateTime.Parse(txtDate1.Text);
        var date2 = DateTime.Parse(txtDate2.Text);

        DataTable dt = mydal.GetdatefilterSalary(date1, date2);

        //lbltotalPayment.Text = dt.Rows[0]["Payment"].ToString();
        //lbltotaldue.Text = dt.Rows[0]["Due"].ToString();

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
  
}