using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Accounts_PaymentReceive : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        DateClanaderExtender.SelectedDate = DateTime.Today;
        if (!Page.IsPostBack)
        {
            InvoiceNo();
            ShowClientname();
            GetBank();
            LoadBankBranch();
        }

    }
    public void GetBank()
    {
        DataTable dt = mydal.GetBank();
        ddlBank.DataSource = dt;
        ddlBank.DataTextField = "AccNAME";
        ddlBank.DataValueField = "AccCode";
        ddlBank.DataBind();
        ddlBank.Items.Insert(0, "--Select Bank Name--");
    }

    public void GetBankBranch()
    {
        DataTable dt = mydal.GetBankBranchByBank(ddlBank.SelectedValue);
        ddlBranch.DataSource = dt;
        ddlBranch.DataTextField = "BRANCH";
        ddlBranch.DataValueField = "id";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, "--Select Branch Name--");
    }

    public void LoadBankBranch()
    {
        DataTable dt = mydal.GetBankBranchByBank();
        ddlBranch.DataSource = dt;
        ddlBranch.DataTextField = "BRANCH";
        ddlBranch.DataValueField = "id";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, "--Select Branch Name--");
    }

    public void ShowClientname()
    {
        DataTable dt = mydal.GetClientname();
        ddlClient.DataSource = dt;
        ddlClient.DataTextField = "ClientName";
        ddlClient.DataValueField = "ClientID";
        ddlClient.DataBind();
        ddlClient.Items.Insert(0, "--Select--");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
        }
        else
        {
            bool InserttoPaymentrecive = mydal.insertpaymentreceive(DropDownList1.SelectedItem.ToString(), ddlBank.SelectedItem.ToString(), ddlBranch.SelectedItem.ToString(), txtName.Text, txtClientId.Text, txtVoucherName.Text, txtDate.Text, txtPayAmount.Text);

            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Save Information Successfully!!!!');", true);



            cleantext();
        }
        cleantext();
    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = mydal.GetDistributorById(ddlClient.SelectedValue);
        txtName.Text = dt.Rows[0]["ClientName"].ToString();
        txtClientId.Text = dt.Rows[0]["ClientID"].ToString();
        txtAddress.Text = dt.Rows[0]["Address"].ToString();
        txtphone.Text = dt.Rows[0]["ContactNo"].ToString();

    }
    public void cleantext()
    {
        txtName.Text = "";
        txtAddress.Text = "";
        txtDate.Text = "";
        txtphone.Text = "";
        txtComment.Text = "";
    }

    public void InvoiceNo()
    {
        DataTable n = mydal.GetIncoVoucher();
        txtVoucherName.Text = "INC-" + n.Rows[0][0].ToString();
    }
    
    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBankBranch();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "1")
        {
            ddlBank.Visible = false;
            label3.Visible = false;
            ddlBranch.Visible = false;
            label9.Visible = false;
            label6.Visible = false;
            txtComment.Visible = false;

        }
        else
        {
            ddlBank.Visible = true;
            label3.Visible = true;
            ddlBranch.Visible = true;
            label9.Visible = true;
            label6.Visible = true;
            txtComment.Visible = true;
        }

    }

}