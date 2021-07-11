using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_NewFolder1_AccountsLedger : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            getLedgerNames();
            if (Request.QueryString["Id"] == "1")
            {
                ddlLedger.SelectedItem.Text = Session["AccName"].ToString();
                ddlLedger.SelectedValue = Session["AccCode"].ToString();

                txtFromDate.Text = Session["d1"].ToString();
                txtToDate.Text = Session["d2"].ToString();

                ddlLedger_SelectedIndexChanged(null, null);
            }
        }
    }

    public void getLedgerNames()
    {
        DataTable Dt = mydal.GetChartOfAcc();
        ddlLedger.DataSource = Dt;
        ddlLedger.DataTextField = "AccName";
        ddlLedger.DataValueField = "AccCode";
        ddlLedger.DataBind();
        ddlLedger.Items.Insert(0, "--Select a Ledger--");
    }

    protected void OpeningBalance()
    {
        DateTime date1 = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

        if (ddlLedger.SelectedItem.Text == "Cash" || ddlLedger.SelectedItem.Text == "Bank")
        {
            panelBalance.Visible = true;
            DataTable balance = mydal.getOpeningBalanceForCash(ddlLedger.SelectedValue, date1);
            lblOpeningBalance.Text = balance.Rows[0][0].ToString();
        }
        else
        {
            panelBalance.Visible = true;
            DataTable balance = mydal.getOpeningBalance(ddlLedger.SelectedValue, date1);
            lblOpeningBalance.Text = balance.Rows[0][0].ToString();
        }
    }

    protected void ClosingBalance()
    {
        DateTime date2 = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        //if (ddlLedger.SelectedItem.Text == "Cash" || ddlLedger.SelectedItem.Text == "Bank")
        //{

        //}
        //else
        //{
        //    panelBalance.Visible = true;
        //    DataTable balance = mydal.getClosingBalance(ddlLedger.SelectedValue, txtToDate.Text);
        //    lblClosingBalance.Text = balance.Rows[0][0].ToString();
        //}
        panelBalance.Visible = true;
        DataTable balance = mydal.getClosingBalanceForCash(ddlLedger.SelectedValue, date2);
        lblClosingBalance.Text = balance.Rows[0][0].ToString();
    }

    protected void getLedger()
    {
        gridViewLedger.DataSource = null;
        gridViewLedger.DataBind();

        DateTime date1 = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

        DataTable dt = mydal.GetAccountsLedger(ddlLedger.SelectedValue, date1, date2);
        Session["dtledger"] = dt;
        if (dt.Rows.Count > 0)
        {
            gridViewLedger.DataSource = dt;
            gridViewLedger.DataBind();
            if (dt.Rows[0]["VoucherType"].ToString() == "Purchase")
            {
                panelBalance.Visible = true;
                DataTable balance = mydal.getClosingBalance(ddlLedger.SelectedValue, date2);
                lblClosingBalance.Text = balance.Rows[0][0].ToString();
            }
            else
            {
                //panelBalance.Visible = true;
                //DataTable balance = mydal.getClosingBalanceForCash(ddlLedger.SelectedValue, date2);
                //lblClosingBalance.Text = balance.Rows[0][0].ToString();
            }

            foreach (GridViewRow row in gridViewLedger.Rows)
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
                        lblLinks.Text = "~/Pages/Accounts/PaymentReceiveNew.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "~/Pages/Accounts/ReceiveVoucherEdit.aspx" + "?id=" + lblVoucherNo.Text;
                    }
                    else if (lblVoucherType.Text == "Payment")
                    {
                        lblLinks.Text = "~/Pages/Accounts/PaymentVoucherNew.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "~/Pages/Accounts/PaymentVoucherEdit.aspx" + "?id=" + lblVoucherNo.Text;
                    }
                    else if (lblVoucherType.Text == "Purchase")
                    {
                        lblLinks.Text = "~/Pages/Procurement/PurchaseBulk.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "~/Pages/Procurement/PurchaseEdit.aspx" + "?id=" + lblVoucherNo.Text;
                    }
                    else if (lblVoucherType.Text == "Field Sales" || lblVoucherType.Text == "Institutional sales" || lblVoucherType.Text == "Sales Return")
                    {
                        lblLinks.Text = "~/Pages/Sales/SalesInvoice.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "../Sales/SalesInvoiceEdit.aspx" + "?id=" + lblVoucherNo.Text;
                    }
                    else if (lblVoucherType.Text == "Journal")
                    {
                        lblLinks.Text = "~/Pages/Accounts/JournalEntries.aspx";
                        hplinkNavigateInsert.NavigateUrl = lblLinks.Text;
                        hplinkNavigateEdit.NavigateUrl = "../Accounts/JournalVoucherEdit.aspx" + "?id=" + lblVoucherNo.Text;
                    }
                }
            }
        }
        // lblLedgerName.Text = ddlLedger.SelectedItem.Text;
    }

    protected void gridViewLedger_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridViewLedger.PageIndex = e.NewPageIndex;
        gridViewLedger.DataBind();
        OpeningBalance();
        ClosingBalance();
        getLedger();
    }

    protected void ddlLedger_SelectedIndexChanged(object sender, EventArgs e)
    {
        OpeningBalance();
        ClosingBalance();
        getLedger();
        lblLedgerName.Text = ddlLedger.SelectedItem.Text;
    }
    
    private int totalDebit = 0;
    private int totalCredit = 0;
    double runningbalance = 0;
    protected void gridViewLedger_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            totalDebit += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Debit"));
            totalCredit += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Credit"));

            Label lblDebit = e.Row.FindControl("lblDebit") as Label;
            Label lblCredit = e.Row.FindControl("lblCredit") as Label;
            Label lblBalance = e.Row.FindControl("lblBalance") as Label;

            double openingBalance = Convert.ToDouble(lblOpeningBalance.Text);
            double debit = Convert.ToDouble(lblDebit.Text);
            double credit = Convert.ToDouble(lblCredit.Text);
            double balance = 0;
            if (runningbalance == 0)
            {
                balance = (openingBalance + debit) - credit;
            }
            else
            {
                balance = (runningbalance + debit) - credit;
            }
            runningbalance = balance;
            lblBalance.Text = balance.ToString();
            lblClosingBalance.Text = lblBalance.Text;

        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[6].Text = totalDebit.ToString();
            e.Row.Cells[6].Font.Bold = true;
            e.Row.Cells[7].Text = totalCredit.ToString();
            e.Row.Cells[7].Font.Bold = true;
        }
    }

    protected void gridViewLedger_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = 0;
        Label lblVoucherNo = (Label)gridViewLedger.Rows[index].FindControl("lblVoucherNo");
        Label lblVoucherType = (Label)gridViewLedger.Rows[index].FindControl("lblVoucherType");

        if (e.CommandName == "DeleteRow")
        {
            if (Session["RoleId"].ToString() == "1")
            {
                mydal.DeleteReceivePaymentandSalesPurchsase(lblVoucherNo.Text, lblVoucherType.Text);
                gridViewLedger.DataBind();
                getLedger();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('You are not valid user to delete this record!!');", true);
            }
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        DateTime date1 = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

        Session["fromdate"] = date1;
        Session["todate"] = date2;
        Session["id"] = "";
        Session["ledger"] = ddlLedger.SelectedValue;
        Session["ledgerName"] = ddlLedger.SelectedItem.Text;
        Session["openningbalance"] = lblOpeningBalance.Text;
        Session["closingbalance"] = lblClosingBalance.Text;
        Session["dtLedger"] = ledgerReport();
        Response.Redirect("../Reports/rptLedger.aspx");
    }

    protected DataTable ledgerReport()
    {

        DataTable dt = (DataTable)Session["dtledger"];
        runningbalance = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            double openingBalance = Convert.ToDouble(lblOpeningBalance.Text);
            double debit = Convert.ToDouble(dt.Rows[i]["Debit"].ToString());
            double credit = Convert.ToDouble(dt.Rows[i]["Credit"].ToString());

            double balance = 0;
            if (runningbalance == 0)
            {
                balance = (openingBalance + debit) - credit;
            }
            else
            {
                balance = (runningbalance + debit) - credit;
            }
            runningbalance = balance;
            dt.Rows[i]["Balance"] = balance.ToString();
        }
        return dt;
    }
}