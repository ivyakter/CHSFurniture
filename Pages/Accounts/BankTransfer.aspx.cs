using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_BankTransfer : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InvoiceNo();
            GetBank();
            SetInitialRow();
            GetTrType();
            txtDate.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
        }
    }
    public void GetBank()
    {
        DataTable dt = mydal.GetBank();
        ddlBank.DataSource = dt;
        ddlBank.DataTextField = "AccName";
        ddlBank.DataValueField = "AccCode";
        ddlBank.DataBind();
        ddlBank.Items.Insert(0, "--Select Bank Name--");
    }
    public void GetTrType()
    {
        DataTable Dt = mydal.GetTRType();
        ddlIncomeType.DataSource = Dt;
        ddlIncomeType.DataTextField = "AccName";
        ddlIncomeType.DataValueField = "AccCode";
        ddlIncomeType.DataBind();
        ddlIncomeType.Items.Insert(0, "--Select--");

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
        }
        else
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList ddlIncomeTypeTo = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlIncomeTypeTo");
                        TextBox txtCOA = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtCOA");
                        DropDownList ddlBnakTo = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("ddlBankTo");
                        TextBox txtdescription = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtdescription");
                        TextBox txtpayment = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txtpayment"); 
                      
                        string chatrofACC = "Transfer";

                        bool InserttoPaymentvoucherCr = mydal.insertTransfervoucherCR(ddlIncomeType.SelectedItem.ToString(), ddlBank.SelectedItem.ToString(), txtCheck.Text, ddlIncomeType.SelectedItem.Text, ddlIncomeType.SelectedValue, txtVoucherName.Text, txtDate.Text, txtpayment.Text, chatrofACC, ddlIncomeType.SelectedValue);
                        bool InserttoPaymentvoucherDr = mydal.insertTransfervoucherDR(ddlIncomeTypeTo.SelectedItem.ToString(), ddlBnakTo.SelectedItem.ToString(), txtdescription.Text, ddlIncomeTypeTo.SelectedItem.Text, ddlIncomeTypeTo.SelectedValue, txtVoucherName.Text, txtDate.Text, txtpayment.Text, chatrofACC, ddlIncomeTypeTo.SelectedValue);

                        rowIndex++;
                    }
                }
            }          

            Session["VoucherNo"] = txtVoucherName.Text;
            string strconfirm = "<script>if(window.confirm('Save Information Successfully!!!!')){window.location.href='BankTransfer.aspx'}</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);

            SetInitialRow();
            cleantext();
            Gridview1.DataSource = null;
            cleantext();
            InvoiceNo();

        }
    }

    public void cleantext()
    {
        txtDate.Text = "";
        txtComment.Text = "";
    }
    public void InvoiceNo()
    {
        DataTable n = mydal.GetPaymetReceiveId();
        txtVoucherName.Text = "TR-" + n.Rows[0][0].ToString();
    }
    protected void ddlIncomeTypeTo_TextChanged(object sender, EventArgs e)
    {
        DropDownList vendordrop = sender as DropDownList;
        GridViewRow gr = vendordrop.NamingContainer as GridViewRow;
        DropDownList ddlIncomeTypeTo = (DropDownList)gr.Cells[0].FindControl("ddlIncomeTypeTo");
        DropDownList ddlBnakTo = (DropDownList)gr.Cells[0].FindControl("ddlBankTo");
        TextBox txttranjection = (TextBox)gr.Cells[0].FindControl("txtdescription");

        if (ddlIncomeTypeTo.SelectedItem.ToString() == "Bank")
        {
            ddlBnakTo.Visible = true;
            txttranjection.Visible = true; 
        }
        else if (ddlIncomeTypeTo.SelectedItem.ToString() == "Cash")
        {
            ddlBnakTo.Visible = false;         
            txttranjection.Visible = false;
        }
        else
        {
            ddlBnakTo.Visible = false;
            txttranjection.Visible = true;
        }
    }
    protected void ddlIncomeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIncomeType.SelectedItem.ToString() == "Bank")
        {
            ddlBank.Visible = true;
            label3.Visible = true;
            txtCheck.Visible = true;
            label8.Visible = true;

        }
        else if (ddlIncomeType.SelectedItem.ToString() == "Cash")
        {
            label8.Visible = false;
            ddlBank.Visible = false;
            label3.Visible = false;
            txtCheck.Visible = false;
        }
        else
        {
            label8.Visible = false;
            ddlBank.Visible = false;
            label3.Visible = true;
            txtCheck.Visible = true;
        }
        DataTable dtcahsCr = mydal.GetCahBalanceCr(ddlIncomeType.SelectedItem.ToString());
        DataTable dtcahsDr = mydal.GetCahBalanceDr(ddlIncomeType.SelectedItem.ToString());

        double cashcr = Convert.ToDouble(dtcahsCr.Rows[0][0].ToString());
        double cashdr = Convert.ToDouble(dtcahsDr.Rows[0][0].ToString());

        lblBablance.Text = (cashdr - cashcr).ToString();
    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        dt.Columns.Add(new DataColumn("Column7", typeof(string)));
        dt.Columns.Add(new DataColumn("Column8", typeof(string)));
        dt.Columns.Add(new DataColumn("Column9", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dr["Column6"] = string.Empty;
        dr["Column7"] = string.Empty;
        dr["Column8"] = string.Empty;
        dr["Column9"] = string.Empty;
        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlIncomeType");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtCOA");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtpayableamount");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtpayment");


                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;

                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                Gridview1.DataSource = dtCurrentTable;
                Gridview1.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        SetPreviousData();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlIncomeType");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtCOA");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtpayableamount");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtpayment");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();

                    rowIndex++;
                }

            }

        }
    }
    protected void ButtonAdd_Click1(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        Gridview1.DeleteRow(index);
    }
    private void SetPreviousData1(DataTable dtCurrentTable)
    {
        int rowIndex = 0;
        if (dtCurrentTable != null)
        {
            DataTable dt = dtCurrentTable;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlIncomeType");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtCOA");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtpayableamount");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtpayment");


                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "r")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Gridview1.DeleteRow(rowIndex);
        }
    }
    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = mydal.GetBank();
            var Vendorname = (DropDownList)e.Row.FindControl("ddlBankTo");
            Vendorname.DataSource = dt;
            Vendorname.DataTextField = "AccName";
            Vendorname.DataValueField = "AccCode";
            Vendorname.DataBind();
            Vendorname.Items.Insert(0, new ListItem("--Select--", "0"));

            DataTable Dt = mydal.GetTRType();
            var ddlIncomeType = (DropDownList)e.Row.FindControl("ddlIncomeTypeTo");
            ddlIncomeType.DataSource = Dt;
            ddlIncomeType.DataTextField = "AccName";
            ddlIncomeType.DataValueField = "AccCode";
            ddlIncomeType.DataBind();
            ddlIncomeType.Items.Insert(0, "--Select--");
        }

    }

    protected void delete_Click(object sender, EventArgs e)
    {
        Button btndel = sender as Button;
        GridViewRow gr = btndel.NamingContainer as GridViewRow;
        string rownumber = gr.Cells[0].Text;

        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
        {
            DataRow dr = dtCurrentTable.Rows[i];
            if (dtCurrentTable.Rows[i]["RowNumber"].ToString() == rownumber)
                dr.Delete();
        }
        ViewState["CurrentTable"] = dtCurrentTable;
        Gridview1.DataSource = dtCurrentTable;
        Gridview1.DataBind();
        SetPreviousData1(dtCurrentTable);
    }

    //protected void ddlvendorname_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList vendordrop = sender as DropDownList;
    //    GridViewRow gr = vendordrop.NamingContainer as GridViewRow;
    //    DropDownList vendorid = (DropDownList)gr.Cells[0].FindControl("ddlvendorname");

    //    TextBox COA = (TextBox)gr.Cells[0].FindControl("txtCOA");
    //    TextBox txtpayableamount = (TextBox)gr.Cells[0].FindControl("txtpayableamount");

    //    DataTable dt = mydal.GetVandorById(vendorid.SelectedValue);
    //    if (dt.Rows.Count > 0)
    //    {
    //        COA.Text = dt.Rows[0]["AccCode"].ToString();

    //    }

     

    //    DataTable Purchasetotal = mydal.Purchasetotal(vendorid.SelectedItem.ToString());
    //    string totalpurchase = Purchasetotal.Rows[0]["TotalPurchased"].ToString();

    //    if (totalpurchase == "")
    //    {
    //        totalpurchase = "0";
    //    }

        

    //    DataTable Gettotalpaidamount = mydal.totalPaidamount(vendorid.SelectedItem.ToString());
    //    string TotalPaidAmount = Gettotalpaidamount.Rows[0]["PaidAmount"].ToString();

    //    if (TotalPaidAmount == "")
    //    {
    //        TotalPaidAmount = "0";
    //    }

    //    decimal Havetopay = decimal.Parse(totalpurchase) - decimal.Parse(TotalPaidAmount);

    //    txtpayableamount.Text = Havetopay.ToString();
    //}



    protected void txtpayment_TextChanged(object sender, EventArgs e)
    {
        double sum = 0;
        for (int index = 0; index < Gridview1.Rows.Count; index++)
        {
            sum += Convert.ToDouble((Gridview1.Rows[index].FindControl("txtpayment") as TextBox).Text);
        }
        txtalltotal.Text = sum.ToString();

    }
  
}