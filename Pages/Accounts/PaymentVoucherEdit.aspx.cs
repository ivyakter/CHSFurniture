using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_PaymentVoucherEdit : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // SetInitialRow();
            LoadTranType();
            LoadVoucherNo();
            
        }
    }

    public void LoadTranType()
    {
        DataTable Dt = mydal.GetTRType();     
        ddlIncomeType.DataSource = Dt;
        ddlIncomeType.DataTextField = "AccName";
        ddlIncomeType.DataValueField = "AccCode";
        ddlIncomeType.DataBind();
        ddlIncomeType.Items.Insert(0, "--Select--");
    }
    public void cleantext()
    {
        //ddlvendorname.SelectedItem.Text = "";
        //txtSupplierName.Text = "";
        txtAddress.Text = "";
        txtDate.Text = "";
        txtComment.Text = "";
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

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dr["Column6"] = string.Empty;
        dr["Column7"] = string.Empty;

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
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtamount");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlIncomeType");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtdescription");
                    HiddenField box4 = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("TranssactionTypename");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;

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
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtamount");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlIncomeType");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtdescription");
                    HiddenField box4 = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("TranssactionTypename");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();

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
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtamount");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlIncomeType");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtdescription");
                    HiddenField box4 = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("TranssactionTypename");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();


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
    double total1 = 0;
    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = mydal.GetAccountsPayableForCashBook();
            var Vendorname = (DropDownList)e.Row.FindControl("ddlvendorname");
            Vendorname.DataSource = dt;
            Vendorname.DataTextField = "AccName";
            Vendorname.DataValueField = "AccCode";
            Vendorname.DataBind();
            Vendorname.Items.Insert(0, new ListItem("--Select--", "0"));
            
            HiddenField hfVendorName = (HiddenField)e.Row.FindControl("hfvendorname");
            Vendorname.SelectedItem.Text = hfVendorName.Value;

            
        }

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
                    bool delete = mydal.PaymentVoucherDeletebyvoucherfromexpence(ddlvoucherno.SelectedItem.Text);
                    bool deleteExpenselist = mydal.PaymentVoucherDeletebyvoucherfromexpenceList(ddlvoucherno.SelectedItem.Text);

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList ddlVendor = (DropDownList)Gridview1.Rows[rowIndex].FindControl("ddlvendorname");
                        TextBox txtpayment = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtamount");
                        TextBox txtdescription = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtdescription");
                        HiddenField DbRownumber = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("DbRownumber");

                        string rownumber = DbRownumber.Value;

                        bool UpdateRecivevoucher = mydal.UpdatePaymentvoucher(ddlVendor.SelectedItem.Text, ddlVendor.SelectedValue, ddlvoucherno.SelectedItem.Text, txtpayment.Text, txtDate.Text, rownumber);

                        if (UpdateRecivevoucher == true)
                        {                         

                            bool InsertExpenseVoucher = mydal.InsertExpenseVoucher1(ddlVendor.SelectedValue, ddlvoucherno.SelectedItem.Text, txtdescription.Text, txtDate.Text, txtpayment.Text);
                            bool InsertExpenseVoucherList = mydal.InsertExpenseVoucherList1( ddlIncomeType.SelectedItem.ToString(), ddlvoucherno.SelectedItem.Text, txtComment.Text, txtDate.Text, txtpayment.Text);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Something Went Wrong!!!!');", true);
                        }
                        rowIndex++;
                    }
                }
            }          
          
            Session["VoucherNo"] = txtVoucherName.Text;

            string strconfirm = "<script>if(window.confirm('Update Successfully!!!!')){window.location.href='ViewExpenseVoucher.aspx'}</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);

            //SetInitialRow();
            //cleantext();
           // Gridview1.DataSource = null;
            cleantext();
        }
    }
    protected void delete_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            string VoucherNo = ddlvoucherno.SelectedValue;

            bool delete = mydal.PaymentVoucherDeletebyvoucherfromexpence(VoucherNo);
            bool deleteExpenselist = mydal.PaymentVoucherDeletebyvoucherfromexpenceList(VoucherNo);
            bool deleteRecivePayment = mydal.PaymentVoucherDeletebyvoucherfromRecivePayment(VoucherNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LoadVoucherNo()
    {
        DataTable getvoucherbyclient = mydal.getAllPaymentVoucher();
        if (getvoucherbyclient.Rows.Count > 0)
        {
            ddlvoucherno.DataSource = getvoucherbyclient;
            ddlvoucherno.DataTextField = "VoucherNo";
            ddlvoucherno.DataValueField = "VoucherNo";
            ddlvoucherno.DataBind();
            ddlvoucherno.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        if (Request.QueryString["Id"] != "")
        {
            ddlvoucherno.SelectedValue = Request.QueryString["Id"];
            ddlvoucherno.SelectedItem.Text = Request.QueryString["Id"];
            ddlvoucherno_SelectedIndexChanged(null, null);
        }
    }

    protected void ddlvoucherno_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = mydal.GetPaymentdetailsbyclient(ddlvoucherno.SelectedItem.Text);

        Gridview1.DataSource = dt;
        Gridview1.DataBind();

        ViewState["CurrentTable"] = dt;
        Gridview1.DataSource = dt;
        Gridview1.DataBind();

        txtDate.Text = dt.Rows[0]["Date"].ToString();
        txtComment.Text = dt.Rows[0]["Comment"].ToString();
        //ddlIncomeType.DataSource = dt;
        //ddlIncomeType.DataBind();
        ddlIncomeType.SelectedValue = dt.Rows[0]["Trans_Type"].ToString();
        ddlIncomeType.SelectedItem.Text = dt.Rows[0]["Trans_Type"].ToString();

        double sum = 0;
        for (int index = 0; index < Gridview1.Rows.Count; index++)
        {
            sum += Convert.ToDouble((Gridview1.Rows[index].FindControl("txtamount") as TextBox).Text);
        }
        lblratesum.Text = sum.ToString();
    }

    protected void txtamount_TextChanged(object sender, EventArgs e)
    {
        double sum = 0;
        for (int index = 0; index < Gridview1.Rows.Count; index++)
        {
            sum += Convert.ToDouble((Gridview1.Rows[index].FindControl("txtamount") as TextBox).Text);
        }
        lblratesum.Text = sum.ToString(); ;
    }
}