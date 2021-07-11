using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Procurement_ViewPurchaseAccessories : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetExpenseVoucher();
    }
    private void GetExpenseVoucher()
    {
        DataTable dt = mydal.GetPurchaseVoucherList();
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        DataTable dt = mydal.GetPurchaseVoucherList(txtDateFrom.Text, txtDateTo.Text);
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        if (txtSearch.Text != "")
        {
            DataTable dt = mydal.GetPurchaseVoucherList(txtSearch.Text);
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }
        else
        {
            GetExpenseVoucher();
        }
    }
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview1.PageIndex = e.NewPageIndex;
        Gridview1.DataBind();
        GetExpenseVoucher();
    }

    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("DeleteRow"))
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = Gridview1.Rows[rowIndex];
            string VoucherNo = (row.FindControl("lblVoucher") as Label).Text;

            bool delete = mydal.DeletePurchaseAccessories(VoucherNo);
            GetExpenseVoucher();
        }
    }
}