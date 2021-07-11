using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Reports_DayBookReport : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void getDayBook()
    {
        DateTime date1 = DateTime.ParseExact(txtDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

        gridViewDayBook.DataSource = null;
        gridViewDayBook.DataBind();

        DataTable dt = mydal.GetDayBook(date1, date2);
        if (dt.Rows.Count > 0)
        {
            gridViewDayBook.DataSource = dt;
            gridViewDayBook.DataBind();

            foreach (GridViewRow row in gridViewDayBook.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label lblLinks = row.FindControl("lblExternalLinks") as Label;
                    Label lblVoucherType = row.FindControl("lblVoucherType") as Label;
                    Label lblVoucherNo = row.FindControl("lblVoucherNo") as Label;
                    HyperLink hplinkNavigateInsert = row.FindControl("hplinkNavigateInsert") as HyperLink;
                    HyperLink hplinkNavigateEdit = row.FindControl("hplinkNavigateEdit") as HyperLink;
                   
                    if (lblVoucherType.Text == "Receive")
                    {
                        lblLinks.Text = "~/Pages/Accounts/ReciveVoucher.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "~/Pages/Accounts/ReciveVoucherEdit.aspx" + "?Id=" + lblVoucherNo.Text;
                    }
                    else if (lblVoucherType.Text == "Payment")
                    {
                        lblLinks.Text = "~/Pages/Accounts/PaymentVoucher.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "~/Pages/Accounts/PaymentVoucherEdit.aspx" + "?Id=" + lblVoucherNo.Text;
                    }
                    else if (lblVoucherType.Text == "Purchase")
                    {
                        lblLinks.Text = "~/Pages/Procurement/PurchaseAccessories.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "~/Pages/Procurement/PurchaseAccessoriesEdit.aspx" + "?id=" + lblVoucherNo.Text;
                    }
                    else if (lblVoucherType.Text == "Sales")
                    {
                        lblLinks.Text = "~/Pages/Sales/SalesInvoiceAccessories.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "~/Pages/Sales/SaleVoucherEdit.aspx" + "?id=" + lblVoucherNo.Text;
                    }
                }
            }
        }
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        getDayBook();
    }

    protected void gridViewDayBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridViewDayBook.PageIndex = e.NewPageIndex;
        gridViewDayBook.DataBind();
        getDayBook();
    }
    private int totalDebit = 0;
    private int totalCredit = 0;

    protected void gridViewDayBook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
            totalDebit += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Debit"));
            totalCredit += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Credit"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[5].Text =totalDebit.ToString();
            e.Row.Cells[5].Font.Bold = true;
            e.Row.Cells[6].Text = totalCredit.ToString();
            e.Row.Cells[6].Font.Bold = true;
        }
    }

    protected void gridViewDayBook_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("DeleteRow"))
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gridViewDayBook.Rows[rowIndex];
            string VoucherNo = (row.FindControl("lblVoucher") as Label).Text;
            string VoucherType = (row.FindControl("lblVoucherType") as Label).Text;

            if (Session["Uid"].ToString() != "admin")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('You are not valid user to delete this record!!');", true);
            }
            else
            {
                mydal.DeleteReceivePaymentandSalesPurchsase(VoucherNo, VoucherType);

                gridViewDayBook.DataBind();
                getDayBook();
            }
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        DateTime date1 = DateTime.ParseExact(txtDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

        Session["date1"] = date1;
        Session["date2"] = date2;
        Response.Redirect("../Reports/rptDayBook.aspx");
    }
}