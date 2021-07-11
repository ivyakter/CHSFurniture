using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Procurement_ViewPurchaseProduct : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetExpenseVoucher();
    }
    private void GetExpenseVoucher()
    {
        DataTable dt = mydal.GetProductPurchaseList();
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        DataTable dt = mydal.GetReceiveVoucherListByDate(txtDateFrom.Text, txtDateTo.Text);
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["datefrom"] = txtDateFrom.Text;
        Session["dateto"] = txtDateTo.Text;

        Response.Redirect("~/Pages/Report/PaymentVoucherReport.aspx");
    }

    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview1.PageIndex = e.NewPageIndex;
        Gridview1.DataBind();
        GetExpenseVoucher();
    }
}